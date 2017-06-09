using OurModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IStudioService
    {
        void AddStudio(Studio studio);
        Studio GetStudioById(int? Id);
        void DeleteStudio(Studio studio);
        //void EditStudio(int Id, Studio studio);
    }
}
