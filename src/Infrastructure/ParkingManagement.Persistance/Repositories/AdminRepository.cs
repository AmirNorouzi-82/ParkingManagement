using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Domain;
using ParkingManagement.Persistance.Contexts;

namespace ParkingManagement.Persistance.Repositories
{
    internal class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private readonly ParkingDbContext _context;
        public AdminRepository(ParkingDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
