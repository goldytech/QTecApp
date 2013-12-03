namespace QTec.Hrms.Models.Dto
{
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

    /// <summary>
    ///  Represents Employee Language ViewModel
    /// </summary>
    public class EmployeeLanguageInfo
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        /// <value>The employee id.</value>
        public int EmployeeId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the language id.
        /// </summary>
        /// <value>The language id.</value>
        public int LanguageId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the language.
        /// </summary>
        /// <value>The name of the language.</value>
        public string LanguageName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fluency.
        /// </summary>
        /// <value>The fluency.</value>
        [EnumConversionValidator(typeof(Fluency), MessageTemplate = "Fluency must be value from '{3}' enumeration")]
        public Fluency Fluency
        {
            get;
            set;
        }
    }
}
