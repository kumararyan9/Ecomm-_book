using Ecomm_practice01.DataAccess.Data;
using Ecomm_practice01.DataAccess.Repository.IRepository;
using Ecomm_practice01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm_practice01.DataAccess.Repository
{
    public class CoverTypeRepository:Repository<CoverType>,ICoverTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public CoverTypeRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
    }
}
