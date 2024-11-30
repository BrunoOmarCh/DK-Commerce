using AutoMapper;
using DKCommerceBussinesEntity;
using DKCommerceUI.Models;
using MercurioBE;

namespace MercurioUI.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductoModel, ProductoBE>();
            CreateMap<ProductoBE, ProductoModel>();

            CreateMap<Categoria, CategoriaModel>();
            CreateMap<CategoriaModel, CategoriaModel>();

            CreateMap<ClienteModel, Cliente>();
            CreateMap<Cliente, ClienteModel>();

            CreateMap<CompañiaDeEnvioModel, CompañiaDeEnvio>();
            CreateMap<CompañiaDeEnvio, CompañiaDeEnvioModel>();

            CreateMap<ProveedorModel, Proveedor>();
            CreateMap<Proveedor, ProveedorModel>();
        }
    }
}
