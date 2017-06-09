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
    public class SongService : ISongService
    {
        private readonly MusicDbContextProvider _contextProvider;

        public SongService(MusicDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }


        public void AddSong(Song song)
        {
            if (song == null) return;
            var newSong = new Song
            {
                Id = song.Id,
                Title = song.Title,
                Duration = song.Duration,
                Appearances = song.Appearances,
                IsCover = song.IsCover,
                GenreId = song.GenreId
            };
            _contextProvider.Context.Songs.Add(newSong);
            _contextProvider.Context.SaveChanges();
        }

        public void DeleteSong(Song song)
        {
            _contextProvider.Context.Songs.Remove(song);
            _contextProvider.Context.SaveChanges();
        }

        public Song GetSongById(int? Id)
        {
            return _contextProvider.Context.Songs.First(x => x.Id == Id);
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
