using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.Models;

namespace ReportSystem.Interfaces
{
    public interface IInvestigationService
    {
        void CreateInvestigation(Investigation investigation);
        List<Investigation> GetAllInvestigations();
        public void RemoveInvestigation(int investigationId);
        void UpdateInvestigation(Investigation investigation);
        Investigation GetInvestigationById(int invId);
        List<Investigation> GetInvestigationsByReporterId(string invId);
    }
}
