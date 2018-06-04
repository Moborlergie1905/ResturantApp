using ResturantApp.BOL;
using ResturantApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class AdjustmentRepository : Repository<Adjustment>, IAdjustmentRepository
    {
        public AdjustmentRepository(RestaurantContext context) 
            : base(context)
        {
        }       
    }
}
