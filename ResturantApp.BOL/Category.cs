using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }
        [Display(Name="Category")]
        [Required(ErrorMessage ="Enter Category")]
        public string Name { get; set; }

        public virtual ICollection<Division> Divisions { get; set; }
    }
}
