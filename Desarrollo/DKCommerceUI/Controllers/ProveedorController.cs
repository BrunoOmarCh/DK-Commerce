using AutoMapper;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{
    [Route("proveedor")]

    public class ProveedorController : Controller
    {
        private readonly IMapper _mapper;

        public ProveedorController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }

    }
}
