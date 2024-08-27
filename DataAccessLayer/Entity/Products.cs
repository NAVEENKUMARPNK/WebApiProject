using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Products
    {
        public long Productid { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OfferPrice { get; set; }
        public decimal Netweight { get; set; }
        public DateTime Expirydate { get; set; }

        public DateTime Manufacture { get; set; }


    }
}
