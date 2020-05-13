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
    public class HazardService: IHazardService
    {
        private readonly ApplicationDbContext _ctx;

        public HazardService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddHazard(string hazardTitle)
        {
            var hazardExit = await _ctx.Hazards.Where(h => h.HazardTitle == hazardTitle).AnyAsync();
            if (!hazardExit)
            {
                var hazard = new Hazard()
                {
                    HazardTitle = hazardTitle,
                };
                await _ctx.AddAsync(hazard);
                await _ctx.SaveChangesAsync();
            }
        }

        public string GetHazardTitleById(int hazardId)
        {
            return  _ctx.Hazards.First(h => h.HazardId == hazardId).HazardTitle;
        }

        public int GetHazardIdByTitle(string hazardTitle)
        {
            return  _ctx.Hazards.First(h => h.HazardTitle == hazardTitle).HazardId;
        }

        public  List<Hazard> GetAllHazards()
        {
            return  _ctx.Hazards.ToList();
        }
    }
}
