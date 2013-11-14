namespace QTec.Hrms.Web.WebApi
{
   
    using System.Web.Http;

    using QTec.Hrms.Business.Contracts;

    /// <summary>
    /// The language controller.
    /// </summary>
    [RoutePrefix("api/languages")]
    public class LanguageController : ApiController
    {
        /// <summary>
        /// The language manager.
        /// </summary>
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
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [Route("")]
        public IHttpActionResult Get()
        {
            var languages = this.languageManager.GetLanguages();

            return this.Ok(languages);
        }
    }
}
