using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTTT.Models;
using NTTT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly ILoaiRepository _loaiRepository;
        public LoaiController(ILoaiRepository loaiRepository)
        {
            _loaiRepository = loaiRepository;
        }        

    }
}
