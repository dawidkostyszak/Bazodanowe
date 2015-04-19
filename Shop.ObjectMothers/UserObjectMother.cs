using Shop.Domain.Model.User;

namespace Shop.ObjectMothers
{
    public class UserObjectMother
    {
        //Create customer with only username and password
        public static User CreateCleanCustomer()
        {
            Validations validations = CreatValidations();
            return new User{Id = 100, Role = User.UserRole.Customer, Validations = validations};
        }

        public static User CreateCustomerWithAddress()
        {
            Validations validations = CreatValidations();
            Address address = CreateAddress();
            return new User{ Id = 100, Role = User.UserRole.Customer, Validations = validations, Address = address };
        }

        public static Address CreateAddress()
        {
            return new Address{City = "Miasto", Flat = "Budynek", House = "Mieszkanie", Street = "Ulica", ZipCode = "Kod"};
        }

        public static Name CreateName()
        {
            return new Name{FirstName = "Imie", LastName = "Nazwisko"};
        }

        public static Validations CreatValidations()
        {
            return new Validations{Logged = false, Password = "haslo", Username = "uzytkownik"};
        }
    }
}
