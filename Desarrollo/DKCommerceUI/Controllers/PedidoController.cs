using AutoMapper;
using DKCommerceUI.Models;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{
    [Route("Pedido")]
    public class PedidoController : Controller
    {
        private IMapper _mapper;
        public PedidoController()
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
        [Route("editar/{idPedido}")]
        public IActionResult Editar(int idPedido)
        {           
            return View();
        }

        [HttpGet]
        [Route("select-by-id/{idPedido}")]
        public async Task<PedidoModel> SelectById(int idPedido)
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
        public async void Insert(string jsonPedido)
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
        [Route("update/{idPedido}")]
        public async Task Update(int idPedido, string jsonPedido)
        {


        }

        [HttpDelete]
        [Route("delete/{idPedido}")]
        public async Task Delete(int idPedido)
        {

        }
 
    }
}
