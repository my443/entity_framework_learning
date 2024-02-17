using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Learning
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly Birthdate { get; set; }        
        public ICollection<UserAccess> UserAccesses  { get; set; }      // A list of times a user access for the User. 
    }
}
