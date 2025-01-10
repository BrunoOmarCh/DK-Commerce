using AutoMapper;
using DKCommerceUI.Models;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{
    [Route("parametro")]

    public class ParametroController : Controller
    {
        private IMapper _mapper;
        public ParametroController()
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
        [Route("select-by-id/{idParametro}")]
        public async Task<ParametroModel> SelectById(int idParametro)
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
        public async void Insert(string beParametro)
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
        [Route("update/{idParametro}")]
        public async Task Update(int idParametro, string beParametro)
        {


        }

        [HttpDelete]
        [Route("delete/{idParametro}")]
        public async Task Delete(int idParametro)
        {

        }
    }
}
