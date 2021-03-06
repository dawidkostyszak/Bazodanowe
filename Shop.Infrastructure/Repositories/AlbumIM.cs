﻿using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;
using Shop.Domain.Model.Artist;

namespace Shop.Infrastructure.Repositories
{
    public class AlbumIM : IAlbumRepository
    {
        private List<Album> albums = new List<Album>();

        public Album Insert(Album album)
        {
            albums.Add(album);
            return album;
        }

        public void Edit(Album album)
        {
            foreach (var a in albums)
                if (a.Id == album.Id)
                {
                    a.Artist = album.Artist;
//                    a.Categories = album.Categories;
                    a.Content = album.Content;
                    a.Name = album.Name;
                    a.Price = album.Price;
                    a.PublishDate = album.PublishDate;
                    a.Type = album.Type;
                }
        }

        public void Delete(int id)
        {
            foreach (var a in albums.Where(a => a.Id == id))
            {
                albums.Remove(a);
                break;
            }
        }

        public Album Find(int id)
        {
            return albums.Single(p => p.Id == id);
        }

        public List<Album> FindAll()
        {
            return albums;
        }

        public List<Album> FindByArtist(Artist artist)
        {
            return albums.Where(a => a.Artist.Id == artist.Id).ToList();
        }

        public List<Album> FindByCategory(Category category)
        {
            return (from a in albums where a.Category.Id == category.Id select a).ToList();
        }

        public List<Album> FindByType(string type)
        {
            return albums.Where(a => a.Type == type).ToList();
        }
    }
}
