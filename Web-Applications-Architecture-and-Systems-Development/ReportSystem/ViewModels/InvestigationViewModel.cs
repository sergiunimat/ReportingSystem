using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ReportSystem.ViewModels
{
    public class InvestigationViewModel
    {
        public int ReportId { get; set; }
        public int InvestigationId { get; set; }
        public string ReportTitle { get; set; }
        public string InvestigatorId { get; set; }
        public string InvestigationTitle { get; set; }
        public int InvestigationStatus { get; set; }
        public string InvestigatorName { get; set; }
        public string InvestigatorEmail { get; set; }
        [Required]
        public string InvestigationDescription { get; set; }

    }
}
