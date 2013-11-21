namespace QTec.Hrms.Models.Dto
{
    using System.Collections.Generic;

    /// <summary>
    ///   Represents the employee viewmodel
    /// </summary>
    public class EmployeeInfo
    {
        /// <summary>
        /// Gets or sets the employee personal info.
        /// </summary>
        public EmployeePersonalInfo EmployeePersonalInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the employee languages.
        /// </summary>
        public List<EmployeeLanguageInfo> EmployeeLanguages
        {
            get;
            set;
        }
    }
}