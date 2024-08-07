using RepositoryClassLibrary.netCore.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryClassLibrary.netCore.interfaces
{
    public interface IbooksRepository :IBaseRepository<Books>
    {
        public IEnumerable<Books> specialMethod();
    }
}
