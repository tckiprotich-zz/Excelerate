using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Connect.Contracts.Models
{
    /// <summary>
    /// Represents the response model for the API.
    /// </summary>
    public class ResponseModel : BaseModel
    {        
        /// <summary>
        /// Gets or sets the title of the target.
        /// </summary>
        public string TargetTitle { get; set; } = string.Empty;        
        
        /// <summary>
        /// Gets or sets the company of the target.
        /// </summary>
        public string TargetCompany { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the message of the response.
        /// </summary>
        public string Message { get; set; } = string.Empty;       
        
    }
}