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
        [Route("select-by-id/{stringParametro}")]
        public async Task<ParametroModel> SelectById(string stringParametro)
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
        [Route("update/{stringParametro}")]
        public async Task Update(string stringParametro, string beParametro)
        {


        }

        [HttpDelete]
        [Route("delete/{stringParametro}")]
        public async Task Delete(string stringParametro)
        {

        }
    }
}
