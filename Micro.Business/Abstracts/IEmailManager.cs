using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Business.Abstracts
{
    public interface IEmailManager
    {
        void Send(string to, string subject, string body);
    }
}
