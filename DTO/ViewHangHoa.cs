using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ViewHangHoa
    {
        public Guid MaHH { get; set; }        
        public string TenHH { get; set; }
        public string MoTa { get; set; }       
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        public int? MaLoai { get; set; }        
    }
}
