using NTTT.API.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.Services
{
    public interface IHangHoaRepository 
    { 
        List<HangHoa> GetAll(string search, double? from, double? to, string sortBy, int page = 1);
    }
}
