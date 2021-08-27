<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128596644/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T577088)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/T577088.DevExpress.AspNetCore.Reporting/Controllers/HomeController.cs)
* [ReportDesignerModel.cs](./CS/T577088.DevExpress.AspNetCore.Reporting/Models/ReportDesignerModel.cs)
* [WebDocumentViewerModel.cs](./CS/T577088.DevExpress.AspNetCore.Reporting/Models/WebDocumentViewerModel.cs)
* [Program.cs](./CS/T577088.DevExpress.AspNetCore.Reporting/Program.cs)
* [CustomReportResolver.cs](./CS/T577088.DevExpress.AspNetCore.Reporting/Services/CustomReportResolver.cs)
* [CustomReportStorageWebExtension.cs](./CS/T577088.DevExpress.AspNetCore.Reporting/Services/CustomReportStorageWebExtension.cs)
* [CustomWebDocumentViewerOperationLogger.cs](./CS/T577088.DevExpress.AspNetCore.Reporting/Services/CustomWebDocumentViewerOperationLogger.cs)
* **[Startup.cs](./CS/T577088.DevExpress.AspNetCore.Reporting/Startup.cs)**
* [_ViewImports.cshtml](./CS/T577088.DevExpress.AspNetCore.Reporting/Views/_ViewImports.cshtml)
* [ReportDesigner.cshtml](./CS/T577088.DevExpress.AspNetCore.Reporting/Views/Home/ReportDesigner.cshtml)
* [ReportViewer.cshtml](./CS/T577088.DevExpress.AspNetCore.Reporting/Views/Home/ReportViewer.cshtml)
<!-- default file list end -->
# How to use reporting controls in ASP.NET Core applications


<p>This example demonstrates how to use the <a href="https://documentation.devexpress.com/XtraReports/17103/Creating-End-User-Reporting-Applications/Web-Reporting/Report-Designer">End-User Report Designer</a> and <a href="https://documentation.devexpress.com/XtraReports/17738/Creating-End-User-Reporting-Applications/Web-Reporting/Document-Viewer/HTML5-Document-Viewer">HTML5 Document Viewer</a> in an ASP.NET Core application targeting .NET Framework v 4.6.1.<br><br>These controls require the <strong>DevExpress.AspNetCore.Reporting </strong><a href="https://www.nuget.org/">NuGet</a> and <strong>xtrareportsjs </strong><a href="https://bower.io/docs/api/">Bower</a> packages. To integrate these controls into an application, register the required services in the <strong>Startup </strong>class, reference the necessary client resources and use the <strong>ReportDesigner </strong>or <strong>WebDocumentViewer </strong>wrapper.<br><br>This example uses an Entity Framework data source as well as an SQL data source.<br><br>Before running this example, do the following:<br>1. In Visual Studio, right-click the ASP.NET Core application and select <strong>Manage Bower Packages</strong>. In the invoked window, switch to the <strong>Updates </strong>page and update the <strong>xtrareportsjs </strong>package to the required version. This downloads all the required client resources for deploying the control.</p>
<p>2. Right-click the ASP.NET Core application and select <strong>Manage</strong><strong> NuGet Packages</strong>. In the invoked window, switch to the <strong>Updates </strong>page, enable the <strong>Include prerelease</strong> check box and update the <strong>DevExpress.AspNetCore.Reporting </strong>package. <br>You may need to add a new NuGet package source to install DevExpress packages <a href="https://www.devexpress.com/Support/Center/Question/Details/T466415/devexpress-nuget-packages">online</a> or offline from the <strong>C:\Program Files (x86)\DevExpress 17.2\Components\System\Components\packages</strong><em> </em>path.<br><br></p>
<p>For step-by-step instructions, refer to the following documentation topic: <a href="https://documentation.devexpress.com/XtraReports/119717/Creating-End-User-Reporting-Applications/Web-Reporting/Web-Reporting-Overview/ASP-NET-Core-Reporting-NET-Framework">ASP.NET Core Reporting (.NET Framework)</a>.</p>

<br/>


