using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurModel
{
    public class AlbumViewModel: Entity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public List<Song> Songs { get; set; }
    }
}
