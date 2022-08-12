using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTTT.Controllers.Data;
using NTTT.Services;
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
        private IHangHoaRepository _hh;
        public HangHoaController(IHangHoaRepository hangHoaRepository)
        {
            _hh = hangHoaRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<HangHoa> lst = _hh.GetAll();
            var alo = lst.Select(c=>new ViewHangHoa() {
                MaHH=c.MaHH,
                TenHH = c.TenHH,
                MoTa = c.MoTa,
                DonGia=c.DonGia,
                GiamGia=c.GiamGia,
                MaLoai=c.MaLoai
            });
            return Ok(alo);
        }

        [HttpGet]
        [Route("{ma}")]
        public IActionResult GetById(Guid ma)
        {
            HangHoa sinhVien = _hh.Getid(ma);
            if (sinhVien == null) return NotFound("Không tồn tại sinh viên này");
            ViewHangHoa alo = new ViewHangHoa();
            alo.MaHH = sinhVien.MaHH;
            alo.TenHH = sinhVien.TenHH;
            alo.MoTa = sinhVien.MoTa;
            alo.DonGia = sinhVien.DonGia;
            alo.GiamGia = sinhVien.GiamGia;
            alo.MaLoai = sinhVien.MaLoai;      
            return Ok(alo);
        }

        [HttpPost]
        public IActionResult Create(ViewHangHoa hangHoaVM)
        {            
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var a = _hh.Create(new HangHoa() { 
                MaHH=Guid.NewGuid(),
                TenHH=hangHoaVM.TenHH,
                MoTa=hangHoaVM.MoTa,
                DonGia=hangHoaVM.DonGia,
                GiamGia=hangHoaVM.GiamGia,
                MaLoai=hangHoaVM.MaLoai
            });
            return CreatedAtAction(nameof(Create), a);
        }

        [HttpPut]
        public IActionResult Edit(ViewHangHoa viewHangHoa)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _hh.Update(new HangHoa() {
                MaHH=viewHangHoa.MaHH,
                TenHH = viewHangHoa.TenHH,
                MoTa = viewHangHoa.MoTa,
                DonGia = viewHangHoa.DonGia,
                GiamGia = viewHangHoa.GiamGia,
                MaLoai = viewHangHoa.MaLoai
            });
            return Ok();
        }
        [HttpDelete]
        [Route("{ma}")]
        public IActionResult Delete(Guid ma)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _hh.Delete(ma);
            return Ok();
        }
    }
}
