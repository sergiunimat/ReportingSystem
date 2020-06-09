using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ReportSystem.Models;

namespace ReportSystem.ViewModels
{
    public class EditUserViewModel
    {
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
        public bool InvestigatorRole { get; set; }
        public bool AdminRole { get; set; }
        public bool ReporterRole { get; set; }

        
    }
}
