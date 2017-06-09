using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurModel
{
    public class BandViewModel : Entity
    {
        public string Title { get; set; }
        public int NumberOfMembers { get; set; }
        public int YearOfFoundation { get; set; }
        public int YearOfEnd { get; set; }
        public List<Member> Members { get; set; }
        public List<Album> Albums { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
