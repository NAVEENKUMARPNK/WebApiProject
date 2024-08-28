using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
   public  class Location
    {    
       [Key]
       [Required]
        public long LocationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public int PinCode { get; set; }
    }
}
