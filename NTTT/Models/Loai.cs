using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.API.Models
{
    public class Loai
    {
        public Guid Id { get; set; }
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
    }
}
