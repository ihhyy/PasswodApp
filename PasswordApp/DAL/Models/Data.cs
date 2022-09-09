using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public  class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Statuses Status { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
    }
}
