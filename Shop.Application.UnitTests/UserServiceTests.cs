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

        public void CreateUser(int id, string username)
        {
            User user = UserObjectMother.CreateCleanCustomer(id, username);
            us.CreateUser(user);
        }

        [TestCleanup]
        public void CleanAfterTest()
        {
            foreach (var u in us.GetAllUsers())
            {
                us.DeleteUser(u.Id);
            }
        }

        [TestMethod]
        public void CheckGetAllUsersMethodResult()
        {
            CreateUser(1, "uzytkownik");
            CreateUser(2, "uzytkownik2");
            List<User> users = us.GetAllUsers();

            Assert.AreEqual(2, users.Count);
        }

        [TestMethod]
        public void CheckCreateUserMethodResult()
        {
            CreateUser(1, "uzytkownik");
            List<User> users = us.GetAllUsers();

            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        public void CheckDeleteUserMethodResult()
        {
            CreateUser(1, "uzytkownik");
            us.DeleteUser(1);
            List<User> result = us.GetAllUsers();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void CheckFindUserMethodResult()
        {
            CreateUser(1, "uzytkownik");
            User result = us.GetUser(1);

            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void CheckEditUserAddressrMethodResult()
        {
            CreateUser(1, "uzytkownik");

            Address address = UserObjectMother.CreateAddress();
            us.EditUserAdress(1, address);

            User result = us.GetUser(1);

            Assert.AreEqual("Miasto", result.Address.City);
            Assert.AreEqual("Budynek", result.Address.Flat);
            Assert.AreEqual("Mieszkanie", result.Address.House);
            Assert.AreEqual("Ulica", result.Address.Street);
            Assert.AreEqual("Kod", result.Address.ZipCode);
        }

        [TestMethod]
        public void CheckEditUserNameMethodResult()
        {
            CreateUser(1, "uzytkownik");

            Name name = UserObjectMother.CreateName();
            us.EditUserName(1, name);

            User result = us.GetUser(1);

            Assert.AreEqual("Imie", result.Name.FirstName);
            Assert.AreEqual("Nazwisko", result.Name.LastName);
        }

        [TestMethod]
        public void CheckEditUserPasswordMethodResult()
        {
            CreateUser(1, "uzytkownik");

            us.EditUserPassword(1, "admin");

            User result = us.GetUser(1);

            Assert.AreEqual("admin", result.Validations.Password);
        }

        [TestMethod]
        public void CheckEditUserPhoneNumberMethodResult()
        {
            CreateUser(1, "uzytkownik");

            us.EditUserPhoneNumber(1, 012345678);

            User result = us.GetUser(1);

            Assert.AreEqual(012345678, result.PhoneNumber);
        }

        [TestMethod]
        public void CheckLoginUserMethodResult()
        {
            User user = UserObjectMother.CreateCleanCustomer(1, "uzytkownik");
            CreateUser(1, "uzytkownik");

            bool logged = us.LoginUser(user.Validations.Username, user.Validations.Password);

            Assert.IsTrue(logged);
        }

        [TestMethod]
        public void CheckLogoutUserMethodResult()
        {
            User user = UserObjectMother.CreateCleanCustomer(1, "uzytkownik");
            CreateUser(1, "uzytkownik");

            bool logged = us.LoginUser(user.Validations.Username, user.Validations.Password);
            Assert.IsTrue(logged);
            bool logout = us.LogoutUser(user);
            Assert.IsTrue(logout);
        }
    }
}
