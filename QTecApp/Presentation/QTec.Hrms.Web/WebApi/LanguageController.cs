namespace QTec.Hrms.Web.WebApi
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using QTec.Hrms.Business.Contracts;

    /// <summary>
    /// The language controller.
    /// </summary>
    public class LanguageController : ApiController
    {
        private readonly ILanguageManager languageManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageController"/> class.
        /// </summary>
        /// <param name="languageManager">
        /// The language manager.
        /// </param>
        public LanguageController(ILanguageManager languageManager)
        {
            this.languageManager = languageManager;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        public HttpResponseMessage Get()
        {
            var languages = this.languageManager.GetLanguages();

            return Request.CreateResponse(HttpStatusCode.OK, languages); //TODO add the error handlers
        }
    }
}
