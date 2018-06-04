using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Customer
    {
        [Key]
        public int CusID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string OfficePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        [Required]
        public string Address { get; set; }

        public ICollection<Delivery> Delveries { get; set; }
    }
}
