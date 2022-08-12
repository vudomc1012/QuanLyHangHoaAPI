using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTT.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Massage { get; set; }
        public object Data { get; set; }
    }
}
