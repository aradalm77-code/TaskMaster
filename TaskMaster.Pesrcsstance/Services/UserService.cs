using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.Services
{
    public class UserService : IUserService
    {
        public void AddUser(User user)
        {
            try
            {
                using (var context = new UserReposetory())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void EditUser(User user, string Username)
        {
            try
            {
                using (var context = new UserReposetory())
                {
                    User User = context.Users.FirstOrDefault(x => x.Username == Username);
                    if(User is null)
                    {
                        throw new Exception("The User Does not Exist");
                    }
                    User = user;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public User GetUserByUsername(string Username)
        {
            using (var context = new UserReposetory())
            {
                User user = context.Users.FirstOrDefault(x => x.Username == Username);
                if (user is null)
                {
                    throw new Exception("The User Does not Exist");
                }
                return user;
            }
        }

        public List<User> GetUsers()
        {
            using (var context = new UserReposetory())
            {
                return context.Users.ToList();
            }
        }

        public void RemoveUser(User user)
        {
            using (var context = new UserReposetory())
            {
                context.Users.Attach(user);
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
        public List<User> SearchUser(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<User>();

            string[] words = searchTerm
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .ToArray();

            using (var context = new UserReposetory())
            {
                var query = context.Users.Where(u =>
                    words.Any(word =>
                        u.Username.Contains(word) ||
                        u.FirstName.Contains(word) ||
                        u.LastName.Contains(word)
                    )
                );

                return query.Distinct().ToList();
            }
        }
    }
}