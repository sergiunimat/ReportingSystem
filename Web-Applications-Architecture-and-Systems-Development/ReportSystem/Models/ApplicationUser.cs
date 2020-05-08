using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ReportSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserAddress { get; set; }
        public int UserCredit { get; set; }
        
        [InverseProperty("ReportReporter")]
        public virtual List<Report> Reporter { get; set; }
        [InverseProperty("ReportInvestigator")]
        public virtual List<Report> Investigator { get; set; }
    }
}
