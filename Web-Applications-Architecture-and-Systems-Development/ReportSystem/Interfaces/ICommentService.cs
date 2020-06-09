using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.Models;

namespace ReportSystem.Interfaces
{
    public interface ICommentService
    {
        public void CreateComment(Guid commentId, int reportId, string userId, string commentText);
        List<Comment> GetAllCommentsByReportId(int reportId);
        int CountCommentsByReportId(int reportId);
        List<Comment> GetAllCommentsByReporterId(string userId);
    }
}
