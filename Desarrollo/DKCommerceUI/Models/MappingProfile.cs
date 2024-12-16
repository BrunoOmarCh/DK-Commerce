using AutoMapper;
using DKCommerceBussinesEntity;
using DKCommerceUI.Models;

namespace MercurioUI.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductoModel, ProductoBE>();
            CreateMap<ProductoBE, ProductoModel>();

            CreateMap<ProveedorModel, ProveedorBE>();
            CreateMap<ProveedorBE, ProveedorModel>();

            CreateMap<CategoriaModel,CategoriaBE>();
            CreateMap<CategoriaBE, CategoriaModel>();

        }
    }
}
