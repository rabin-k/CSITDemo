using CSITDemo.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSITDemo.Services
{
    public class ClassService : IClassService
    {
        private readonly OrchidDbContext _dbContext;
        public ClassService(OrchidDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Class> GetAllClasses()
        {
            return _dbContext.Classes
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .ToList();
        }
    }
}
