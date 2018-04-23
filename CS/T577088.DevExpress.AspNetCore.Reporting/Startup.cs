using System;
using System.IO;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.Utils;
using DevExpress.XtraReports.Security;
using DevExpress.XtraReports.Web.Extensions;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using T577088.DevExpress.AspNetCore.Reporting.Models.Northwind;
using T577088.DevExpress.AspNetCore.Reporting.Services;

namespace T577088.DevExpress.AspNetCore.Reporting {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().AddDefaultReportingControllers();
            services.AddDevExpressControls();

            services.ConfigureReportingServices(configurator => {
                configurator.ConfigureReportDesigner(designerConfigurator => {
                    designerConfigurator.RegisterDataSourceWizardConfigFileConnectionStringsProvider();
                });
            });
            services.AddScoped<IWebDocumentViewerReportResolver, CustomReportResolver>();
            services.AddScoped<WebDocumentViewerOperationLogger, CustomWebDocumentViewerOperationLogger>();

            services
               .AddLogging()
               .AddDbContext<NorthwindContext>(ConfigureNorthwindContext);
            services.AddEntityFrameworkSqlServer();
        }

        static void ConfigureNorthwindContext(IServiceProvider serviceProvider, DbContextOptionsBuilder options) {
            var hosting = serviceProvider.GetRequiredService<IHostingEnvironment>();
            var dbPath = Path.Combine(hosting.ContentRootPath, "NWind.mdf");
            var connectionString = $@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFileName={dbPath};Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework";
            options.UseSqlServer(connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            System.AppDomain.CurrentDomain.SetData("DataDirectory", env.ContentRootPath);
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseDevExpressControls();
            var reportStorageFileDirectoryPath = System.IO.Path.Combine(env.ContentRootPath, "Reports");
            ReportStorageWebExtension.RegisterExtensionGlobal(new CustomReportStorageWebExtension(reportStorageFileDirectoryPath));

            ScriptPermissionManager.GlobalInstance = new ScriptPermissionManager(ExecutionMode.Deny);
            UrlAccessSecurityLevelSetting.SafeSetSecurityLevel(UrlAccessSecurityLevel.WebUrlsOnly);
        }
    }
}
