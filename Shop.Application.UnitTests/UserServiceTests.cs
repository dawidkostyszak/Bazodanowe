using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain.Model.User;
using Shop.ObjectMothers;

namespace Shop.Application.UnitTests
{
    [TestClass]
    public class UserServiceReturnTests
    {
        public IUserService us = new UserService();

        [TestMethod]
        public void CheckGetAllUsersMethodResult()
        {
            List<User> users = us.GetAllUsers();

            Assert.AreEqual(3, users.Count);
        }

        [TestMethod]
        public void CheckCreateUserMethodResult()
        {
            User user = UserObjectMother.CreateCleanCustomer();
            us.CreateUser(user);
            List<User> users = us.GetAllUsers();

            Assert.AreEqual(4, users.Count);
        }

        [TestMethod]
        public void CheckDeleteUserMethodResult()
        {
            User user = UserObjectMother.CreateCleanCustomer();
            us.CreateUser(user);
            List<User> users = us.GetAllUsers();
            Assert.AreEqual(4, users.Count);

            us.DeleteUser(user.Id);
            List<User> result = us.GetAllUsers();

            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void CheckFindUserMethodResult()
        {
            User user = UserObjectMother.CreateCleanCustomer();
            us.CreateUser(user);
            User result = us.GetUser(user.Id);

            Assert.AreEqual(user.Id, result.Id);
        }

        [TestMethod]
        public void CheckEditUserAddressrMethodResult()
        {
            User user = UserObjectMother.CreateCleanCustomer();
            us.CreateUser(user);

            Address address = UserObjectMother.CreateAddress();
            us.EditUserAdress(user.Id, address);

            User result = us.GetUser(user.Id);

            Assert.AreEqual("Miasto", result.Address.City);
            Assert.AreEqual("Budynek", result.Address.Flat);
            Assert.AreEqual("Mieszkanie", result.Address.House);
            Assert.AreEqual("Ulica", result.Address.Street);
            Assert.AreEqual("Kod", result.Address.ZipCode);
        }

        [TestMethod]
        public void CheckEditUserNameMethodResult()
        {
            User user = UserObjectMother.CreateCleanCustomer();
            us.CreateUser(user);

            Name name = UserObjectMother.CreateName();
            us.EditUserName(user.Id, name);

            User result = us.GetUser(user.Id);

            Assert.AreEqual("Imie", result.Name.FirstName);
            Assert.AreEqual("Nazwisko", result.Name.LastName);
        }

        [TestMethod]
        public void CheckEditUserPasswordMethodResult()
        {
            User user = UserObjectMother.CreateCleanCustomer();
            us.CreateUser(user);

            us.EditUserPassword(user.Id, "admin");

            User result = us.GetUser(user.Id);

            Assert.AreEqual("admin", result.Validations.Password);
        }

        [TestMethod]
        public void CheckEditUserPhoneNumberMethodResult()
        {
            User user = UserObjectMother.CreateCleanCustomer();
            us.CreateUser(user);

            us.EditUserPhoneNumber(user.Id, 012345678);

            User result = us.GetUser(user.Id);

            Assert.AreEqual(012345678, result.PhoneNumber);
        }

        [TestMethod]
        public void CheckLoginUserMethodResult()
        {
            User user = UserObjectMother.CreateCleanCustomer();
            us.CreateUser(user);

            bool logged = us.LoginUser(user.Validations.Username, user.Validations.Password);

            Assert.IsTrue(logged);
        }

        [TestMethod]
        public void CheckLogoutUserMethodResult()
        {
            User user = UserObjectMother.CreateCleanCustomer();
            us.CreateUser(user);

            bool logged = us.LoginUser(user.Validations.Username, user.Validations.Password);
            Assert.IsTrue(logged);
            bool logout = us.LogoutUser(user);
            Assert.IsTrue(logout);
        }
    }
}
