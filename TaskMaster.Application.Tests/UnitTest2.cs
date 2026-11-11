using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Domain.Enums;
using TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance;
using TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.DataAccess;
using System.Data.Entity;
using System.Linq;

namespace TaskMaster.Application.Tests
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        private DataBaseContext _dbContext;
        private IDb _db;
        private UserDataAccess _userDataAccess;

        [TestInitialize]
        public void Setup()
        {
            _dbContext = new DataBaseContext();
            _db = _dbContext;
            _userDataAccess = new UserDataAccess(_dbContext);
        }
        [TestCleanup]
        public void CleanUp()
        {
            _dbContext.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            User user = new User
            {
                Username = "testuser",
                Password = "password123",
                Role = UserRole.Role.Intern,
                Level = UserLevel.Level.Beginner,
                Score = 0,
                PersonId = 0,
                Id = 0,

                Person = new Person
                {
                    FirstName = "Test",
                    LastName = "User"
                }
            };
            _userDataAccess.AddUser(user);
            _db.SaveChanges();
            using (var verificationContext = new DataBaseContext())
            {
                var savedUser = verificationContext.Set<User>()
                    .Include(u => u.Person).SingleOrDefault(u => u.Username == user.Username);

                Assert.IsNotNull(savedUser);
                Assert.IsNotNull(savedUser.Person);
                Assert.AreEqual(savedUser.Person.Id, user.PersonId);
                Assert.AreEqual(savedUser.Person.FirstName, user.Person.FirstName);
                Assert.AreEqual(savedUser.Person.LastName, user.Person.LastName);
                Assert.AreEqual(savedUser.Person.Age, user.Person.Age);
            }
        }
    }
}
