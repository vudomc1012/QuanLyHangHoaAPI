﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTTT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHangHoaRepository _hangHoaRepository;

        public ProductsController(IHangHoaRepository hangHoaRepository)
        {
            _hangHoaRepository = hangHoaRepository;
        }

        //[HttpGet]
        //public IActionResult GetAllProducts(string search, double? from, double? to, string sortBy, int page = 1)
        //{
        //    try
        //    {
        //        var result = _hangHoaRepository.GetAll(search, from, to, sortBy,page);
        //        return Ok(result);
        //    }
        //    catch
        //    {

        //        return BadRequest("Không tìm thấy sản phẩm !");
        //    }
        //}
    }
}
