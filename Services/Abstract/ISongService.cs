using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurModel;

namespace Services.Abstract
{
    public interface ISongService
    {
        void AddSong(Song song);
        Song GetSongById(int? Id);
        void DeleteSong(Song song);
        //void EditStudio(int Id, Studio studio);
    }
}
