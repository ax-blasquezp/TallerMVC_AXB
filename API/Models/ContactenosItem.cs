using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ContactenosItem
    {
        public long Id { get; set; }
        public String Email { get; set; }
        public String Asunto { get; set; }
        public String Mensaje { get; set; }
    }
}
