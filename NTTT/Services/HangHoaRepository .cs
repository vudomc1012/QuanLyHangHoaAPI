using Microsoft.EntityFrameworkCore;
using NTTT.Controllers.Data;
using NTTT.Controllers.Models;
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
        public List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1)
        {
            var allPruducts = _context.HangHoas.Include(hh => hh.Loai).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {

                allPruducts = allPruducts.Where(hh => hh.TenHH.Contains(search));
            }
            #region Tìm kiếm theo tên, giá 
            if (to.HasValue)
            {
                allPruducts = allPruducts.Where(hh => hh.DonGia <= to);
            }

            if (from.HasValue)
            {
                allPruducts = allPruducts.Where(hh => hh.DonGia >= from);
            }

            #endregion
            #region sắp xếp
            //Sawps xếp theo tên
            allPruducts = allPruducts.OrderBy(hh => hh.TenHH);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "tenhh_desc":
                        allPruducts = allPruducts.OrderByDescending(hh => hh.TenHH);
                        break;
                    case "gia_asc":
                        allPruducts = allPruducts.OrderBy(hh => hh.DonGia);
                        break;
                    case "gia_desc":
                        allPruducts = allPruducts.OrderByDescending(hh => hh.DonGia);
                        break;
                }
            }
            #endregion
            //#region Phân trang
            //allPruducts = allPruducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            //var result = allPruducts.Select(hh => new HangHoaModel
            //{
            //    MaHangHoa = hh.MaHH,
            //    TenHangHoa = hh.TenHH,
            //    DonGia = hh.DonGia,
            //    TenLoai = hh.Loai.TenLoai
            //});
            //return result.ToList();

            var result = PaginatedList<NTTT.Controllers.Data.HangHoa>.Create(allPruducts, page, PAGE_SIZE);
            return result.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHH,
                TenHangHoa = hh.TenHH,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai?.TenLoai
            }).ToList();
        }



    }
}
