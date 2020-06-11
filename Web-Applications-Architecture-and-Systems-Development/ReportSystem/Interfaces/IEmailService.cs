using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSystem.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string To, string Subject, string BodyContent);
    }
}
