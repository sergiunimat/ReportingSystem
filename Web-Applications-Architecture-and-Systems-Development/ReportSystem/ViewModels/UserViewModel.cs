using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSystem.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string CurrentUserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public int UserReportCount { get; set; }
        public int UserInvestigationCount { get; set; }
        public int UserCommentCount { get; set; }
        public int UserLikeCount { get; set; }
    }
}
