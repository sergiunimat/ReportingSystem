using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.Data;
using ReportSystem.Interfaces;
using ReportSystem.Models;

namespace ReportSystem.Services
{
    public class LikeService: ILikeService
    {
        private readonly ApplicationDbContext _ctx;

        public LikeService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateLike(Like like)
        {
            _ctx.Likes.Add(like);
            _ctx.SaveChanges();
        }

        public void UpdateLike(Like like)
        {
            _ctx.Likes.Update(like);
            _ctx.SaveChanges();
        }

        public Like GetLikeBasedOnReportIdAndUserId(int reportId,string userId)
        {
            return _ctx.Likes.FirstOrDefault(l => l.ReportId == reportId && l.UserId == userId);
        }

        public List<Like> GetAlLikesForReport(int reportId)
        {
            return _ctx.Likes.Where(l => l.ReportId==reportId && l.Liked==true).ToList();
        }
    }
}
