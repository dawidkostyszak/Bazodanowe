using System.Collections.Generic;

namespace Shop.Domain.Model.Album
{
    public class Category
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Album> Albums { get; set; }

        public Category()
        {
            Albums = new List<Album>();
        }
    }
}
