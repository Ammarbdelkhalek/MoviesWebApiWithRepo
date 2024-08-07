using RepositoryClassLibrary.netCore.interfaces;
using RepositoryClassLibrary.netCore.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoyPatternEFCORE.repsoitory
{
    public class BookBaseRepository : BaseRepository<Books>, IbooksRepository
    {
        private readonly AppDbContext context;
        public BookBaseRepository(AppDbContext context):base(context)
        {
            this.context = context;
        }
         
        public IEnumerable<Books> specialMethod()
        {
            throw new NotImplementedException();
        }
    }
}
