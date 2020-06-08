using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.Models;

namespace ReportSystem.Interfaces
{
    public interface ILikeService
    {
        void CreateLike(Like like);
        void UpdateLike(Like like);
        Like GetLikeBasedOnReportIdAndUserId(int reportId, string userId);
        List<Like> GetAlLikesForReport(int reportId);
    }
}
