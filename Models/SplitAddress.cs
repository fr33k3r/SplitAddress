using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitAddresses.Models
{
    public class SplitAddress
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
