using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using OurModel;
using Services.Abstract;

namespace Services.Implementation
{
    public class AlbumService : IAlbumService
    {
        private readonly MusicDbContextProvider _contextProvider;

        public AlbumService(MusicDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }


        public void AddAlbum(Album album)
        {
            if (album == null) return;
            var newAlbum = new Album
            {
                Id = album.Id,
                Title = album.Title,
                Year = album.Year,
                Status = album.Status,
                Genre = album.Genre,
                Songs = album.Songs
            };
            _contextProvider.Context.Albums.Add(newAlbum);
            _contextProvider.Context.SaveChanges();
        }

        public void DeleteAlbum(Album album)
        {
            _contextProvider.Context.Albums.Remove(album);
            _contextProvider.Context.SaveChanges();
        }

        public Album GetAlbumById(int? Id)
        {
            return _contextProvider.Context.Albums.First(x => x.Id == Id);
        }
        /*
        public void EditStudio(int Id, Studio studio)
        {
            if (studio == null) return;
            Studio newStudio = GetStudioById(Id);

            _contextProvider.Context.Studios.AddOrUpdate(newStudio);
            _contextProvider.Context.SaveChanges();
        }*/
    }
}
