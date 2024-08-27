using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IProductRepository
    {
        public void Registerproducts(Products reg);
        public void Updateproducts(Products reg);
        public void Deleteproducts(long reg);
        public List<Products> ShowAllProducts();
        public Products Showproductbyname(string name);



    }
}
