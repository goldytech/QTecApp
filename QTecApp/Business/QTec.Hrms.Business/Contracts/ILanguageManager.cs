namespace QTec.Hrms.Business.Contracts
{
    using System.Collections.Generic;

    using QTec.Hrms.Models;

    /// <summary>
    /// The LanguageManager interface.
    /// </summary>
    public interface ILanguageManager
    {
        /// <summary>
        /// The get languages.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<Language> GetLanguages();
    }
}
