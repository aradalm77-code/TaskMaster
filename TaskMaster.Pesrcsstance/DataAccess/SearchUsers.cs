using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Application.BaseInfo.UserManagment;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.DataAccess
{
    public class SearchUsers(IDb context) : ISearchUsers
    {
        public IQueryable<User> Search(ISearchUsers.Request request = null)
        {
            if (string.IsNullOrWhiteSpace(request?.SearchItem))
            {
                var users = context.Query<User>().Include(u => u.Person);
                return users;
            }
            else
            {
                var users = context.Query<User>().Include(u => u.Person).Where(
                e => e.Username.Contains(request.SearchItem.Replace(" ", ""))
                || e.Person.FirstName.Contains(request.SearchItem.Replace(" ", ""))
                || e.Person.LastName.Contains(request.SearchItem.Replace(" ", ""))
                ).Distinct();
                return users;
            }
        }
    }
}
