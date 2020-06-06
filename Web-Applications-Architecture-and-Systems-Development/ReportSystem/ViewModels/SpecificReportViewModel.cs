using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ReportSystem.Models;

namespace ReportSystem.ViewModels
{
    public class SpecificReportViewModel
    {
        public int ReportId { get; set; }
        public String ReportTitle { get; set; }
        public string ReportDescription { get; set; }
        public double ReportLatitude { get; set; }
        public double ReportLongitude { get; set; }
        public List<Hazard> Hazards { get; set; }
        public string HazardTitle { get; set; }
        public string PicturePath { get; set; }
        public DateTime ReportRegisterTime { get; set; }
        public List<CommentViewModel> ReportCommentList { get; set; }
        public string CommentText { get; set; }
        public string CurrentUserId { get; set; }
        public string ReporterName { get; set; }
        public string ReporterId { get; set; }
        public string InvestigatorId { get; set; }
        public string InvestigatorName { get; set; }
        public bool Status { get; set; }

    }
}
