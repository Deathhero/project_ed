using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace OurModel
{
    public class Song:Entity
    {
        public string Title { get; set; }
        //[DataType(DataType.Date)]
        public float Duration { get; set; }
        public string Appearances { get; set; }
        public bool IsCover { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}