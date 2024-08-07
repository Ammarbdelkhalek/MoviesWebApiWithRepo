using RepositoryClassLibrary.netCore.interfaces;
using RepositoryClassLibrary.netCore.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryClassLibrary.netCore.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        IbooksRepository Books { get; }

        int complete();
    }
}
