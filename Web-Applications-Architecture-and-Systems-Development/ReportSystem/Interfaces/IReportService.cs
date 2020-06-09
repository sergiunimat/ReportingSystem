using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.Models;

namespace ReportSystem.Interfaces
{
    public interface IReportService
    {
        Task CreateReport(Report report);
        List<Report> GetAllReports();
        List<Report> GetReportsByReporterId(string userId);
        List<Report> GetReportsByInvestigatorId(string userId);
        Report GetReportById(int reportId);
        Task EditReport(Report report);
        Task DeleteReportId(int reportId);
        
    }
}
