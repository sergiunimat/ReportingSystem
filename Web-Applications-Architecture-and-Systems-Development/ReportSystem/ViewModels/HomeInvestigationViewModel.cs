using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSystem.ViewModels
{
    public class HomeInvestigationViewModel
    {
        //public string InvestigationTitle { get; set; }
        public int InvestigationId { get; set; }
        public string ReportTitle { get; set; }
        public int ReportId { get; set; }
        public string InvestigationDescription { get; set; }
        public string InvestigatorId { get; set; }
        public string InvestigatorName { get; set; }
        public string ReporterId { get; set; }
        public string ReporterName { get; set; }
        public string StatusText { get; set; }
        public int StatusId { get; set; }
        public string CurrentUserId { get; set; }

    }
}
