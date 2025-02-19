#pragma checksum "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6405893d1bc05ec0c8a34834c0ff10d3adb033b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\_ViewImports.cshtml"
using ControleDeGastos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\_ViewImports.cshtml"
using ControleDeGastos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6405893d1bc05ec0c8a34834c0ff10d3adb033b4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a58a80135b0adb3d3efdc195df33e3b5150c18e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ControleDeGastos.Models.Conta>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3>Contas do mês de Abril</h3>\r\n\r\n");
#nullable restore
#line 8 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\Home\Index.cshtml"
 foreach (var usuarioGroup in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"panel panel-primary\">\r\n        <div class=\"panel-heading\">\r\n            <h3 class=\"panel-title\">Department ");
#nullable restore
#line 12 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\Home\Index.cshtml"
                                          Write(usuarioGroup.Usuario.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(@", Total sales</h3>
        </div>
        <div class=""panel-body"">
            <table class=""table table-striped table-hover"">
                <thead>
                    <tr class=""success"">
                        <th>
                            Date
                        </th>
                        <th>
                            Amount
                        </th>
                        <th>
                            Seller
                        </th>
                        <th>
                            Status
                        </th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>
");
#nullable restore
#line 37 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table table-hover\">\r\n    <thead>\r\n        <tr class=\"table-primary\">\r\n            <th>\r\n                Morador\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 45 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 50 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Usuario.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 60 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n        <tr>\r\n            <td colspan=\"8\">\r\n                <p><span style=\"font-size: 18px\"><b>Total: ");
#nullable restore
#line 65 "C:\temp\ControleDeGastos\SistemaControleDeGastos\ControleDeGastos\Views\Home\Index.cshtml"
                                                      Write(Model.Sum(obj => obj.Valor).ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></span></p>\r\n            </td>\r\n        </tr>\r\n    </tfoot>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ControleDeGastos.Models.Conta>> Html { get; private set; }
    }
}
#pragma warning restore 1591
