using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WASM.Services
{
    public interface IHangHoaService
    {
        Task<List<DTO.ViewHangHoa>> GetlistSV();
        Task<ViewHangHoa> GetId(Guid ma);
        Task<ViewHangHoa> Create(ViewHangHoa sv);
        Task<bool> Update(ViewHangHoa sv);
        Task<bool> Delete(Guid ma);
    }
}
