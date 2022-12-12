using CORS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CORS.Web.Services
{
    public class ProductAPI:IProductAPI
    {
        private readonly HttpClient _httpClient;
        public ProductAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<CreateProductDto>> List()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CreateProductDto>>("http://localhost:29706/api/Product/GetAll");
            return response;
        }
        public async Task<CreateProductDto> Find(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CreateProductDto>($"http://localhost:29706/api/Product/Get?id={id}");
            return response;
        }

        public async Task<CreateProductDto> Add(CreateProductDto createProductDto)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:29706/api/Product/Create", createProductDto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CreateProductDto>();
            return responseBody;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:29706/api/Product/Remove?id={id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> Update(CreateProductDto createProductDto)
        {
            var response = await _httpClient.PutAsJsonAsync("http://localhost:29706/api/Product/Update", createProductDto);
            return response.IsSuccessStatusCode;
        }
    }
}
