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
        [Route("editar/{idParametro}")]
        public IActionResult Editar(int idParametro)
        {
            return View();
        }

        [HttpGet]
        [Route("select-by-id/{stringParametro}")]
        public async Task<ParametroModel> SelectById(string stringParametro)
        {
            try
            {
                ParametroModel dtoParametro = null;
                ParametroBE beParametro = null;

                using (var cliente = new HttpClient())
                {

                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await cliente.GetAsync("api/parametro/select-by-id/" + stringParametro+ "/");
                    if (res.IsSuccessStatusCode)
                    {
                        var ParametroResult = res.Content.ReadAsStringAsync().Result;
                        beParametro = JsonConvert.DeserializeObject<ParametroBE>(ParametroResult)!;
                        dtoParametro = _mapper.Map<ParametroModel>(beParametro);
                    }
                }
                return dtoParametro;

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
