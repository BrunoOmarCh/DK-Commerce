using AutoMapper;
using DKCommerceUI.Models;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{
    [Route("detalleDePedido")]

    public class DetalleDePedidoController : Controller
    {
        private IMapper _mapper;
        public DetalleDePedidoController()
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
        [Route("select-by-id/{idDetalleDePedido}")]
        public async Task<DetalleDePedidoModel> SelectById(int idDetalleDePedido)
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
        public async void Insert(string jsonDetalleDePedido)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("update/{idDetalleDePedido}")]
        public async Task Update(int idDetalleDePedido, string jsonDetalleDePedido)
        {


        }

        [HttpDelete]
        [Route("delete/{idDetalleDePedido}")]
        public async Task Delete(int idDetalleDePedido)
        {

        }
    }
}
