using RepositoryClassLibrary.netCore.interfaces;
using RepositoryClassLibrary.netCore.models;
using RepositoryClassLibrary.netCore.UnitofWork;
using RepositoyPatternEFCORE.repsoitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoyPatternEFCORE.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public IBaseRepository<Author> Authors { get; }

        public IbooksRepository Books { get; }
        public UnitOfWork(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;
            Authors = new BaseRepository<Author>(_appDbContext);
            Books = new BookBaseRepository(_appDbContext);

        }

        public int complete()
        {
            return _appDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
