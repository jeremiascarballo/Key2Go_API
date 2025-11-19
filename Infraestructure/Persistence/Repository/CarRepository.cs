
using Application.Abstraction;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repository
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        private readonly Key2GoDbContext _context;
        public CarRepository(Key2GoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Car?> GetByLicensePlate(string licensePlate)
        {
            return await _context.Cars
                .FirstOrDefaultAsync(c => c.LicensePlate == licensePlate);
        }
    }
}
