using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T577088.DevExpress.AspNetCore.Reporting.Models
{
    public class WebDocumentViewerModel
    {
        public string ReportUrl { get; set; }
        public XtraReport Report { get; set; }
    }
}
