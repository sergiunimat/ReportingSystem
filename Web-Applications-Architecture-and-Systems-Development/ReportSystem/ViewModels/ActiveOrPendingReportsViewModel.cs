using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSystem.ViewModels
{
    public class ActiveOrPendingReportsViewModel
    {
        public List<SpecificReportViewModel> UnderInvestigationReports { get; set; }
        public List<SpecificReportViewModel> PendingReports { get; set; }
    }
}
