using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSystem.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string UserId { get; set; }
        public int ReportId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentCreateDate { get; set; }
    }
}
