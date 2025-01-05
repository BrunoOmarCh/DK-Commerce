using AutoMapper;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{
    [Route("cliente")]
    public class ClienteController : Controller
    {
        private IMapper _mapper;
        public ClienteController()
        {
            /*var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();*/

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
