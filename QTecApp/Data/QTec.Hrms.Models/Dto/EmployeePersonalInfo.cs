namespace QTec.Hrms.Models.Dto
{
    using System;

    /// <summary>
    /// The employee personal info.
    /// </summary>
    public class EmployeePersonalInfo
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int EmployeeId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
       public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
       public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the designation id.
        /// </summary>
        public int DesignationId
        {
            get;
            set;
        }

       /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        public double Salary
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
       public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
       public string Gender
        {
            get;
            set;
        }

    }
}
