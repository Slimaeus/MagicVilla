﻿using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Repositories.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }
}
