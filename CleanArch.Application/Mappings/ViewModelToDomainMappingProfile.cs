using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Domain.Entities;
using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() 
        {
            CreateMap<ProductViewModel, Product>();
        }
    }
}
