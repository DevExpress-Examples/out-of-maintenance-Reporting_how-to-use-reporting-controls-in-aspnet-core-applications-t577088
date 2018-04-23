using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T577088.DevExpress.AspNetCore.Reporting.Models
{
    public class ReportDesignerModel
    {
        public XtraReport Report { get; set; }
        public string ReportUrl { get; set; }
        public Dictionary<string, object> DataSources { get; set; }
        public ReportDesignerModel()
        {
            DataSources = new Dictionary<string, object>();
        }
    }
}
