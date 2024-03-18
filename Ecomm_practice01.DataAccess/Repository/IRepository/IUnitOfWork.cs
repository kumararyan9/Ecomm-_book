using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm_practice01.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository category { get;  }
        public ICoverTypeRepository coverType { get;  }
        public ISPCalls SPCalls { get;  }
        void Save();
    }
}
