global using System.ComponentModel.DataAnnotations;

namespace Career_Connect.Contracts.Models
{
    /// <summary>
    /// Represents a network model that contains information about a target person or company.
    /// </summary>
    public class NetworkModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the title of the target person or company.
        /// </summary>
        [Required]
        public string TargetTitle { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the target company.
        /// </summary>
        [Required]
        public string TargetCompany { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the introduction message for the target person or company.
        /// </summary>
        public string Intro { get; set; } = string.Empty;
    }
}