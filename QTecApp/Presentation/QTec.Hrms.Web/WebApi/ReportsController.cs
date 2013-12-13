namespace QTec.Hrms.Web.WebApi
{
    using System.Web;
    using System.Web.Http;

    using Telerik.Reporting.Cache.Interfaces;
    using Telerik.Reporting.Services.Engine;
    using Telerik.Reporting.Services.WebApi;

    
    public class ReportsController : ReportsControllerBase
    {

        protected override IReportResolver CreateReportResolver()
        {

            var reportsPath = HttpContext.Current.Server.MapPath("~/Reports");

            return new ReportTypeResolver()
             .AddFallbackResolver(new ReportFileResolver(reportsPath));

        }
        protected override ICache CreateCache()
        {
            return CacheFactory.CreateFileCache();
        }

    }
}
