using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSystem.Models
{
    public class Like
    {
        [Key]
        public int Likeid { get; set; }
        public string UserId { get; set; }
        public int ReportId { get; set; }
        public bool Liked { get; set; }
    }
}
