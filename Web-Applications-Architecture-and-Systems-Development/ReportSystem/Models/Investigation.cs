using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSystem.Models
{
    public class Investigation
    {
        public int InvestigationId { get; set; }
        public bool InvestigationStatus { get; set; }
        [ForeignKey("ReportId")]
        public Report Report { get; set; }

    }
}
