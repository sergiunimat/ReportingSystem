using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.Models;
using ReportSystem.ViewModels;

namespace ReportSystem.Interfaces
{
    public interface IAdminService
    {
        Task EditUser(EditUserViewModel userObj);
        Task DeleteUser(string userId);
        void DelUser(string userId);
    }
}
