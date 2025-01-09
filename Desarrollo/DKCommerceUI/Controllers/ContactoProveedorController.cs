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
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("nuevo")]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpGet]
        [Route("select-by-id/{ContactoProveedorId}")]
        public async Task<ContactoClienteModel> SelectById(int ContactoProveedorId)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public async void Insert(string contactoProveedor)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
