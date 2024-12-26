using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper,IProductRepository repository) 
        {
            _mapper = mapper;
            _repository = repository;
        }

        async Task<IEnumerable<ProductViewModel>> IProductService.GetProducts()
        {
            var result = await _repository.GetProducts();
            return _mapper.Map<IEnumerable<ProductViewModel>>(result);
        }

        async Task<ProductViewModel> IProductService.GetById(int? id)
        {
            var result = await _repository.GetById(id);
            return _mapper.Map<ProductViewModel>(result);
        }

        void IProductService.Add(ProductViewModel product)
        {
            var mapProduct = _mapper.Map<Product>(product);
            _repository.Add(mapProduct);
        }

        void IProductService.Update(ProductViewModel product)
        {
            var mapProduct = _mapper.Map<Product>(product);
            _repository.Update(mapProduct);
        }

        void IProductService.Remove(int? id)
        { 
            _repository.Remove(id);
        }
    }
}
