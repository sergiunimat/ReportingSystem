using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ReportSystem.ViewModels
{
    public class CommentViewModel
    {
        public Guid CommentId { get; set; }
        public string CommentOwner { get; set; }
        public string UserId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentCreateDate { get; set; }
        public int ReportId { get; set; }


    }
}
