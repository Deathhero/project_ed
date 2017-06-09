using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurModel;

namespace Services.Abstract
{
    public interface IGenreService
    {
        void AddGenre(Genre genre);
        Genre GetGenreById(int? Id);
        void DeleteGenre(Genre genre);
        //void EditStudio(int Id, Studio studio);
    }
}
