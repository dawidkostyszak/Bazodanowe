namespace Shop.Domain.Model.User
{
    public class Address
    {
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public virtual string House { get; set; }
        public virtual string Flat { get; set; }
        public virtual string ZipCode { get; set; }
    }
}
