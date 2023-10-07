using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Connect.Contracts.Models
{
    public class UserModel
    {
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Public_Name { get; set; } = string.Empty; 
        public string Phone { get; set; } = string.Empty;
        
    }
}