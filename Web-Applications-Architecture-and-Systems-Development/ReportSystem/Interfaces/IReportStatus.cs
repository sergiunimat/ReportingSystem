using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.Models;

namespace ReportSystem.Interfaces
{
    interface IReportStatus
    {
        ReportStatus GetReportStatusById(int reportStatusId);
    }
}
