using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebShop.PayPalHelpers
{
    public class PayPalAPI{
        public IConfiguration configuration{get;}

        public PayPalAPI(IConfiguration _configuration){
            configuration = _configuration;
        }

        public async Task<string> getRedirectUrlToPayPal(double total,string currency){
            try
            {
                return Task.Run(async () => 
                {    
                    HttpClient http = GetPaypalHttpClient();
                    PayPalAccessToken accessToken = await GetPayPalAccessTokenAsync(http);
                    PayPalPaymentCreatedResponse createdPayment = await CreatedPayPalPaymentAsync(http,accessToken,total,currency);
                    return createdPayment.links.First(x => x.rel == "approval_url").href;
                }).Result;

            }
            catch(Exception ex){
                Debug.WriteLine(ex,"Fail");
                return null;
            }
        }
        public async Task<PayPalPaymentExecutedResponse> executedPayment(string paymentId,string payerId){
            try{
                HttpClient http = GetPaypalHttpClient();
                PayPalAccessToken accessToken = await GetPayPalAccessTokenAsync(http);
                return await executedPaymentAsync(http,accessToken,paymentId,payerId);
            }catch(Exception ex){
                Debug.WriteLine(ex,"Fail");
                return null;
            }
        }
        private HttpClient GetPaypalHttpClient(){
            string sandbox = configuration["PayPal:urlAPI"];
            var http = new HttpClient{
                    BaseAddress= new Uri(sandbox),
                    Timeout=TimeSpan.FromSeconds(30)
            };
            return http;
        }
        private async Task<PayPalAccessToken> GetPayPalAccessTokenAsync(HttpClient http){
            Byte[] bytes= Encoding.GetEncoding("iso-8859-1")
            .GetBytes($"{configuration["PayPal:ClientId"]}:{configuration["PayPal:Secret"]}");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,"/v1/oauth2/token");
            request.Headers.Authorization =  new AuthenticationHeaderValue("Basic",Convert.ToBase64String(bytes));
            var form = new Dictionary<string,string>
            {   
                    ["grant_type"] = "client_credentials"
            };

            request.Content= new FormUrlEncodedContent(form);

            HttpResponseMessage responce = await http.SendAsync(request);

            string content  = await responce.Content.ReadAsStringAsync();

            PayPalAccessToken accessToken = JsonConvert.DeserializeObject<PayPalAccessToken>(content);
            return accessToken;
        }
         private async Task<PayPalPaymentCreatedResponse> CreatedPayPalPaymentAsync(HttpClient http,PayPalAccessToken accessToken1,double total,string currency)
         {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,"/v1/payments/payment");
            request.Headers.Authorization =  new AuthenticationHeaderValue("Bearer",accessToken1.access_token);
            var payment = JObject.FromObject(
                new{
                    intent = "sale",
                    redirect_urls = new{
                        return_url = configuration["PayPal:returnUrl"],
                        cancel_url = configuration["PayPal:CancelUrl"]
                    },
                    payer = new { payment_method = "paypal" },
                    transactions = JArray.FromObject(new[]{
                        new{
                            amount = new{
                                total = total,
                                currency = currency
                            }
                        }
                    })
                });
            
            request.Content= new StringContent(JsonConvert.SerializeObject(payment),Encoding.UTF8,"application/json");

            HttpResponseMessage responce = await http.SendAsync(request);

            string content  = await responce.Content.ReadAsStringAsync();

            PayPalPaymentCreatedResponse PayPalPaymentCreated = JsonConvert.DeserializeObject<PayPalPaymentCreatedResponse>(content);
            return PayPalPaymentCreated;
        }
         private async Task<PayPalPaymentExecutedResponse> executedPaymentAsync(HttpClient http,PayPalAccessToken accessToken1,string paymentId,string payerId)
         {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,$"/v1/payments/payment/{paymentId}/execute");
            request.Headers.Authorization =  new AuthenticationHeaderValue("Bearer",accessToken1.access_token);
            var payment = JObject.FromObject(new
            {
                payer_id = payerId
            });
            
            request.Content= new StringContent(JsonConvert.SerializeObject(payment),Encoding.UTF8,"application/json");

            HttpResponseMessage responce = await http.SendAsync(request);

            string content  = await responce.Content.ReadAsStringAsync();

            PayPalPaymentExecutedResponse executedPayment = JsonConvert.DeserializeObject<PayPalPaymentExecutedResponse>(content);
            return executedPayment;
        }
    }
}