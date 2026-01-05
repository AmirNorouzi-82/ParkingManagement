using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagement.Domain;

namespace ParkingManagement.Application.Contracts.Persistance
{
    public interface IParkingSpotRepository : IGenericRepository<ParkingSpot>
    {
    }
}
