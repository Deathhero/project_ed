using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurModel;
using DAL;
using System.Data.Entity.Migrations;

namespace Services.Implementation
{
    public class StudioService : IStudioService
    {
        private readonly MusicDbContextProvider _contextProvider;

        public StudioService(MusicDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }


        public void AddStudio(Studio studio)
        {
            if (studio == null) return;
            var newStudio = new Studio
            {
                Id = studio.Id,
                Title = studio.Title,
                Bands = studio.Bands,
                Address = studio.Address,
                Phone = studio.Phone,
            };
            _contextProvider.Context.Studios.Add(newStudio);
            _contextProvider.Context.SaveChanges();
        }

        public void DeleteStudio(Studio studio)
        {
            _contextProvider.Context.Studios.Remove(studio);
            _contextProvider.Context.SaveChanges();
        }

        public Studio GetStudioById(int? Id)
        {
            return _contextProvider.Context.Studios.First(x => x.Id == Id);
        }
        /*
        public void EditStudio(int Id, Studio studio)
        {
            if (studio == null) return;
            Studio newStudio = GetStudioById(Id);

            _contextProvider.Context.Studios.AddOrUpdate(newStudio);
            _contextProvider.Context.SaveChanges();
        }*/
    }
}
