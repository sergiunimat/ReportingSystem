using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReportSystem.Data;
using ReportSystem.Interfaces;
using ReportSystem.Models;

namespace ReportSystem.Services
{
    public class InvestigationService: IInvestigationService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IReportService _reportService;

        public InvestigationService(ApplicationDbContext ctx,IReportService reportService)
        {
            _ctx = ctx;
            _reportService = reportService;
        }

        public void CreateInvestigation(Investigation investigation)
        {
            _ctx.Investigations.Add(investigation);
            _ctx.SaveChanges();
        }

        public List<Investigation> GetAllInvestigations()
        {
            return _ctx.Investigations.ToList();
        }

        public Investigation GetInvestigationById(int invId)
        {
            return _ctx.Investigations.FirstOrDefault(i => i.InvestigationId == invId);
        }

        public List<Investigation> GetInvestigationsByReporterId(string invId)
        {
             return _ctx.Investigations.Where(i=>i.InvestigatorId== invId).ToList();
        }

        //public Investigation GetInvestigationByReporterId(int reportId)
        //{
        //    return _ctx.Investigations.FirstOrDefault(inv => inv.ReportId == reportId);
        //}

        public async Task<Investigation> GetInvestigationByReporterId(int reportId)
        {
            return await _ctx.Investigations.Where(x => x.ReportId == reportId).FirstOrDefaultAsync();
        }


        public void RemoveInvestigation(int investigationId)
        {
            var tempInv = GetInvestigationById(investigationId);
            _ctx.Investigations.Remove(tempInv);
            _ctx.SaveChanges();
        }

        public void RemoveInvestigationAsync(Investigation investigation)
        {
             _ctx.Remove(investigation);
             _ctx.SaveChanges();
        }

        public bool CheckIfInvestigatorIsActive(string investigatorId)
        {
            return  _ctx.Investigations.Any(i => i.InvestigatorId == investigatorId);
            
        }

        public void UpdateInvestigation(Investigation investigation)
        {
            _ctx.Update(investigation);
            _ctx.SaveChanges();
        }

        
    }
}
