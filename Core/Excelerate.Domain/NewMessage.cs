using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excelerate.Domain
{
    public class NewMessage : BaseDomainEntity
    {
        public string TargetTitle { get; set; }
        public string TargetCompany { get; set; }
        public string Intro { get; set; }
    }
}