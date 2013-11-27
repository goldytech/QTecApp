namespace QTec.Hrms.Web.ActionFilters
{
    using System;
    using System.Net.Http.Headers;
    using System.Web.Http.Filters;

    /// <summary>
    /// The cache attribute.
    /// </summary>
    public class CacheAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Gets or sets the cache expiry duration.
        /// </summary>
        public double CacheExpiryDuration
        {
            get;
            set;
        }

        /// <summary>
        /// The on action executed.
        /// </summary>
        /// <param name="actionExecutedContext">
        /// The action executed context.
        /// </param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (this.CacheExpiryDuration > 0)
            {
                //// adding the cache control in response header
                actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
                {
                    MaxAge = TimeSpan.FromSeconds(this.CacheExpiryDuration),
                    MustRevalidate = true,
                    Private = true
                };
            }
        }
    }
}