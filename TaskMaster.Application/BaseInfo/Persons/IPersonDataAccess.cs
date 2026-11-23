using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.BaseInfo.Persons
{
    public interface IPersonDataAccess
    {
        void Update(Request request);
        void Delete(Request request);
        void Add(Request request);
        void RemoveById(Request request);
        public class Request
        {
            public int Id { get; set; }
            public Person person { get; set; }
        }
    }
}
