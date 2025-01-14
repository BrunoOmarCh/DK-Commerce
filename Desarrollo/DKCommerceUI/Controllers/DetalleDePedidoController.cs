using AutoMapper;
using DKCommerceBussinesEntity;
using DKCommerceUI.Models;
using Libreria;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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
        [Route("editar/{idDetalleDePedido}")]
        public IActionResult Editar(int idDetalleDePedido)
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
