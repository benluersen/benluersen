#pragma checksum "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d1f339076bca98d1fcf5364ad39e8b515d99822"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Park_Detail), @"mvc.1.0.view", @"/Views/Park/Detail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Park/Detail.cshtml", typeof(AspNetCore.Views_Park_Detail))]
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
#line 1 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\_ViewImports.cshtml"
using ParkGeekMVC;

#line default
#line hidden
#line 2 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\_ViewImports.cshtml"
using ParkGeekMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d1f339076bca98d1fcf5364ad39e8b515d99822", @"/Views/Park/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15185d71b3921f30edf676e73fad43fd81bdf08f", @"/Views/_ViewImports.cshtml")]
    public class Views_Park_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ParkViewModel>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(22, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Title", async() => {
                BeginContext(42, 20, true);
                WriteLiteral("\r\n    Park Details\r\n");
                EndContext();
            }
            );
            BeginContext(65, 93, true);
            WriteLiteral("\r\n\r\n<section>\r\n    <div class=\"detail-container\">\r\n        <div id=\"image\">\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 158, "\"", 201, 3);
            WriteAttributeValue("", 164, "/img/parks/", 164, 11, true);
#line 12 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
WriteAttributeValue("", 175, Model.Park.ParkCode, 175, 22, false);

#line default
#line hidden
            WriteAttributeValue("", 197, ".jpg", 197, 4, true);
            EndWriteAttribute();
            BeginContext(202, 77, true);
            WriteLiteral(" />\r\n        </div>\r\n\r\n        <div class=\"detail-details\">\r\n            <h2>");
            EndContext();
            BeginContext(280, 19, false);
#line 16 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
           Write(Model.Park.ParkName);

#line default
#line hidden
            EndContext();
            BeginContext(299, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(302, 16, false);
#line 16 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                                 Write(Model.Park.State);

#line default
#line hidden
            EndContext();
            BeginContext(318, 35, true);
            WriteLiteral("</h2>\r\n            <div id=\"quote\">");
            EndContext();
            BeginContext(354, 29, false);
#line 17 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                       Write(Model.Park.InspirationalQuote);

#line default
#line hidden
            EndContext();
            BeginContext(383, 43, true);
            WriteLiteral("</div>\r\n            <div id=\"quote-source\">");
            EndContext();
            BeginContext(427, 35, false);
#line 18 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                              Write(Model.Park.InspirationalQuoteSource);

#line default
#line hidden
            EndContext();
            BeginContext(462, 117, true);
            WriteLiteral("</div>\r\n            <br /><br />\r\n            <table>\r\n                <tr>\r\n                    <td><b>Acreage: </b>");
            EndContext();
            BeginContext(580, 18, false);
#line 22 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                                   Write(Model.Park.Acreage);

#line default
#line hidden
            EndContext();
            BeginContext(598, 52, true);
            WriteLiteral("<b></td>\r\n                    <td><b>Elevation: </b>");
            EndContext();
            BeginContext(651, 26, false);
#line 23 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                                     Write(Model.Park.ElevationInFeet);

#line default
#line hidden
            EndContext();
            BeginContext(677, 47, true);
            WriteLiteral("</td>\r\n                    <td><b>Climate: </b>");
            EndContext();
            BeginContext(725, 18, false);
#line 24 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                                   Write(Model.Park.Climate);

#line default
#line hidden
            EndContext();
            BeginContext(743, 50, true);
            WriteLiteral("</td>\r\n                    <td><b>Entry Fee: $</b>");
            EndContext();
            BeginContext(794, 19, false);
#line 25 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                                      Write(Model.Park.EntryFee);

#line default
#line hidden
            EndContext();
            BeginContext(813, 99, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td><b>Miles of Trail: </b>");
            EndContext();
            BeginContext(913, 23, false);
#line 28 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                                          Write(Model.Park.MilesOfTrail);

#line default
#line hidden
            EndContext();
            BeginContext(936, 59, true);
            WriteLiteral("</td>\r\n                    <td><b>Number of Campsites: </b>");
            EndContext();
            BeginContext(996, 28, false);
#line 29 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                                               Write(Model.Park.NumberOfCampsites);

#line default
#line hidden
            EndContext();
            BeginContext(1024, 55, true);
            WriteLiteral("</td>\r\n                    <td><b>Annual Visitors: </b>");
            EndContext();
            BeginContext(1080, 25, false);
#line 30 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                                           Write(Model.Park.AnnualVisitors);

#line default
#line hidden
            EndContext();
            BeginContext(1105, 64, true);
            WriteLiteral("</td>\r\n                    <td><b>Number of Animal Species: </b>");
            EndContext();
            BeginContext(1170, 27, false);
#line 31 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                                                    Write(Model.Park.NumAnimalSpecies);

#line default
#line hidden
            EndContext();
            BeginContext(1197, 116, true);
            WriteLiteral("</td>\r\n                </tr>\r\n            </table>\r\n        </div>\r\n    </div>\r\n    <div id=\"detail_description\"><p>");
            EndContext();
            BeginContext(1314, 26, false);
#line 36 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                               Write(Model.Park.ParkDescription);

#line default
#line hidden
            EndContext();
            BeginContext(1340, 483, true);
            WriteLiteral(@"</p></div>
</section>




<div id=""exTab2"" class=""container"">
    <ul class=""nav nav-tabs"">
        <li class=""active"">
            <a href=""#1"" data-toggle=""tab"">Farenheit  |  </a>
        </li>
        <li>
            <a href=""#2"" data-toggle=""tab"">Celsius</a>
        </li>
    </ul>

    <div class=""tab-content "">
        <div class=""tab-pane active"" id=""1"">
            <div class=""farenheit"">
                <div id=""forecast-today"">
                    ");
            EndContext();
            BeginContext(1823, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d1f339076bca98d1fcf5364ad39e8b515d9982210658", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1833, "~/img/weather/", 1833, 14, true);
#line 56 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
AddHtmlAttributeValue("", 1847, Model.WeatherPicString(Model.FiveDayForeCast[0].Forecast), 1847, 60, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 1907, ".png", 1907, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1915, 31, true);
            WriteLiteral("\r\n                    <p>High: ");
            EndContext();
            BeginContext(1947, 33, false);
#line 57 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                        Write(Model.FiveDayForeCast[0].HighTemp);

#line default
#line hidden
            EndContext();
            BeginContext(1980, 34, true);
            WriteLiteral("</p>\r\n                    <p>Low: ");
            EndContext();
            BeginContext(2015, 32, false);
#line 58 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                       Write(Model.FiveDayForeCast[0].LowTemp);

#line default
#line hidden
            EndContext();
            BeginContext(2047, 29, true);
            WriteLiteral("</p>\r\n                    <p>");
            EndContext();
            BeginContext(2077, 63, false);
#line 59 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                  Write(Model.WeatherWarningForecast(Model.FiveDayForeCast[0].Forecast));

#line default
#line hidden
            EndContext();
            BeginContext(2140, 74, true);
            WriteLiteral("</p>\r\n                </div>\r\n                <div id=\"forecast-future\">\r\n");
            EndContext();
#line 62 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                     for (int i = 1; i < Model.FiveDayForeCast.Count; i++)
                    {

#line default
#line hidden
            BeginContext(2313, 80, true);
            WriteLiteral("                        <div id=\"forecast-single\">\r\n                            ");
            EndContext();
            BeginContext(2393, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d1f339076bca98d1fcf5364ad39e8b515d9982214171", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2403, "~/img/weather/", 2403, 14, true);
#line 65 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
AddHtmlAttributeValue("", 2417, Model.WeatherPicString(Model.FiveDayForeCast[i].Forecast), 2417, 60, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 2477, ".png", 2477, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2485, 39, true);
            WriteLiteral("\r\n                            <p>High: ");
            EndContext();
            BeginContext(2525, 33, false);
#line 66 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                                Write(Model.FiveDayForeCast[i].HighTemp);

#line default
#line hidden
            EndContext();
            BeginContext(2558, 42, true);
            WriteLiteral("</p>\r\n                            <p>Low: ");
            EndContext();
            BeginContext(2601, 32, false);
#line 67 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                               Write(Model.FiveDayForeCast[i].LowTemp);

#line default
#line hidden
            EndContext();
            BeginContext(2633, 38, true);
            WriteLiteral("</p>\r\n                        </div>\r\n");
            EndContext();
#line 69 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                    }

#line default
#line hidden
            BeginContext(2694, 201, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"tab-pane\" id=\"2\">\r\n\r\n            <div class=\"celsius\">\r\n                <div id=\"forecast-today\">\r\n                    ");
            EndContext();
            BeginContext(2895, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d1f339076bca98d1fcf5364ad39e8b515d9982217302", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2905, "~/img/weather/", 2905, 14, true);
#line 78 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
AddHtmlAttributeValue("", 2919, Model.WeatherPicString(Model.FiveDayForeCast[0].Forecast), 2919, 60, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 2979, ".png", 2979, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2987, 31, true);
            WriteLiteral("\r\n                    <p>High: ");
            EndContext();
            BeginContext(3019, 53, false);
#line 79 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                        Write(Model.ConvertTempC(Model.FiveDayForeCast[0].HighTemp));

#line default
#line hidden
            EndContext();
            BeginContext(3072, 34, true);
            WriteLiteral("</p>\r\n                    <p>Low: ");
            EndContext();
            BeginContext(3107, 52, false);
#line 80 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                       Write(Model.ConvertTempC(Model.FiveDayForeCast[0].LowTemp));

#line default
#line hidden
            EndContext();
            BeginContext(3159, 29, true);
            WriteLiteral("</p>\r\n                    <p>");
            EndContext();
            BeginContext(3189, 63, false);
#line 81 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                  Write(Model.WeatherWarningForecast(Model.FiveDayForeCast[0].Forecast));

#line default
#line hidden
            EndContext();
            BeginContext(3252, 74, true);
            WriteLiteral("</p>\r\n                </div>\r\n                <div id=\"forecast-future\">\r\n");
            EndContext();
#line 84 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                     for (int i = 1; i < Model.FiveDayForeCast.Count; i++)
                    {

#line default
#line hidden
            BeginContext(3425, 80, true);
            WriteLiteral("                        <div id=\"forecast-single\">\r\n                            ");
            EndContext();
            BeginContext(3505, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d1f339076bca98d1fcf5364ad39e8b515d9982220855", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3515, "~/img/weather/", 3515, 14, true);
#line 87 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
AddHtmlAttributeValue("", 3529, Model.WeatherPicString(Model.FiveDayForeCast[i].Forecast), 3529, 60, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 3589, ".png", 3589, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3597, 38, true);
            WriteLiteral("\r\n                            <p>High:");
            EndContext();
            BeginContext(3636, 53, false);
#line 88 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                               Write(Model.ConvertTempC(Model.FiveDayForeCast[i].HighTemp));

#line default
#line hidden
            EndContext();
            BeginContext(3689, 42, true);
            WriteLiteral("</p>\r\n                            <p>Low: ");
            EndContext();
            BeginContext(3732, 52, false);
#line 89 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                               Write(Model.ConvertTempC(Model.FiveDayForeCast[i].LowTemp));

#line default
#line hidden
            EndContext();
            BeginContext(3784, 37, true);
            WriteLiteral("</p>\r\n                       </div>\r\n");
            EndContext();
#line 91 "C:\Users\Student\workspace\team6-c-week9-pair-exercises\Park Geek\ParkGeekMVC\Views\Park\Detail.cshtml"
                    }

#line default
#line hidden
            BeginContext(3844, 71, true);
            WriteLiteral("                </div>\r\n           </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ParkViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591