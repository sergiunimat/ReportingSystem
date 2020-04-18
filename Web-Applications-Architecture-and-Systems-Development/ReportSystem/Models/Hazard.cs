using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSystem.Models
{
    public class Hazard
    {
        public int HazardId { get; set; }
        public string HazardTitle { get; set; }
        public string HazardDescription { get; set; }
        [ForeignKey("ReportId")]
        public Report Report { get; set; }

    }
}
