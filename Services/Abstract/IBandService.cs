using OurModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IBandService
    {
        void AddBand(Band band);
        Band GetBandById(int? Id);
        void DeleteBand(Band band);
        //void EditBand(int Id, Band band);
    }
}
