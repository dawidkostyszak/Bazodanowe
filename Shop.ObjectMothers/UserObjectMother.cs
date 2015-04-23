using Shop.Domain.Model.User;

namespace Shop.ObjectMothers
{
    public class UserObjectMother
    {
        //Create customer with only username and password
        public static User CreateCleanCustomer(int id, string username)
        {
            Validations validations = CreatValidations(username);
            return new User{Id = id, Role = UserRole.Customer, Validations = validations};
        }

        public static User CreateCustomerWithAddress(int id, string username)
        {
            Validations validations = CreatValidations(username);
            Address address = CreateAddress();
            return new User{ Id = id, Role = UserRole.Customer, Validations = validations, Address = address };
        }

        public static Address CreateAddress()
        {
            return new Address{City = "Miasto", Flat = "Budynek", House = "Mieszkanie", Street = "Ulica", ZipCode = "Kod"};
        }

        public static Name CreateName()
        {
            return new Name{FirstName = "Imie", LastName = "Nazwisko"};
        }

        public static Validations CreatValidations(string username)
        {
            return new Validations{Logged = false, Password = "haslo", Username = username};
        }
    }
}
