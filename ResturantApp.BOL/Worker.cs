using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Worker
    {
        public int WorkerID { get; set; }
        public string IdCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<LoginTrack> LoginTracks { get; set; }
    }
}
