using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.API.Models
{
    public class HangHoa
    {
        public Guid Id { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public Guid IdLoai { get; set; }
    }
}
