using Ecomm_practice01.DataAccess.Data;
using Ecomm_practice01.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm_practice01.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            category = new CategoryRepository(_context);
            coverType = new CoverTypeRepository(_context);
            SPCalls = new SPCalls(_context);
        }

        public ICategoryRepository category { private set; get; }
        public ICoverTypeRepository coverType { private  set; get; }
        public ISPCalls SPCalls { private  set; get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
