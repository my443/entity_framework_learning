using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Learning
{
    public class UserAccess
    {
        public int Id { get; set; } 
        public string AccessURL { get; set; }
        public DateTime TimeStamp { get; set; }
        public User User { get; set; }              // Relationship to User.
    }
}
