using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurModel
{
    public class Genre:Entity
    {
        public string Title { get; set; }
        public int YearOfMeaning { get; set; }
        public string Description { get; set; }
    }
}