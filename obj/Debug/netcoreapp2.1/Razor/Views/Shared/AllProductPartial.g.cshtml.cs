#pragma checksum "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\ProductsAndCategories\Views\Shared\AllProductPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d1d05c87c68cd0299237ba9ecf28dc16ccc0de4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_AllProductPartial), @"mvc.1.0.view", @"/Views/Shared/AllProductPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/AllProductPartial.cshtml", typeof(AspNetCore.Views_Shared_AllProductPartial))]
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
#line 1 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\ProductsAndCategories\Views\_ViewImports.cshtml"
using ProductsAndCategories;

#line default
#line hidden
#line 2 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\ProductsAndCategories\Views\_ViewImports.cshtml"
using ProductsAndCategories.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d1d05c87c68cd0299237ba9ecf28dc16ccc0de4", @"/Views/Shared/AllProductPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3772dd1aab0a113eef9daa4fd8f7fdb8a407ef7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_AllProductPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NewProductForm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(23, 54, true);
            WriteLiteral("\r\n<h1 class=\"text-center\">Existed Products!</h1>\r\n\r\n\r\n");
            EndContext();
#line 6 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\ProductsAndCategories\Views\Shared\AllProductPartial.cshtml"
     foreach (var product in Model.CurrentProducts)
        {

#line default
#line hidden
            BeginContext(141, 18, true);
            WriteLiteral("            <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 159, "\"", 194, 2);
            WriteAttributeValue("", 166, "/products/", 166, 10, true);
#line 8 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\ProductsAndCategories\Views\Shared\AllProductPartial.cshtml"
WriteAttributeValue("", 176, product.ProductId, 176, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(195, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(197, 12, false);
#line 8 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\ProductsAndCategories\Views\Shared\AllProductPartial.cshtml"
                                                  Write(product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(209, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 9 "C:\Users\Lili\Desktop\Coding Dojo\CSharp\MVC\ProductsAndCategories\Views\Shared\AllProductPartial.cshtml"
        }

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NewProductForm> Html { get; private set; }
    }
}
#pragma warning restore 1591
