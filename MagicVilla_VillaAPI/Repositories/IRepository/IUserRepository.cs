using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Repositories.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
