using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DataAccessLayer.Entity;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class ProductRepository: IProductRepository
    {
        string connectionString = null;
        SqlConnection con = null;
        public ProductRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConnection");
            con = new SqlConnection(connectionString);
        }
        public void Registerproducts(Products reg)
        {
            try
            {
                var insertquery = $"exec Insertproducts '{reg.Name}',{reg.Price},{reg.OfferPrice},{reg.Netweight},'{reg.Expirydate}','{reg.Manufacture}'";
                con.Open();
                con.Execute(insertquery);
                con.Close();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void Updateproducts(Products reg)
        {
            try
            {
                var updatequery = $"exec Updateproducts {reg.Productid},'{reg.Name}',{ reg.Price},{ reg.OfferPrice},{ reg.Netweight},'{reg.Expirydate}','{reg.Manufacture}'";
                con.Open();
                con.Execute(updatequery);
                con.Close();
            }
            catch (Exception e)
            {
                 throw;
            }

               
        }
        
        public void Deleteproducts(long reg)
        {
            try
            {
                var Deletequery = $"exec Deleteproduct {reg}";
                con.Open();
                con.Execute(Deletequery);
                con.Close();
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public List<Products> ShowAllProducts()
        {
            try
            {
                var Selectall = $"exec Selectallproduct";
                con.Open();
                List<Products> result = con.Query<Products>(Selectall).ToList();
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public Products Showproductbyname(string name)
        {
            try
            {
                var SelectbyName = $"exec Selectproductbyname {name}";
                con.Open();
                Products results = con.QueryFirstOrDefault<Products>(SelectbyName);
                con.Close();
                return results;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
