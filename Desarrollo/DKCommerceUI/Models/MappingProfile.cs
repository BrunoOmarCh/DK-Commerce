using AutoMapper;
using DKCommerceBussinesEntity;
using DKCommerceUI.Models;

namespace MercurioUI.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoriaModel,CategoriaBE>();
            CreateMap<CategoriaBE, CategoriaModel>();

            CreateMap<ClienteModel, ClienteBE>();
            CreateMap<ClienteBE, ClienteModel>();

            CreateMap<CompaniaDeEnvioModel, CompaniaEnvioBE>();
            CreateMap<CompaniaEnvioBE, CompaniaDeEnvioModel>();
            
            CreateMap<ContactoClienteModel, ContactoClienteBE>();
            CreateMap<ContactoClienteBE, ContactoClienteModel>();

            CreateMap<ContactoProveedorModel, ContactoProveedorBE>();
            CreateMap<ContactoProveedorBE, ContactoProveedorModel>();

            CreateMap<DetalleDePedidoModel, DetalleDePedidoBE>();
            CreateMap<DetalleDePedidoBE, DetalleDePedidoModel>();

            CreateMap<EmpleadoModel, EmpleadoBE>();
            CreateMap<EmpleadoBE, EmpleadoModel>();

            CreateMap<ParametroModel, ParametroBE>();
            CreateMap<ParametroBE, ParametroModel>();

            CreateMap<ProductoModel, ProductoBE>();
            CreateMap<ProductoBE, ProductoModel>();

            CreateMap<ProveedorModel, ProveedorBE>();
            CreateMap<ProveedorBE, ProveedorModel>();

        }
    }
}
