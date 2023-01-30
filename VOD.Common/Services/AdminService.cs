using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD.Common.Services
{
    public class AdminService : IAdminService
    {
         readonly MembershipHttpClient _http;

        public AdminService(MembershipHttpClient http)
        {
            _http = http;
        }

        public async Task<List<TDto>> GetAsync<TDto>(string uri)
        {
            try
            {
                using HttpResponseMessage response = await _http.Client.GetAsync(uri);// $"courses?freeOnly=false");
                response.EnsureSuccessStatusCode();

                var result = JsonSerializer.Deserialize<List<TDto>>(await response.Content.ReadAsStreamAsync(),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return new List<TDto>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<TDto> SingleAsync<TDto>(string uri)
        {
            try
            {
                using HttpResponseMessage response = await _http.Client.GetAsync(uri);// $"courses?freeOnly=false");
                response.EnsureSuccessStatusCode();

                var result = JsonSerializer.Deserialize<TDto>(await response.Content.ReadAsStreamAsync(),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return default;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task CreateAsync<TDto>(string uri, TDto dto)
        {
            try
            {
                using StringContent jsonContent = new( JsonSerializer.Serialize(dto),Encoding.UTF8,"application/json");
                using HttpResponseMessage response = await _http.Client.PostAsync(uri, jsonContent);
                response.EnsureSuccessStatusCode();
            }

            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task EditAsync<TDto>(string uri, TDto dto)
        {
            try
            {
                using StringContent jsonContent = new(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
                using HttpResponseMessage response = await _http.Client.PutAsync(uri, jsonContent);
                response.EnsureSuccessStatusCode();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task DeleteAsync<TDto>(string uri)
        {
            try
            {
                
                using HttpResponseMessage response = await _http.Client.DeleteAsync(uri);
                response.EnsureSuccessStatusCode();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
