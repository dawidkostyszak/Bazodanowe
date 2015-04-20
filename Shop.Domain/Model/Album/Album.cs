﻿using System;
using System.Collections.Generic;

namespace Shop.Domain.Model.Album
{
    public class Album
    {
        public virtual int Id { get; set; }
        public virtual Artist.Artist Artist { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual string Content { get; set; }
        public virtual string Name { get; set; }
        public virtual int Price { get; set; }
        public virtual DateTime PublishDate { get; set; }
        public virtual string Type { get; set; }

        public Album()
        {
            Categories = new List<Category>();
        }
    }
}