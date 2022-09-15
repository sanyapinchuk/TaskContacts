using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string JobTtile { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
