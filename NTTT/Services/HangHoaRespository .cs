using NTTT.Controllers.Data;
using NTTT.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.Services
{
    public class HangHoaRespository : IHangHoaRespository
    {
        private readonly MyDbContext _context;

        public HangHoaRespository(MyDbContext context)
        {
            _context = context;
        }
        public List<HangHoaModel> GetAll(string search)
        {
            var allPruducts = _context.HangHoas.Where(hh => hh.TenHH.Contains(search));
            var result = allPruducts.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHH,
                TenHangHoa = hh.TenHH,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai.TenLoai
            });
            return result.ToList();
              
        }



    }
}
