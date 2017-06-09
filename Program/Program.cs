using DAL;
using OurModel;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Implementation;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MusicDbContextProvider();
            StudioService ss = new StudioService(context);
            Studio a = new Studio { Id = 1, Title = "Sunny Records", Address = "Hollywood, 1", Phone = 88005553535};
            ss.AddStudio(a);
            a = ss.GetStudioById(1);
            Console.WriteLine(a.Title);
            Console.ReadKey();
        }
    }
}
