namespace QTec.Hrms.Web.ActionFilters
{
    #region Usings
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters; 
    #endregion

    /// <summary>
    /// The e tag attribute.
    /// </summary>
    public class ETagAttribute : ActionFilterAttribute
    {
        #region Declarations
        /// <summary>
        /// The entity tags concurrent dictionary.
        /// </summary>
        private static ConcurrentDictionary<string, EntityTagHeaderValue> etags = new ConcurrentDictionary<string, EntityTagHeaderValue>(); 
        #endregion

        #region Overridden Methods
        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void OnActionExecuting(HttpActionContext context)
        {
            var request = context.Request;

            if (request.Method == HttpMethod.Get)
            {
                var key = GetKey(request);

                ICollection<EntityTagHeaderValue> etagsFromClient = request.Headers.IfNoneMatch;

                if (etagsFromClient.Count > 0)
                {
                    EntityTagHeaderValue etag = null;
                    if (etags.TryGetValue(key, out etag) && etagsFromClient.Any(t => t.Tag == etag.Tag))
                    {
                        //// Etag found in dictionary so just returned the cached response
                        context.Response = new HttpResponseMessage(HttpStatusCode.NotModified);
                    }
                }
            }
        }

        /// <summary>
        /// The on action executed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            var request = context.Request;
            var key = GetKey(request);

            EntityTagHeaderValue etag = null;

            bool isGet = request.Method == HttpMethod.Get;
            bool isPutOrPost = request.Method == HttpMethod.Put || request.Method == HttpMethod.Post;


            if (isPutOrPost)
            {
                ////empty the dictionary because the resource has been changed.So now all tags will be cleared and data 
                //// will be fetched from server. It would be good to implement a logic in which only change the ETags 
                //// of that urls which are affected by this post or put method rather than clearing entire dictionary
                     etags.Clear();
                //// generate new ETag for Put or Post because the resource is changed.
                    etag = new EntityTagHeaderValue("\"" + Guid.NewGuid().ToString() + "\"");
                    etags.AddOrUpdate(key, etag, (k, val) => etag);


            }
            //if ((isGet && !etags.TryGetValue(key, out etag)) || isPutOrPost)
            //{
            //    //// generate new ETag for Put or Post because the resource is changed.
            //    etag = new EntityTagHeaderValue("\"" + Guid.NewGuid().ToString() + "\"");
            //    etags.AddOrUpdate(key, etag, (k, val) => etag);
            //}

            if (isGet)
            {
                context.Response.Headers.ETag = etag;
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// The get key.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetKey(HttpRequestMessage request)
        {
            return request.RequestUri.ToString();
        } 
        #endregion
    }
}