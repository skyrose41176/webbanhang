#pragma checksum "F:\webbanhang\shop\WebShop\Views\Home\FAQ.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe09f882dc9ef1d4de973b4562184cf0af2311c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FAQ), @"mvc.1.0.view", @"/Views/Home/FAQ.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe09f882dc9ef1d4de973b4562184cf0af2311c6", @"/Views/Home/FAQ.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c556b273de8c6e9b39dcb44a04dfc25438d88853", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FAQ : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\webbanhang\shop\WebShop\Views\Home\FAQ.cshtml"
  
    ViewData["Title"] = "FAQ";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      <!-- Begin Li\'s Breadcrumb Area -->\r\n            <div class=\"breadcrumb-area\">\r\n                <div class=\"container\">\r\n                    <div class=\"breadcrumb-content\">\r\n                        <ul>\r\n                            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe09f882dc9ef1d4de973b4562184cf0af2311c63992", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                            <li class=\"active\">");
#nullable restore
#line 11 "F:\webbanhang\shop\WebShop\Views\Home\FAQ.cshtml"
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
            <!-- Begin Frequently Area -->
            <div class=""frequently-area pt-60 pb-50"">
                <div class=""container"">
                    <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""frequently-content"">
                                <div class=""frequently-desc"">
                                    <h3>Below are frequently asked questions, you may find the answer for yourself</h3>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec id erat sagittis, faucibus metus malesuada, eleifend turpis. Mauris semper augue id nisl aliquet, a porta lectus mattis. Nulla at tortor augue. In eget enim diam. Donec gravida tortor sem, ac fermentum nibh rutrum sit amet. Nulla convallis mauris vitae congue consequat. Donec interdum ");
            WriteLiteral(@"nunc purus, vitae vulputate arcu fringilla quis. Vivamus iaculis euismod dui.</p>
                                </div>
                            </div>
                            <!-- Begin Frequently Accordin -->
                            <div class=""frequently-accordion"">
                                <div id=""accordion"">
                                  <div class=""card actives"">
                                    <div class=""card-header"" id=""headingOne"">
                                      <h5 class=""mb-0"">
                                        <a");
            BeginWriteAttribute("class", " class=\"", 2013, "\"", 2021, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-toggle=""collapse"" data-target=""#collapseOne"" aria-expanded=""true"" aria-controls=""collapseOne"">
                                          Mauris congue euismod purus at semper. Morbi et vulputate massa?
                                        </a>
                                      </h5>
                                    </div>
                                    <div id=""collapseOne"" class=""collapse show"" aria-labelledby=""headingOne"" data-parent=""#accordion"">
                                      <div class=""card-body"">
                                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butc");
            WriteLiteral(@"her vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                      </div>
                                    </div>
                                  </div>
                                  <div class=""card"">
                                    <div class=""card-header"" id=""headingTwo"">
                                      <h5 class=""mb-0"">
                                        <a class=""collapsed"" data-toggle=""collapse"" data-target=""#collapseTwo"" aria-expanded=""false"" aria-controls=""collapseTwo"">
                                          Donec mattis finibus elit ut tristique?
                                        </a>
                                      </h5>
                                    </div>
                                    <div id=""collapseTwo"" class=""collapse"" aria-labelledby=""headingTwo"" data-parent=""#accordion"">
                          ");
            WriteLiteral(@"            <div class=""card-body"">
                                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                      </div>
                                    </div>
                                  </div>
                                  <div class=""card"">
                                    <div class=""card-header"" id=""headingThree"">
                                      <h5 class=""mb-0"">
                   ");
            WriteLiteral(@"                     <a class=""collapsed"" data-toggle=""collapse"" data-target=""#collapseThree"" aria-expanded=""false"" aria-controls=""collapseThree"">
                                          Vestibulum a lorem placerat, porttitor urna vel?
                                        </a>
                                      </h5>
                                    </div>
                                    <div id=""collapseThree"" class=""collapse"" aria-labelledby=""headingThree"" data-parent=""#accordion"">
                                      <div class=""card-body"">
                                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proi");
            WriteLiteral(@"dent. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                      </div>
                                    </div>
                                  </div>
                                  <div class=""card"">
                                    <div class=""card-header"" id=""headingFour"">
                                      <h5 class=""mb-0"">
                                        <a class=""collapsed"" data-toggle=""collapse"" data-target=""#collapseFour"" aria-expanded=""false"" aria-controls=""collapseFour"">
                                          Aenean elit orci, efficitur quis nisl at, accumsan?
                                        </a>
                                      </h5>
                                    </div>
                                    <div id=""collapseFour"" class=""collapse"" aria-labelledby=""headingFour"" data-pa");
            WriteLiteral(@"rent=""#accordion"">
                                      <div class=""card-body"">
                                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                      </div>
                                    </div>
                                  </div>
                                  <div class=""card"">
                                    <div class=""card-header"" id=""headingFive"">
                               ");
            WriteLiteral(@"       <h5 class=""mb-0"">
                                        <a class=""collapsed"" data-toggle=""collapse"" data-target=""#collapseFive"" aria-expanded=""false"" aria-controls=""collapseFive"">
                                          Pellentesque habitant morbi tristique senectus et netus?
                                        </a>
                                      </h5>
                                    </div>
                                    <div id=""collapseFive"" class=""collapse"" aria-labelledby=""headingFive"" data-parent=""#accordion"">
                                      <div class=""card-body"">
                                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer l");
            WriteLiteral(@"abore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                      </div>
                                    </div>
                                  </div>
                                  <div class=""card"">
                                    <div class=""card-header"" id=""headingSix"">
                                      <h5 class=""mb-0"">
                                        <a class=""collapsed"" data-toggle=""collapse"" data-target=""#collapseSix"" aria-expanded=""false"" aria-controls=""collapseSix"">
                                          Nam pellentesque aliquam metus?
                                        </a>
                                      </h5>
                                    </div>
                                    <div id=""collapseSix"" class=""collapse"" aria-labelle");
            WriteLiteral(@"dby=""headingSix"" data-parent=""#accordion"">
                                      <div class=""card-body"">
                                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                      </div>
                                    </div>
                                  </div>
                                  <div class=""card"">
                                    <div class=""card-header"" id=""headingSeven"">
      ");
            WriteLiteral(@"                                <h5 class=""mb-0"">
                                        <a class=""collapsed"" data-toggle=""collapse"" data-target=""#collapseSeven"" aria-expanded=""false"" aria-controls=""collapseSeven"">
                                          Aenean elit orci, efficitur quis nisl at?
                                        </a>
                                      </h5>
                                    </div>
                                    <div id=""collapseSeven"" class=""collapse"" aria-labelledby=""headingSeven"" data-parent=""#accordion"">
                                      <div class=""card-body"">
                                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica");
            WriteLiteral(@", craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                      </div>
                                    </div>
                                  </div>
                                  <div class=""card"">
                                    <div class=""card-header"" id=""headingEight"">
                                      <h5 class=""mb-0"">
                                        <a class=""collapsed"" data-toggle=""collapse"" data-target=""#collapseEight"" aria-expanded=""false"" aria-controls=""collapseEight"">
                                          Morbi gravida, nisi id fringilla ultricies, elit lorem?
                                        </a>
                                      </h5>
                                    </div>
                                    <div id");
            WriteLiteral(@"=""collapseEight"" class=""collapse"" aria-labelledby=""headingEight"" data-parent=""#accordion"">
                                      <div class=""card-body"">
                                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                      </div>
                                    </div>
                                  </div>
                                </div>
                            </div>
                 ");
            WriteLiteral("           <!--Frequently Accordin End Here -->\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <!--Frequently Area End Here -->");
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
