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
    public class GenreService : IGenreService
    {
        private readonly MusicDbContextProvider _contextProvider;

        public GenreService(MusicDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }


        public void AddGenre(Genre genre)
        {
            if (genre == null) return;
            var newGenre = new Genre
            {
                Id = genre.Id,
                Title = genre.Title,
                YearOfMeaning = genre.YearOfMeaning,
                Description = genre.Description
            };
            _contextProvider.Context.Genres.Add(newGenre);
            _contextProvider.Context.SaveChanges();
        }

        public void DeleteGenre(Genre genre)
        {
            _contextProvider.Context.Genres.Remove(genre);
            _contextProvider.Context.SaveChanges();
        }

        public Genre GetGenreById(int? Id)
        {
            return _contextProvider.Context.Genres.First(x => x.Id == Id);
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
