using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.Extensions;

namespace T577088.DevExpress.AspNetCore.Reporting.Services {
    public class CustomReportStorageWebExtension : ReportStorageWebExtension {
        readonly string reportDirectoryPath;
        public CustomReportStorageWebExtension(string reportDirectoryPath) {
            this.reportDirectoryPath = reportDirectoryPath;
        }
        public override bool IsValidUrl(string url) {
            return true;
        }

        public override string SetNewData(XtraReport report, string defaultUrl) {
            if(!defaultUrl.Contains(".repx"))
                defaultUrl += ".repx";

            SetData(report, defaultUrl);
            return defaultUrl;
        }

        public override byte[] GetData(string url) {
            using(var fileStream = File.OpenRead(Path.Combine(reportDirectoryPath, url)))
            using(var stream = new MemoryStream()) {
                var report = XtraReport.FromStream(fileStream, true);
                report.SaveLayoutToXml(stream);
                stream.Position = 0;
                return stream.GetBuffer();
            }
        }

        public override Dictionary<string, string> GetUrls() {
            var dictionary = new Dictionary<string, string>();
            var files = Directory.GetFiles(reportDirectoryPath);
            foreach(var item in files.Where(x => x.Contains(".repx")).Select(x => x.Split('\\').Last())) {
                dictionary.Add(item, item);
            }
            return dictionary;
        }

        public override void SetData(XtraReport report, string url) {
            using(var fileStream = File.OpenWrite(Path.Combine(reportDirectoryPath, url))) {
                report.SaveLayoutToXml(fileStream);
            }
        }

        public override bool CanSetData(string url) {
            return true;
        }
    }
}
