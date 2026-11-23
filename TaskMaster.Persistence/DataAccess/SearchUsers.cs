using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Application.BaseInfo.Users;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Persistence.DataAccess
{
    public class SearchUsers(IDb db, ISearchPersons searchPersons) : ISearchUsers
    {
        public IQueryable<User> Respond(ISearchUsers.Request request = null)
        {
            return Respond(request, db.Query<User>());
        }

        private IQueryable<User> Respond(ISearchUsers.Request request, IQueryable<User> items)
        {
            if (!string.IsNullOrWhiteSpace(request?.SearchItem))
            {
                items = items.Where(e => e.Username.Contains(request.SearchItem.Replace(" ", "")));
            }
            if (!string.IsNullOrWhiteSpace(request?.Username))
            {
                items = items.Where(e => e.Username == request.Username);
            }
            if(request.Id != 0)
            {
                items = items.Where(e => e.Id == request.Id);
            }
            if (request?.PersonRequest != null)
            {
                items = from user in items
                join person in searchPersons.Respond(request.PersonRequest)
                on user.PersonId equals person.Id
                        select user;
            }

            return items;
        }
    }
}

