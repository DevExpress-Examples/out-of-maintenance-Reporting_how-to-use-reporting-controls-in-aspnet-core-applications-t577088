using System.Diagnostics;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.EntityFramework;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Mvc;
using T577088.DevExpress.AspNetCore.Reporting.Models;
using T577088.DevExpress.AspNetCore.Reporting.Models.Northwind;

namespace T577088.DevExpress.AspNetCore.Reporting.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        public object CreateSqlNorthwindDataSource() {
            SqlDataSource northwindDataSource = new SqlDataSource("localdb_nwind_connection") { Name = "Northwind" };
            SelectQuery categories = new SelectQuery("Categories");
            categories.AddTable("Categories");
            categories.SelectAll();

            SelectQuery products = new SelectQuery("Products");
            products.AddTable("Products");
            products.SelectAll();

            northwindDataSource.Queries.AddRange(new SqlQuery[] { categories, products });
            northwindDataSource.RebuildResultSchema();
            return northwindDataSource;
        }

        public IActionResult ReportDesigner() {
            ViewData["Message"] = "DevExpress Reporting. Report Designer Control.";

            var report = new XtraReport();
            var connectionParameters = new EFConnectionParameters(typeof(NorthwindContext));
            report.DataSource = new EFDataSource(connectionParameters) { Name = "NorthwindEFDataSource" };
            report.DataMember = nameof(NorthwindContext.Categories);

            var msSqlConnectionParameters = new MsSqlConnectionParameters("localhost", "database", "user", "password", MsSqlAuthorizationType.SqlServer);
            var sqlServerDataSource = new SqlDataSource(msSqlConnectionParameters);
            var northwindDataSource = CreateSqlNorthwindDataSource();

            var model = new ReportDesignerModel {
                Report = report
            };
            model.DataSources.Add("SqlServerDataSource", sqlServerDataSource);
            model.DataSources.Add("LocalDbNorthwindDataSource", northwindDataSource);
            return View(model);
        }

        public IActionResult ReportViewer() {
            ViewData["Message"] = "DevExpress Reporting. Web Document Viewer Control.";
            var report = new Reports.CategoriesReportSqlDS();
            report.SqlDataSource1.ConnectionName = "localdb_nwind_connection";
            var model = new WebDocumentViewerModel {
                Report = report
            };
            return View(model);
        }

        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
