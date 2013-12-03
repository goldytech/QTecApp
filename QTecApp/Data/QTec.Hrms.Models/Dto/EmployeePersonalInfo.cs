namespace QTec.Hrms.Models.Dto
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

    /// <summary>
    /// The employee personal info.
    /// </summary>
    [HasSelfValidation]
    public class EmployeePersonalInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeePersonalInfo"/> class.
        /// </summary>
        public EmployeePersonalInfo()
        {
            this.Errors = new List<string>();
        }

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
        [NotNullValidator(MessageTemplate = "Employee first name is required")]
        [StringLengthValidator(5, RangeBoundaryType.Inclusive, 50, RangeBoundaryType.Inclusive,
            MessageTemplate = "First name must be at least {3} characters")]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [NotNullValidator(MessageTemplate = "Employee last name is required")]
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
        [RelativeDateTimeValidator(-120, DateTimeUnit.Year, -18, DateTimeUnit.Year, MessageTemplate = "Employee must be atleast 18 years to work")]
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

        /// <summary>
        /// Checks whether given instance is valid or not
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsValid()
        {
            var employeePersonalInfoValidator = ValidationFactory.CreateValidator<EmployeePersonalInfo>();

            var validationResults = employeePersonalInfoValidator.Validate(this);

            if (validationResults.Count > 0)
            {
                foreach (var validationResult in validationResults)
                {
                    this.Errors.Add(validationResult.Message);
                }
            }

            return validationResults.Count <= 0;
        }

        public IList<string> Errors
        {
            get; 
            private set;
        }

        /// <summary>
        /// The validate software trainee salary.
        /// </summary>
        /// <param name="validationResults">
        /// The validation results.
        /// </param>
        [SelfValidation]
        public void ValidateSoftwareTraineeSalary(ValidationResults validationResults)
        {
            if (this.DesignationId.Equals(1) && this.Salary < 50000)
            {
                validationResults.AddResult(
                    new ValidationResult("Software trainee salary should be more than 50000", this, "SalaryValidation", string.Empty, null));
            }
        }
    }
}