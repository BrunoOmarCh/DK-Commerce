using AutoMapper;
using DKCommerceUI.Models;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{
    [Route("companiaDeEnvio")]

    public class CompaniaDeEnvioController : Controller
    {
            private IMapper _mapper;
            public CompaniaDeEnvioController()
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
        [Route("select-by-id/{CompaniaDeEnvioId}")]
        public async Task<CompaniaDeEnvioModel> SelectById(int CompaniaDeEnviod)
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
        public async void Insert(string companiaDeEnvio)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }s

    }
}
