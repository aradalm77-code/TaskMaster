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

    public class SearchUsers(IDb context, ISearchPersons searchPersons, ISearchUsers searchUsers) : ISearchUsers
    {
        public IQueryable<IUserDataAccess.ResponseDTO> Search(
            ISearchUsers.Request request = null)
        {
            var items = context.Query<User>();

            return Execute(request, items);
        }

        private IQueryable<IUserDataAccess.ResponseDTO> Execute(
            ISearchUsers.Request request,
            IQueryable<User> items)
        {


            IQueryable<Person> people = null;
            var result = searchUsers.Search(request);

            // ---------- cheking if user searched for something ----------

            if (!string.IsNullOrWhiteSpace(request?.SearchItem))
            {
                string searchTerm = request.SearchItem.Replace(" ", "");

                result = result.Where(e =>
                    e.User.Username.Contains(searchTerm));
            }

            // ---------- cheking if person is requiered ----------

            if (request?.PersonRequest != null)
            {
                people = searchPersons.SearchPeople(request.PersonRequest);
                result =
                from user in items
                join person in people
                on user.PersonId equals person.Id
                select new IUserDataAccess.ResponseDTO
                {
                    User = user,
                    Person = person
                };
            }

            return result;
        }
    }
}

