using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TaskMaster.Application.BaseInfo.Users;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;
using TaskMaster.Domain.Enums;

namespace TaskMaster.Application.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IUserDataAccess> _userDataAccessMock;
        private Mock<IDb> _dbMock;
        private CreateUser _useCase;

        [TestInitialize]
        public void Setup()
        {
            _userDataAccessMock = new Mock<IUserDataAccess>();
            _dbMock = new Mock<IDb>();
            _useCase = new CreateUser(_userDataAccessMock.Object, _dbMock.Object);
        }
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var req = new ICreateUser.Req
            {
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Password = "password123",
                Role = "Intern",
                Age = 25,
                Gender = "male"
            };
            _userDataAccessMock.Setup(x => x.GetUserByUsername(req.UserName)).Returns((User)null);
            // Act
            var result = _useCase.UserRegister(req);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(req.FirstName, result.Person.FirstName);
            Assert.AreEqual(req.LastName, result.Person.LastName);
            Assert.AreEqual(req.UserName, result.Username);
            Assert.AreEqual(req.Password, result.Password);
            Assert.AreEqual(UserRole.Role.Intern, result.Role);
            Assert.AreEqual(UserLevel.Level.Beginner, result.Level);
            _userDataAccessMock.Verify(x => x.AddUser(It.IsAny<User>()), Times.Once);
            _dbMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
