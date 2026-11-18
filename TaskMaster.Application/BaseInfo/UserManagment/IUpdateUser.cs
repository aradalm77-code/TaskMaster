using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Application.BaseInfo.UserManagment
{
    public interface IUpdateUser
    {
        void EditUser(Request request);
        public class Request
        {
            public Person Person { get; set; }
            public User User { get; set; }
            public string Username { get; set; }
        }
    }
}
