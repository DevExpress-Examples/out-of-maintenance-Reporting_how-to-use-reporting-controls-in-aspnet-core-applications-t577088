using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.DataAccess.EntityFramework;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using T577088.DevExpress.AspNetCore.Reporting.Models.Northwind;

namespace T577088.DevExpress.AspNetCore.Reporting.Services {
    public class CustomWebDocumentViewerOperationLogger : WebDocumentViewerOperationLogger {
        NorthwindContext nwindDbContext;
        public CustomWebDocumentViewerOperationLogger(NorthwindContext nwindDbContext) {
            this.nwindDbContext = nwindDbContext;
        }
        public override Action BuildStarting(string reportId, string reportUrl, XtraReport report, ReportBuildProperties buildProperties) {
            if(report.DataSource != null && report.DataSource is EFDataSource && ((EFDataSource)report.DataSource).Name == "NorthwindEFDataSource") {
                report.DataSource = GetData(nwindDbContext, report.DataMember, report.FilterString);
                report.FilterString = "";
            }
            return base.BuildStarting(reportId, reportUrl, report, buildProperties);
        }

        object GetData(NorthwindContext context, string dataMember, string filterString) {
            if(dataMember == nameof(NorthwindContext.Categories)) {
                return new { Categories = context.Categories.ToList() };
            }
            if(dataMember == nameof(NorthwindContext.Customers)) {
                return new { Customers = context.Customers.ToList() };
            }
            if(dataMember == nameof(NorthwindContext.Employees)) {
                return new { Employees = context.Employees.ToList() };
            }
            if(dataMember == nameof(NorthwindContext.Orders)) {
                return new { Orders = context.Orders.ToList() };
            }
            if(dataMember == nameof(NorthwindContext.Order_Details)) {
                return new { Order_Details = context.Order_Details.ToList() };
            }
            if(dataMember == nameof(NorthwindContext.Products)) {
                return new { Products = context.Products.ToList() };
            }
            if(dataMember == nameof(NorthwindContext.Shippers)) {
                return new { Shippers = context.Shippers.ToList() };
            }
            if(dataMember == nameof(NorthwindContext.Suppliers)) {
                return new { Suppliers = context.Suppliers.ToList() };
            }
            throw new ArgumentException("Please specify a valid data member.");
        }

        object FilterCategory(NorthwindContext context, string filterString) {
            CriteriaOperator criteriaOperator = CriteriaOperator.Parse(filterString, out OperandValue[] p);

            CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
            var categories = context.Categories.AppendWhere(converter, criteriaOperator) as IQueryable<Category>;

            return new { Categories = categories.ToList() };
        }
    }
}
