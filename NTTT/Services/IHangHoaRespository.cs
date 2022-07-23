using NTTT.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.Services
{
    public interface IHangHoaRespository 
    { 
        List<HangHoaModel> GetAll(string search);
        List<HangHoaModel> GetAll(string search);
        List<HangHoaModel> GetAll(string search);
    }
}
