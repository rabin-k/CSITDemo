using CSITDemo.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSITDemo.Services
{
    public interface IClassService
    {
        IList<Class> GetAllClasses();
    }
}
