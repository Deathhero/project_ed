using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MusicDbContextProvider : IDbContextProvider
    {
        private readonly MusicDbContext _dbContext = new MusicDbContext();

        public MusicDbContext Context {
            get {
                return _dbContext;
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
            
        }
    }
}
