// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Language.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the language table
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Hrms.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents the language table
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get;
            set;
        }
    }
}
