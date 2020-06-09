using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.ViewModels;

namespace ReportSystem.Interfaces
{
    public interface IHallOfFameService
    {
        List<BestReporterViewModel> GetBestReporters();
        List<BestInvestigator> GetBestInvestigators();
        List<ReportWithMostComments> GetReportWithMostComments();
        List<ReportWithMostLikes> GetReportWithMostLikes();
    }
}
