using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IAircraftRepository
    {
        Task<AirCraft> Get(int id);
        Task<IEnumerable<AirCraft>> GetAll();
        Task<int> Add(AirCraft entity);
        Task<int> Delete(int id);
        Task<int> Update(AirCraft AirCraftEntity);
    }
}
