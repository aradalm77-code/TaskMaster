using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Application.Interfaces
{
    public interface IGetUsers
    {
        List<User> GetUserList();
        List<User> SearchUser(string searchItem);
    }
}
