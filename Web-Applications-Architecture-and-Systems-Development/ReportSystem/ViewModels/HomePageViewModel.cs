using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSystem.ViewModels
{
    public class HomePageViewModel
    {
        
        public List<ReportViewModel> ReportViewModels { get; set; }
        public List<BestReporterViewModel> BestReporterViewModels { get; set; }
        public List<BestInvestigator> BestInvestigators { get; set; }
        public List<ReportWithMostLikes> LikesList { get; set; }
        public List<ReportWithMostComments> CommentsList { get; set; }
        public List<HomeInvestigationViewModel> HomeInvestigationViewModels { get; set; }


        
    }
}
