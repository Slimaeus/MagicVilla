using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Repositories.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
