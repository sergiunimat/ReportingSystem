using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.Data;
using ReportSystem.Interfaces;
using ReportSystem.Models;

namespace ReportSystem.Services
{
    public class InvestigationService: IInvestigationService
    {
        private readonly ApplicationDbContext _ctx;

        public InvestigationService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
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
    }
}
