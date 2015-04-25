using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.User
{
    public class Address
    {
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public virtual string House { get; set; }
        public virtual string Flat { get; set; }
        [RegexValidator(@"\d{2}-\d{3}", ErrorMessage = "Zip code should have format XX-XXX")]
        public virtual string ZipCode { get; set; }
    }
}
