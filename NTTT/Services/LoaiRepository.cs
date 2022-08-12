using NTTT.Controllers.Data;
using NTTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.Services
{
   
    public class LoaiRepository : ILoaiRepository
    {
      private readonly  MyDbContext _context;
        public LoaiRepository(MyDbContext context)
        {
            _context = context;
        }
       
    }
}
