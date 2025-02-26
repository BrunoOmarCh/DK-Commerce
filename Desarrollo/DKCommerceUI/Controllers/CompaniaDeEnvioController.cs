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
        [Route("editar/{idCompaniaDeEnvio}")]
        public async Task<IActionResult> Editar(int idCompaniaDeEnvio)
        {
            var dtoCompaniaDeEnvio = new CompaniaDeEnvioModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/companiadeenvio/select-by-id/" + idCompaniaDeEnvio + "/");
                if (res.IsSuccessStatusCode)
                {
                    var mainResult = await res.Content.ReadAsStringAsync();
                    var beCompaniaDeEnvio = JsonConvert.DeserializeObject<CompaniaEnvioBE>(mainResult);

                    dtoCompaniaDeEnvio = _mapper.Map<CompaniaDeEnvioModel>(beCompaniaDeEnvio);
                }
            }

            ViewBag.CompañiaDeEnvioId = dtoCompaniaDeEnvio.CompañiaDeEnvioId;
            ViewBag.NombreCompañia = dtoCompaniaDeEnvio.NombreCompañia;
            ViewBag.Ruc = dtoCompaniaDeEnvio.Ruc;
            ViewBag.Telefono = dtoCompaniaDeEnvio.Telefono;

            return View(dtoCompaniaDeEnvio);
        }



    }
}
