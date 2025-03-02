using AutoMapper;
using DKCommerceBussinesEntity;
using DKCommerceUI.Models;
using Libreria;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

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
        [Route("editar/{stringParametro}")]
        public async Task<IActionResult> Editar(string stringParametro)
        {
            var dtoParametro = new ParametroModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/parametro/select-by-clave/" + stringParametro + "/");
                if (res.IsSuccessStatusCode)
                {
                    var mainParametroResult = await res.Content.ReadAsStringAsync();
                    var beParametro = JsonConvert.DeserializeObject<ParametroBE>(mainParametroResult);

                    dtoParametro = _mapper.Map<ParametroModel>(beParametro);
                }
            }
            ViewBag.Clave = dtoParametro.Clave;
            ViewBag.Grupo = dtoParametro.Grupo;
            ViewBag.Valor = dtoParametro.Valor;

            return View(dtoParametro);
        }

    }
}
