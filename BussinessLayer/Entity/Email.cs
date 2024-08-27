using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Entity
{
     public class EmailRequest
    {
        public string FromAddress { get; set; }
        public string Password { get; set; }
        public string ToAddress { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

    }
}
