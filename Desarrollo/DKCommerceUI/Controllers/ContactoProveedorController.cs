using AutoMapper;
using DKCommerceUI.Models;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{

    [Route("ContactoProveedor")]
    public class ContactoProveedorController : Controller
    {
        private IMapper _mapper;
        public ContactoProveedorController()
        {
            var config = new MapperConfiguration(
                x =>
                {
                    x.AddProfile(new MappingProfile());
                }
                );
            _mapper = config.CreateMapper();

        }
    }
}
