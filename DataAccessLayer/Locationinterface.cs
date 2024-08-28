using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public interface ILocationinterface
    {
        public void insertlocation(Location value);
        public void Updatelocation(Location value);
        public void Deletelocation(long reg);
        public List<Location> selectalllocation();
        public Location selectbyid(int id);

    }
}
