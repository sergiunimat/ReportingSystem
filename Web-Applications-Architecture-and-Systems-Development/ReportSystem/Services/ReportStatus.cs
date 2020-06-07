using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.Data;
using ReportSystem.Interfaces;


namespace ReportSystem.Services
{
    public class ReportStatus :IReportStatus
    {
        private readonly ApplicationDbContext _ctx;

        public ReportStatus(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Models.ReportStatus GetReportStatusById(int reportStatusId)
        {
            return  _ctx.ReportStatuses.FirstOrDefault(s => s.StatusId == reportStatusId);
        }
    }
}
