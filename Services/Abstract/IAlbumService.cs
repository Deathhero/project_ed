using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurModel;

namespace Services.Abstract
{
    public interface IAlbumService
    {
        void AddAlbum(Album album);
        Album GetAlbumById(int? Id);
        void DeleteAlbum(Album album);
        //void EditBand(int Id, Band band);
    }
}
