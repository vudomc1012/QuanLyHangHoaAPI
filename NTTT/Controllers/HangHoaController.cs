﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTTT.Controllers.Models;
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
        public static List<HangHoa> hangHoas = new List<HangHoa>();

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
                var hangHoa = hangHoas.SingleOrDefault(sv => sv.MaHangHoa == Guid.Parse(id));
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
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
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
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                //LINQ[Object] Query
                var hangHoa = hangHoas.SingleOrDefault(c => c.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound("Không tìm thấy mã hàng hóa");
                }
                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                //Update
                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
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
                var hangHoa = hangHoas.SingleOrDefault(c => c.MaHangHoa == Guid.Parse(id));
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
