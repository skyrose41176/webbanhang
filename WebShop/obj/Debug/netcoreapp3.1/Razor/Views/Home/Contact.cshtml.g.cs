#pragma checksum "F:\webbanhang\shop\WebShop\Views\Home\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ead0a29fe4fa23105a47161e8d9bc4d82ed617e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\webbanhang\shop\WebShop\Views\_ViewImports.cshtml"
using WebShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\webbanhang\shop\WebShop\Views\_ViewImports.cshtml"
using WebShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ead0a29fe4fa23105a47161e8d9bc4d82ed617e", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c556b273de8c6e9b39dcb44a04dfc25438d88853", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("contact-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("http://demo.hasthemes.com/limupa-v3/limupa/mail.php"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\webbanhang\shop\WebShop\Views\Home\Contact.cshtml"
  
    ViewData["Title"] = "Contact";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n       <!-- Begin Li\'s Breadcrumb Area -->\r\n            <div class=\"breadcrumb-area\">\r\n                <div class=\"container\">\r\n                    <div class=\"breadcrumb-content\">\r\n                        <ul>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 291, "\"", 298, 0);
            EndWriteAttribute();
            WriteLiteral(">Home</a></li>\r\n                            <li class=\"active\">");
#nullable restore
#line 11 "F:\webbanhang\shop\WebShop\Views\Home\Contact.cshtml"
                                          Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- Li's Breadcrumb Area End Here -->     
            <!-- Begin Contact Main Page Area -->
            <div class=""contact-main-page mt-60 mb-40 mb-md-40 mb-sm-40 mb-xs-40"">
                <div class=""container mb-60"">
                    <div id=""google-map""></div>
                </div>
                <div class=""container"">
                    <div class=""row"">
                        <div class=""col-lg-5 offset-lg-1 col-md-12 order-1 order-lg-2"">
                            <div class=""contact-page-side-content"">
                                <h3 class=""contact-page-title"">Contact Us</h3>
                                <p class=""contact-page-message mb-25"">Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram anteposuerit litterarum formas human.</p>
              ");
            WriteLiteral(@"                  <div class=""single-contact-block"">
                                    <h4><i class=""fa fa-fax""></i> Address</h4>
                                    <p>123 Main Street, Anytown, CA 12345 – USA</p>
                                </div>
                                <div class=""single-contact-block"">
                                    <h4><i class=""fa fa-phone""></i> Phone</h4>
                                    <p>Mobile: (08) 123 456 789</p>
                                    <p>Hotline: 1009 678 456</p>
                                </div>
                                <div class=""single-contact-block last-child"">
                                    <h4><i class=""fa fa-envelope-o""></i> Email</h4>
                                    <p>yourmail@domain.com</p>
                                    <p>support@hastech.company</p>
                                </div>
                            </div>
                        </div>
                        <div class=""co");
            WriteLiteral(@"l-lg-6 col-md-12 order-2 order-lg-1"">
                            <div class=""contact-form-content pt-sm-55 pt-xs-55"">
                                <h3 class=""contact-page-title"">Tell Us Your Message</h3>
                                <div class=""contact-form"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ead0a29fe4fa23105a47161e8d9bc4d82ed617e7503", async() => {
                WriteLiteral(@"
                                        <div class=""form-group"">
                                            <label>Your Name <span class=""required"">*</span></label>
                                            <input type=""text"" name=""customerName"" id=""customername"" required>
                                        </div>
                                        <div class=""form-group"">
                                            <label>Your Email <span class=""required"">*</span></label>
                                            <input type=""email"" name=""customerEmail"" id=""customerEmail"" required>
                                        </div>
                                        <div class=""form-group"">
                                            <label>Subject</label>
                                            <input type=""text"" name=""contactSubject"" id=""contactSubject"">
                                        </div>
                                        <div class=""form-group mb-30"">
 ");
                WriteLiteral(@"                                           <label>Your Message</label>
                                            <textarea name=""contactMessage"" id=""contactMessage"" ></textarea>
                                        </div>
                                        <div class=""form-group"">
                                            <button type=""submit"" value=""submit"" id=""submit"" class=""li-btn-3"" name=""submit"">send</button>
                                        </div>
                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </div>
                                <p class=""form-messege""></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Contact Main Page Area End Here -->
            <!-- Google Map -->
            <script src=""https://maps.google.com/maps/api/js?sensor=false&amp;libraries=geometry&amp;v=3.22&amp;key=AIzaSyChs2QWiAhnzz0a4OEhzqCXwx_qA9ST_lE""></script>
            
            <script>
                // When the window has finished loading create our google map below
                google.maps.event.addDomListener(window, 'load', init);
                function init() {
                    // Basic options for a simple Google Map
                    // For more options see: https://developers.google.com/maps/documentation/javascript/reference#MapOptions
                    var mapOptions = {
                        // How zoomed in you want the map to start ");
            WriteLiteral(@"at (always required)
                        zoom: 12,
                        scrollwheel: false,
                        // The latitude and longitude to center the map (always required)
                        center: new google.maps.LatLng(40.740610, -73.935242), // New York
                        // How you would like to style the map. 
                        // This is where you would paste any style found on
                        styles: [{
                                ""featureType"": ""water"",
                                ""elementType"": ""geometry"",
                                ""stylers"": [{
                                        ""color"": ""#e9e9e9""
                                    },
                                    {
                                        ""lightness"": 17
                                    }
                                ]
                            },
                            {
                                ""featureType"": ""landscape"",
  ");
            WriteLiteral(@"                              ""elementType"": ""geometry"",
                                ""stylers"": [{
                                        ""color"": ""#f5f5f5""
                                    },
                                    {
                                        ""lightness"": 20
                                    }
                                ]
                            },
                            {
                                ""featureType"": ""road.highway"",
                                ""elementType"": ""geometry.fill"",
                                ""stylers"": [{
                                        ""color"": ""#ffffff""
                                    },
                                    {
                                        ""lightness"": 17
                                    }
                                ]
                            },
                            {
                                ""featureType"": ""road.highway"",
             ");
            WriteLiteral(@"                   ""elementType"": ""geometry.stroke"",
                                ""stylers"": [{
                                        ""color"": ""#ffffff""
                                    },
                                    {
                                        ""lightness"": 29
                                    },
                                    {
                                        ""weight"": 0.2
                                    }
                                ]
                            },
                            {
                                ""featureType"": ""road.arterial"",
                                ""elementType"": ""geometry"",
                                ""stylers"": [{
                                        ""color"": ""#ffffff""
                                    },
                                    {
                                        ""lightness"": 18
                                    }
                                ]
              ");
            WriteLiteral(@"              },
                            {
                                ""featureType"": ""road.local"",
                                ""elementType"": ""geometry"",
                                ""stylers"": [{
                                        ""color"": ""#ffffff""
                                    },
                                    {
                                        ""lightness"": 16
                                    }
                                ]
                            },
                            {
                                ""featureType"": ""poi"",
                                ""elementType"": ""geometry"",
                                ""stylers"": [{
                                        ""color"": ""#f5f5f5""
                                    },
                                    {
                                        ""lightness"": 21
                                    }
                                ]
                            },
         ");
            WriteLiteral(@"                   {
                                ""featureType"": ""poi.park"",
                                ""elementType"": ""geometry"",
                                ""stylers"": [{
                                        ""color"": ""#dedede""
                                    },
                                    {
                                        ""lightness"": 21
                                    }
                                ]
                            },
                            {
                                ""elementType"": ""labels.text.stroke"",
                                ""stylers"": [{
                                        ""visibility"": ""on""
                                    },
                                    {
                                        ""color"": ""#ffffff""
                                    },
                                    {
                                        ""lightness"": 16
                                    }
           ");
            WriteLiteral(@"                     ]
                            },
                            {
                                ""elementType"": ""labels.text.fill"",
                                ""stylers"": [{
                                        ""saturation"": 36
                                    },
                                    {
                                        ""color"": ""#333333""
                                    },
                                    {
                                        ""lightness"": 40
                                    }
                                ]
                            },
                            {
                                ""elementType"": ""labels.icon"",
                                ""stylers"": [{
                                    ""visibility"": ""off""
                                }]
                            },
                            {
                                ""featureType"": ""transit"",
                           ");
            WriteLiteral(@"     ""elementType"": ""geometry"",
                                ""stylers"": [{
                                        ""color"": ""#f2f2f2""
                                    },
                                    {
                                        ""lightness"": 19
                                    }
                                ]
                            },
                            {
                                ""featureType"": ""administrative"",
                                ""elementType"": ""geometry.fill"",
                                ""stylers"": [{
                                        ""color"": ""#fefefe""
                                    },
                                    {
                                        ""lightness"": 20
                                    }
                                ]
                            },
                            {
                                ""featureType"": ""administrative"",
                                ""e");
            WriteLiteral(@"lementType"": ""geometry.stroke"",
                                ""stylers"": [{
                                        ""color"": ""#fefefe""
                                    },
                                    {
                                        ""lightness"": 17
                                    },
                                    {
                                        ""weight"": 1.2
                                    }
                                ]
                            }
                        ]
                    };

                    // Get the HTML DOM element that will contain your map 
                    // We are using a div with id=""map"" seen below in the <body>
                    var mapElement = document.getElementById('google-map');

                    // Create the Google Map using our element and options defined above
                    var map = new google.maps.Map(mapElement, mapOptions);

                    // Let's also add a marker whi");
            WriteLiteral(@"le we're at it
                    var marker = new google.maps.Marker({
                        position: new google.maps.LatLng(40.740610, -73.935242),
                        map: map,
                        title: 'Limupa',
                        animation: google.maps.Animation.BOUNCE
                    });
                }
            </script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
