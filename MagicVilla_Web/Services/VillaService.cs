using MagicVilla_Utility;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private string _villaUrl;

        public VillaService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaCreateDTO dto)
        {
            return SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = _villaUrl + "/api/villaAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = _villaUrl + "/api/villaAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _villaUrl + "/api/villaAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _villaUrl + "/api/villaAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO dto)
        {
            return SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = _villaUrl + "/api/villaAPI/" + dto.Id
            });
        }
    }
}
