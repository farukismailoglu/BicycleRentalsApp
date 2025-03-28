#pragma checksum "C:\Users\Faruk\source\repos\BicycleRentalsApp\WebApp\Views\Home\BicycleRentals.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf9b65d92fd99ccba88d4b1b3d431a54fe864d26"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_BicycleRentals), @"mvc.1.0.view", @"/Views/Home/BicycleRentals.cshtml")]
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
#line 1 "C:\Users\Faruk\source\repos\BicycleRentalsApp\WebApp\Views\_ViewImports.cshtml"
using BicyleRentalsApp.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf9b65d92fd99ccba88d4b1b3d431a54fe864d26", @"/Views/Home/BicycleRentals.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d717f3edd0054a7066465255a774c9c789822ca9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_BicycleRentals : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Faruk\source\repos\BicycleRentalsApp\WebApp\Views\Home\BicycleRentals.cshtml"
  
    ViewData["Title"] = "BicycleRentals";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"" integrity=""sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u"" crossorigin=""anonymous"">
<link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css"" integrity=""sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp"" crossorigin=""anonymous"">
<script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"" integrity=""sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa"" crossorigin=""anonymous""></script>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
<script>
    $(document).ready(function () {

        $.getJSON('");
#nullable restore
#line 14 "C:\Users\Faruk\source\repos\BicycleRentalsApp\WebApp\Views\Home\BicycleRentals.cshtml"
              Write(Url.Action("GetAllCountry", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', function (data) {

			        var items = '<option value="""" selected>--Seçiniz--</option>';
			        $.each(data, function(index, item) {

                        items += ""<option value='"" + item.id + ""'>"" + item.country + ""</option>"";


                    });
            //console.log(items);
            $('#country').html(items);
        });

        $('#country').change(function () {
            $.getJSON('");
#nullable restore
#line 28 "C:\Users\Faruk\source\repos\BicycleRentalsApp\WebApp\Views\Home\BicycleRentals.cshtml"
                  Write(Url.Action("GetCityById", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', { Id: $(this).val() }, function (data) {

                var items = '<option value="""" selected>--Seçiniz--</option>';
                $.each(data, function (index, item) {

                    items += ""<option value='"" + item.id + ""'>"" + item.city + ""</option>"";

                });
                $('#city').html(items);
            });
        });

        $('#city').change(function () {
            $.getJSON('");
#nullable restore
#line 41 "C:\Users\Faruk\source\repos\BicycleRentalsApp\WebApp\Views\Home\BicycleRentals.cshtml"
                  Write(Url.Action("GetStationsByLocationId", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', { Id: $(this).val() }, function (data) {

                var items;

                $.each(data, function (index, item) {
                    console.log(item);
                    items += '<tr><th scope=""row"">' + item.id + '</th><th>' + item.name + '</th><th>' + item.freeBikes + '</th><th>' + item.emptySlots + '</th><th> <button type=""button"" class=""btn btn-info"" id='+item.id+'>Select</button></th></tr>';

                });
                $('#tbl').html(items);
            });
        });
    });
</script>
<h1>BicycleRentals</h1>

<div>
    <h4 class=""text-center"">Country</h4>
    <div class=""clearfix center-block"" style=""margin-left: 40px""></div>
    <select class=""form-control auditorSelect"" id=""country"" name=""country"" style=""width:100%"">
    </select>
    <h4 class=""text-center"">City</h4>
    <div class=""clearfix center-block"" style=""margin-left: 40px""></div>
    <select class=""form-control auditorSelect"" id=""city"" name=""city"" style=""width:100%"">
    </select>
    <hr />");
            WriteLiteral(@"
    <table class=""table table-bordered"">
        <thead>
            <tr>
                <th scope=""col"">ID</th>
                <th scope=""col"">Name</th>
                <th scope=""col"">Free Bikes</th>
                <th scope=""col"">Empty Slots</th>
                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody class=""tbl"" id=""tbl"">

        </tbody>
    </table>


</div>");
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
