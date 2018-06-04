using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Division
    {
        [Key]
        public int divID { get; set; }
        [DisplayName("Division")]
        public string Name { get; set; }
        [ForeignKey("Category")]
        public int CatId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
