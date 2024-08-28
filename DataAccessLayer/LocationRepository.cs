using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataAccessLayer
{
   public  class LocationRepository : ILocationinterface
    {
        LocationDbContext con = null;
        public LocationRepository(LocationDbContext reg)
        {
            con = reg;
        }
        public void insertlocation(Location value)
        {
            con.Add(value);
            con.SaveChanges();
            
        }
        public void Updatelocation(Location value)
        {
            con.Update(value);
            con.SaveChanges();
        }
        public void Deletelocation(long reg)
        {
            var count = con.Location.Find( reg);
            con.Remove(count);
            con.SaveChanges();
        }
        public List<Location> selectalllocation()
        {
            return con.Location.ToList();
        }
        public Location selectbyid(int id)
        {
            return con.Location.Find(id);
        }

    }

}
