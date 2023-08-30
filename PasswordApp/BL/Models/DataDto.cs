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
        public string SecretName { get; set; }
        public Statuses Status { get; set; }
        public string? SecretValue { get; set; }
        public int? SecretLength { get; set; }
    }
}
