using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ReportSystem.Models;

namespace ReportSystem.ViewModels
{
    public class ReportViewModel
    {

        public int ReportId { get; set; }
        public String ReportTitle { get; set; }
        public string ReportDescription { get; set; }
        public IFormFile ReportPicture { get; set; }
        public double ReportLatitude { get; set; }
        public double ReportLongitude { get; set; }
        public ApplicationUser ReportReporter { get; set; }
        public ApplicationUser ReportInvestigator { get; set; }
        public Investigation Investigation { get; set; }
        public Hazard Hazard { get; set; }
    }
}
