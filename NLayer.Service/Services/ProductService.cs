using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UOWs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUOW uow, IProductRepository productRepo, IMapper mapper) : base(repository, uow)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var product=await _productRepo.GetProductsWithCategory();
            var productDto = _mapper.Map<List<ProductWithCategoryDto>>(product);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Succsess(200, productDto);
        }
    }
}
