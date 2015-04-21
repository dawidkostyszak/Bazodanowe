namespace Shop.Domain.Model.User
{
    public class Validations
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual bool Logged { get; set; }
    }
}
