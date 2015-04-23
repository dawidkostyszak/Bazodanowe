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

        public User CreateUser(string username)
        {
            User user = UserObjectMother.CreateCleanCustomer(username);
            return us.CreateUser(user);
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
            CreateUser("uzytkownik");
            CreateUser("uzytkownik2");
            List<User> users = us.GetAllUsers();

            Assert.AreEqual(2, users.Count);
        }

        [TestMethod]
        public void CheckCreateUserMethodResult()
        {
            CreateUser("uzytkownik");
            List<User> users = us.GetAllUsers();

            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        public void CheckDeleteUserMethodResult()
        {
            var user = CreateUser("uzytkownik");
            us.DeleteUser(user.Id);
            List<User> result = us.GetAllUsers();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void CheckFindUserMethodResult()
        {
            var user = CreateUser("uzytkownik");
            User result = us.GetUser(user.Id);

            Assert.AreEqual(user.Id, result.Id);
        }

        [TestMethod]
        public void CheckEditUserAddressrMethodResult()
        {
            var user = CreateUser("uzytkownik");

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
            var user = CreateUser("uzytkownik");

            Name name = UserObjectMother.CreateName();
            us.EditUserName(user.Id, name);

            User result = us.GetUser(user.Id);

            Assert.AreEqual("Imie", result.Name.FirstName);
            Assert.AreEqual("Nazwisko", result.Name.LastName);
        }

        [TestMethod]
        public void CheckEditUserPasswordMethodResult()
        {
            var user = CreateUser("uzytkownik");

            us.EditUserPassword(user.Id, "admin");

            User result = us.GetUser(user.Id);

            Assert.AreEqual("admin", result.Validations.Password);
        }

        [TestMethod]
        public void CheckEditUserPhoneNumberMethodResult()
        {
            var user = CreateUser("uzytkownik");

            us.EditUserPhoneNumber(user.Id, 012345678);

            User result = us.GetUser(user.Id);

            Assert.AreEqual(012345678, result.PhoneNumber);
        }

        [TestMethod]
        public void CheckEditUserEmailAddressMethodResult()
        {
            var user = CreateUser("uzytkownik");

            us.EditUserEmailAddress(user.Id, "test@test.pl");

            User result = us.GetUser(user.Id);

            Assert.AreEqual("test@test.pl", result.EmailAddress);
        }

        [TestMethod]
        public void CheckLoginUserMethodResult()
        {
            var user = CreateUser("uzytkownik");

            bool logged = us.LoginUser(user.Validations.Username, user.Validations.Password);

            Assert.IsTrue(logged);
        }

        [TestMethod]
        public void CheckLogoutUserMethodResult()
        {
            var user = CreateUser("uzytkownik");

            bool logged = us.LoginUser(user.Validations.Username, user.Validations.Password);
            Assert.IsTrue(logged);
            bool logout = us.LogoutUser(user);
            Assert.IsTrue(logout);
        }
    }
}
