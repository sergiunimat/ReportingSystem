using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.Models;

namespace ReportSystem.Interfaces
{
    public interface IHazardService
    {
        string GetHazardTitleById(int hazardId);
        Task AddHazard(string hazardTitle);
        List<Hazard> GetAllHazards();
        int GetHazardIdByTitle(string hazardTitle);
    }

}
