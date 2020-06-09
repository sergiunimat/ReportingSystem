using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ReportSystem.Models;

namespace ReportSystem.ViewModels
{
    public class ReportViewModel
    {

        public int ReportId { get; set; }
        [StringLength(120, MinimumLength = 3)]
        [Required]
        public String ReportTitle { get; set; }
        [StringLength(600, MinimumLength = 12)]
        [Required]
        public string ReportDescription { get; set; }
        
        public IFormFile ReportPicture { get; set; }
        public double ReportLatitude { get; set; }
        public double ReportLongitude { get; set; }
        
        public List<Hazard> Hazards { get; set; }
        public string HazardTitle { get; set; }
        public string PicturePath { get; set; }
        public DateTime ReportRegisterTime { get; set; }
        public int ReportCommentCount { get; set; }
        public string ReporterName { get; set; }
        public string ReporterId { get; set; }
        public string CurrentUserId { get; set; }
        public int ReportStatusId { get; set; }
        public string ReportStausText { get; set; }
        public int ReportLikes { get; set; }
        
        
        //public ApplicationUser ReportReporter { get; set; }
        //public ApplicationUser ReportInvestigator { get; set; }
        //public Investigation Investigation { get; set; }
        //public Hazard Hazard { get; set; }
    }
}
