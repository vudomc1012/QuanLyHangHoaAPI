using Microsoft.EntityFrameworkCore;
using NTTT.Controllers.Data;
using NTTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.Services
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private readonly MyDbContext _context;

        public static int PAGE_SIZE { get; set; } = 5;

        public HangHoaRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<HangHoa> GetAll()
        {
            return _context.HangHoas.ToList();
        }

        public bool Create(HangHoa hangHoa)
        {
            if (hangHoa == null) return false;
            _context.HangHoas.Add(hangHoa);
            _context.SaveChanges();
            return true;
        }

        public bool Update(HangHoa hangHoa)
        {
            if (hangHoa == null) return false;
            _context.HangHoas.Update(hangHoa);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Guid ma)
        {
            HangHoa hangHoa = _context.HangHoas.FirstOrDefault(c => c.MaHH == ma);
            if (hangHoa == null) return false;
            _context.HangHoas.Remove(hangHoa);
            _context.SaveChanges();
            return true;
        }

        public HangHoa Getid(Guid ma)
        {
            return _context.HangHoas.FirstOrDefault(c => c.MaHH == ma);
        }
    }
}
