using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantApp.BOL
{
    public class Production
    {
        [Key]
        public int ProdID { get; set; }
        public ProductionType ProductionType { get; set; }
        [ForeignKey("InventoryItem")]
        public int InvItemId { get; set; }
        public DateTime ProdDate { get; set; }
        public int Qty { get; set; }

        public virtual ICollection<ProductionIngredient> Ingredients { get; set; }       
        public virtual InventoryItem InventoryItem { get; set; }
    }
}
