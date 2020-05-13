using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ReportSystem.Data;
using ReportSystem.Interfaces;
using ReportSystem.Models;

namespace ReportSystem.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _ctx;

        public CommentService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateComment(Guid commentId,int reportId, string userId,string commentText)
        {
            if (!_ctx.Comments.Any(c => c.CommentId==commentId))
            {
                var newComment = new Comment()
                {
                    CommentId = commentId,
                    CommentText = commentText,
                    CommentCreateDate = DateTime.Now,
                    ReportId = reportId,
                    UserId = userId
                };
                _ctx.Comments.Add(newComment);
                _ctx.SaveChanges();
            }
        }

        public List<Comment> GetAllCommentsByReportId(int reportId)
        {
            return _ctx.Comments.Where(c => c.ReportId == reportId).ToList();
        }

        public int CountCommentsByReportId(int reportId)
        {
            return _ctx.Comments.Count(c => c.ReportId == reportId);
        }
    }
}
