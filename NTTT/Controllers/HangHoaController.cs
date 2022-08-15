using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTTT.API.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<ViewHangHoa> hangHoas = new List<ViewHangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                //LINQ[Object] Query
                var hangHoa = hangHoas.SingleOrDefault(sv => sv.MaHH == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(ViewHangHoa hangHoaVM)
        {
            var hanghoa = new ViewHangHoa
            {
                MaHH = Guid.NewGuid(),
                TenHH = hangHoaVM.TenHH,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, ViewHangHoa hangHoaEdit)
        {
            try
            {
                //LINQ[Object] Query
                var hangHoa = hangHoas.SingleOrDefault(c => c.MaHH == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound("Không tìm thấy mã hàng hóa");
                }
                if (id != hangHoa.MaHH.ToString())
                {
                    return BadRequest();
                }
                //Update
                hangHoa.TenHH = hangHoaEdit.TenHH;
                hangHoa.DonGia = hangHoaEdit.DonGia;
                return Ok("Bạn đã sửa thành cmn công");
            }
            catch
            {
                return BadRequest();
            }        
        }
        [HttpDelete("{id}")]
        public IActionResult Remove (string id)
        {
            try
            {
                //LINQ[Object] Query
                var hangHoa = hangHoas.SingleOrDefault(c => c.MaHH == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                //Delete
                hangHoas.Remove(hangHoa);
                return Ok(hangHoas);                   
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
