using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Database.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}