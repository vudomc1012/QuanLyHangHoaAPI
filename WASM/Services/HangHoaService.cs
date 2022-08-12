using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WASM.Services
{
    public class HangHoaService:IHangHoaService
    {
        public HttpClient _httpClient;
        public HangHoaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ViewHangHoa> Create(ViewHangHoa sv)
        {
            var alo = await _httpClient.PostAsJsonAsync("/api/HangHoa", sv);
            return sv;
        }
        

        public async Task<bool> Delete(Guid ma)
        {
            var sv = await _httpClient.DeleteAsync($"/api/HangHoa/{ma}");
            return true;
        }

        

        public async Task<ViewHangHoa> GetId(Guid ma)
        {
            var sv = await _httpClient.GetFromJsonAsync<ViewHangHoa>($"/api/HangHoa/{ma}");
            return sv;
        }

        public async Task<List<DTO.ViewHangHoa>> GetlistSV()
        {
            var sv = await _httpClient.GetFromJsonAsync<List<DTO.ViewHangHoa>>("/api/HangHoa");
            return sv;
        }

        public async Task<bool> Update(ViewHangHoa sv)
        {
            var sv1 = await _httpClient.PutAsJsonAsync("/api/HangHoa", sv);
            return true;
        }
    }
}
