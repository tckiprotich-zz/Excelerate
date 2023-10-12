global using Excelerate.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excelerate.Domain
{
    public class NewMessageResponse : BaseDomainEntity
    {
        public string? TargetTitle { get; set; }
        public string? TargetCompany { get; set; }
        public string? Intro { get; set; }
        public string? Message { get; set; }
    }
}