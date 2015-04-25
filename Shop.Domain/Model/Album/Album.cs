using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.Album
{
    public class Album
    {
        public virtual int Id { get; set; }
        public virtual Artist.Artist Artist { get; set; }
        public virtual IList<Order.Order> Orders { get; set; }
        public virtual Category Category { get; set; }
        [NotNullValidator(MessageTemplate = "Add additional information about album")]
        public virtual string Content { get; set; }
        [NotNullValidator(ErrorMessage = "Name can not be empty")]
        [StringLengthValidator(3, 100, MessageTemplate = "Add album name")]
        public virtual string Name { get; set; }
        [NotNullValidator(MessageTemplate = "Add price")]
        public virtual int Price { get; set; }
        public virtual DateTime PublishDate { get; set; }
        [ContainsCharactersValidator("CD,DVD,Vinyl", ContainsCharacters.Any, MessageTemplate = "Add type")]
        public virtual string Type { get; set; }

        public Album()
        {
            Orders = new List<Order.Order>();
        }
    }
}
