using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_StoreV10.Models;

namespace Book_StoreV10.Interfaces
{
    public interface IMailService
    {
        void Send(Message message);
    }
}
