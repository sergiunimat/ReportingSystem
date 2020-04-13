using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSystem.Interfaces
{
    interface IRoleService
    {
        Task CreateRoleIfDoesNotExist(string roleName);
    }
}
