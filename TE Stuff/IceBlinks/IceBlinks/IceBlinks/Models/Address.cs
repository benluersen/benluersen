using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceBlinks.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string UserAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int UserId { get; set; }
    }
}
