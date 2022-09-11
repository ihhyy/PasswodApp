using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public  class Data
    {
        public int DataId { get; set; }
        public string Name { get; set; }
        public Statuses Status { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}
