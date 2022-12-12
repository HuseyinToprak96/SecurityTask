using CORS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORS.Web.Services
{
    public interface IProductAPI
    {
        Task<List<CreateProductDto>> List();
        Task<CreateProductDto> Find(int id);
        Task<CreateProductDto> Add(CreateProductDto createProductDto);
        Task<bool> Delete(int id);
        Task<bool> Update(CreateProductDto createProductDto);
    }
}
