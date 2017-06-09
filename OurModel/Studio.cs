using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurModel
{
    public class Studio:Entity
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public List<Band> Bands { get; set; }
    }
}
