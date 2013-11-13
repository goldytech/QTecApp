namespace QTec.Hrms.Business.Masters
{
    using System.Collections.Generic;
    using System.Linq;

    using QTec.Hrms.Business.Contracts;
    using QTec.Hrms.DataTier.Contracts;
    using QTec.Hrms.Models;

    /// <summary>
    /// The language manager.
    /// </summary>
    public class LanguageManager : ILanguageManager
    {
        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly IQTecUnitOfWork qTecUnitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageManager"/> class.
        /// </summary>
        /// <param name="qTecUnitOfWork">
        /// The q tec unit of work.
        /// </param>
        public LanguageManager(IQTecUnitOfWork qTecUnitOfWork)
        {
            this.qTecUnitOfWork = qTecUnitOfWork;
        }

        /// <summary>
        /// The get languages.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<Language> GetLanguages()
        {
            return this.qTecUnitOfWork.LanguageRepository.GetAll().ToList();
        }
    }
}