using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class DataDto
    {
        public string Name { get; set; }
        public Statuses Status { get; set; }
        public string? Password { get; set; }
        public int? SecretLength { get; set; }
    }
}
