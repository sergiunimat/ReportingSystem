using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        [Required(ErrorMessage = "note, to create a report an image is necessary")]
        public IFormFile ReportPicture { get; set; }
        
        public double ReportLatitude { get; set; }
        
        public double ReportLongitude { get; set; }
<<<<<<< Updated upstream
=======
        //[Required(ErrorMessage = "note, to create a report choose an existing hazard or add a new one")]
>>>>>>> Stashed changes
        public List<Hazard> Hazards { get; set; }
        public string HazardTitle { get; set; }
        public string PicturePath { get; set; }
        public DateTime ReportRegisterTime { get; set; }
        public int ReportCommentCount { get; set; }

        public string ReporterName { get; set; }
        //public ApplicationUser ReportReporter { get; set; }
        //public ApplicationUser ReportInvestigator { get; set; }
        //public Investigation Investigation { get; set; }
        //public Hazard Hazard { get; set; }
    }
}
