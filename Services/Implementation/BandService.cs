using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurModel;
using DAL;

namespace Services.Implementation
{
    public class BandService : IBandService
    {
        private readonly MusicDbContextProvider _contextProvider;

        public BandService(MusicDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public void AddBand(Band band)
        {
            if (band == null) return;
            var newBand = new Band
            {
                Id = band.Id,
                Title = band.Title,
                NumberOfMembers = band.NumberOfMembers,
                Members = band.Members,
                Genre = band.Genre,
                Albums = band.Albums,
                YearOfFoundation = band.YearOfFoundation,
                YearOfEnd = band.YearOfEnd
            };
            _contextProvider.Context.Bands.Add(newBand);
            _contextProvider.Context.SaveChanges();
        }

        public void DeleteBand(Band band)
        {
            _contextProvider.Context.Bands.Remove(band);
            _contextProvider.Context.SaveChanges();
        }

        public Band GetBandById(int? Id)
        {
            return _contextProvider.Context.Bands.First(x => x.Id == Id);
        }
    }
}
