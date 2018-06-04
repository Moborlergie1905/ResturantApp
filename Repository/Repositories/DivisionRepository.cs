using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ResturantApp.DAL;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class DivisionRepository : Repository<Division>, IDivisionRepository
    {
        public DivisionRepository(RestaurantContext context) 
            : base(context)
        {
        }
    }
}
