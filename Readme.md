<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128596644/18.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T577088)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to use reporting controls in ASP.NET Core applications


This example demonstrates how to use the <a href="https://docs.devexpress.com/XtraReports/400249/create-end-user-reporting-applications/web-reporting/asp-net-core-reporting/end-user-report-designer">End-User Report Designer</a> and <a href="https://docs.devexpress.com/XtraReports/400248/create-end-user-reporting-applications/web-reporting/asp-net-core-reporting/document-viewer">HTML5 Document Viewer</a> in an ASP.NET Core application that targets both .NET Standard and .NET Framework.


These are the main steps to integrate these controls into an application:

1. Install the **DevExpress.AspNetCore.Reporting** <a href="https://www.nuget.org/">NuGet</a> package.

2. Install **devexpress-reporting** <a href="https://www.npmjs.com/package/devexpress-reporting">npm</a> package.

3. Register reporting services in the **Startup** class.

4. Reference all the required client resources in the View file.

5. Use the <a href="https://docs.devexpress.com/XtraReports/DevExpress.AspNetCore.BuilderFactoryExtensions.ReportDesigner.overloads">ReportDesigner</a> and <a href="https://docs.devexpress.com/XtraReports/DevExpress.AspNetCore.BuilderFactoryExtensions.WebDocumentViewer.overloads">WebDocumentViewer </a> wrappers to display reporting controls on your web pages.


Before running this example, do the following:

1. In Visual Studio, right-click the **package.json** file and select **Restore Packages**. This adds the node_modules folder to the application project.

2. Right-click the ASP.NET Core application and select **Manage NuGet Packages**. In the invoked window, switch to the **Updates** page and update the **DevExpress.AspNetCore.Reporting** package. You may need to add a new NuGet package source to install DevExpress packages <a href="https://www.devexpress.com/Support/Center/Question/Details/T466415/devexpress-nuget-packages">online</a> or offline from the **C:\Program Files (x86)\DevExpress 18.2\Components\System\Components\packages</strong><em> </em>path.**


For more information and step-by-step tutorials, refer to the following documentation topic: <a href="https://docs.devexpress.com/XtraReports/119717/create-end-user-reporting-applications/web-reporting/asp.net-core-reporting">ASP.NET Core Reporting</a>.

