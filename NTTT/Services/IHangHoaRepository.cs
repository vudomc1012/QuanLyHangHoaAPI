using NTTT.Controllers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.Services
{
    public interface IHangHoaRepository 
    { 
        List<HangHoa> GetAll();
        bool Create(HangHoa hangHoa);
        bool Update(HangHoa hangHoa);
        bool Delete(Guid ma);
        HangHoa Getid(Guid ma);
    }
}
