using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OurModel
{
    public class SongViewModel : Entity
    {
        public string Title { get; set; }
        [DataType(DataType.Duration)]
        public float Duration { get; set; }
        public string Appearances { get; set; }
        public bool IsCover { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}