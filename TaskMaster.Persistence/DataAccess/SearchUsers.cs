using System;
using System.Linq;
using TaskMaster.Application.BaseInfo.Users;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Persistence.DataAccess
{
    public class SearchUsers(IDb db) : ISearchUsers
    {
        public IQueryable<User> Respond(out int totalPages, ISearchUsers.Request request = null)
        {
            return Respond(request, db.Query<User>(), out totalPages);
        }

        private IQueryable<User> Respond(ISearchUsers.Request request, IQueryable<User> items, out int totalPages)
        {
            totalPages = 0;

            if (!string.IsNullOrWhiteSpace(request?.SearchItem))
            {
                items = items.Where(e => e.Username.Contains(request.SearchItem.Replace(" ", "")));

            }
            if (!string.IsNullOrWhiteSpace(request?.Username))
            {
                items = items.Where(e => e.Username == request.Username);
            }
            if (request.Id != 0)
            {
                items = items.Where(e => e.Id == request.Id);
            }

            if (request.PgeSize != 0 || request.PageNumber is not null)
            {
                int totalItems = items.Count();
                totalPages = (int)Math.Ceiling((double)totalItems / request.PgeSize);

                items = items.OrderBy(u => u.Id)
                    .Skip((int)request.PageNumber * request.PgeSize)
                    .Take(request.PgeSize);
            }

            return items;
        }
    }
}

