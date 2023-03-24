﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Succsess(200, productDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Succsess(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto pdto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(pdto));
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Succsess(201, productDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto pudto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(pudto));
            return CreateActionResult(CustomResponseDto<NoContentResponseDto>.Succsess(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentResponseDto>.Succsess(204));
        }
    }
}
