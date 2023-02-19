using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Models
{
    public class Address
    {
        
        public string City { get; set; }

        public string Details { get; set; }

        public List<Phone> Phone { get; set; }

        public User User { get; set; }
    }
}
