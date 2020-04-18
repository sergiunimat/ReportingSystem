using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSystem.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public String ReportTitle { get; set; }
        public string ReportDescription { get; set; }
        public string ReportPicturePath { get; set; }
        public ApplicationUser ReportReporter { get; set; }
        public ApplicationUser ReportInvestigator { get; set; }
        public Investigation Investigation { get; set; }
    }
}
