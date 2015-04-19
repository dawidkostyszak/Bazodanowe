namespace Shop.Domain.Model.User
{
    public class User
    {
        public enum UserRole
        {
            Customer,
            Worker
        }

        public int Id { get; set; }
        public Address Address { get; set; }
        public Name Name { get; set; }
        public string EmailAddress { get; set; }
        public int PhoneNumber { get; set; }
        public UserRole Role { get; set; }
        public Validations Validations { get; set; }
    }
}
