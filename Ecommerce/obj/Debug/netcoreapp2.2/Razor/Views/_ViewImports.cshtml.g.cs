#pragma checksum "C:\Estudo\Ecommerce\MyEcommerce\Ecommerce\Views\_ViewImports.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8aecd047b2b5bba63f69e591be27c20d2c77fde7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views__ViewImports), @"mvc.1.0.view", @"/Views/_ViewImports.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/_ViewImports.cshtml", typeof(AspNetCore.Views__ViewImports))]
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
#line 2 "C:\Estudo\Ecommerce\MyEcommerce\Ecommerce\Views\_ViewImports.cshtml"
using Ecommerce.Models;

#line default
#line hidden
#line 3 "C:\Estudo\Ecommerce\MyEcommerce\Ecommerce\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#line 4 "C:\Estudo\Ecommerce\MyEcommerce\Ecommerce\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8aecd047b2b5bba63f69e591be27c20d2c77fde7", @"/Views/_ViewImports.cshtml")]
    public class Views__ViewImports : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(107, 42, true);
            WriteLiteral(" //import this so we get our HTML Helper\r\n");
            EndContext();
            BeginContext(168, 96, true);
            WriteLiteral(" //import this so we can cast our list to IPagedList (only necessary because ViewBag is dynamic)");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
