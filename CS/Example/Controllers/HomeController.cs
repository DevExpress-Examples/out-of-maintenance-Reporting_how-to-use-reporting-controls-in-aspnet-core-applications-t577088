using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Designer() {
            Models.ReportDesignerModel model = new Models.ReportDesignerModel();
            return View(model);
        }

        public IActionResult Viewer() {
            return View();
        }
    }
}