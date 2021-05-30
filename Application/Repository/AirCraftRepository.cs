using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class AirCraftRepository : IAircraftRepository
    {
        private readonly IApplicationDbContext _context;

        public AirCraftRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(AirCraft entity)
        {
            await _context.AirCrafts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return 1;
        }
        public async Task<int> Delete(int id)
        {
            var entity = await _context.AirCrafts.FindAsync(id);
            if (entity == null)
            {
                return 0;
            }
            _context.AirCrafts.Remove(entity);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<AirCraft> Get(int id)
        {
            return await _context.AirCrafts.FindAsync(id);
        }

        public async Task<IEnumerable<AirCraft>> GetAll()
        {
            return await _context.AirCrafts.ToListAsync();
        }

        public async Task<int> Update(AirCraft AirCraftEntity)
        {
            var result = await _context.AirCrafts.FirstOrDefaultAsync(e => e.Id == AirCraftEntity.Id);

            if (result != null)
            {
                //result.Id = AirCraftEntity.Id;        
                result.Make = AirCraftEntity.Make;
                result.Model = AirCraftEntity.Model;
                result.Registration = AirCraftEntity.Registration;
                result.Location = AirCraftEntity.Location;
                result.IsActive = AirCraftEntity.IsActive;
                result.CreatedDate = AirCraftEntity.CreatedDate;
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }
}

