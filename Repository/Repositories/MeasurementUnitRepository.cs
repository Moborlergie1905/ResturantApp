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
    public class MeasurementUnitRepository : Repository<MeasurementUnit>, IMeasurementUnitRepository
    {
        public MeasurementUnitRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
