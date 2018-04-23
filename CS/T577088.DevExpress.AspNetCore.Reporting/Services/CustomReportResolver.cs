using System;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Microsoft.AspNetCore.Hosting;
using T577088.DevExpress.AspNetCore.Reporting.Models.Northwind;

namespace T577088.DevExpress.AspNetCore.Reporting.Services
{
    public class CustomReportResolver : IWebDocumentViewerReportResolver
    {
        NorthwindContext dbContext;
        IHostingEnvironment hostingEnvironment;
        public CustomReportResolver(NorthwindContext dbContext, IHostingEnvironment hostingEnvironment) {
            this.dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }
        public XtraReport Resolve(string reportEntry) {
            if (reportEntry == "CategoriesTyped") {
                var report = new Reports.CategoriesReportSqlDS();
                report.SqlDataSource1.ConnectionName = "localdb_nwind_connection";
                return report;
            }
            if(reportEntry == "CategoriesEF") {
                var reportRepxFilePath = System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Reports", "CategoriesReport.repx");
                var report = XtraReport.FromFile(reportRepxFilePath, true);
                return report;
            }
            throw new ArgumentException("reportEntry");
        }
    }
}
