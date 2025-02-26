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




        [HttpGet]
        [Route("select-by-id/{idCompaniaDeEnvio}")]
        public async Task<CompaniaDeEnvioModel> SelectById(int idCompaniaDeEnvio)
        {
            try
            {
                CompaniaDeEnvioModel dtoCompaniaDeEnvio = null;
                CompaniaEnvioBE beCompaniaDeEnvio = null;

                using (var cliente = new HttpClient())
                {

                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await cliente.GetAsync("api/companiaDeEnvio/select-by-id/" + idCompaniaDeEnvio + "/");
                    if (res.IsSuccessStatusCode)
                    {
                        var CompaniaDeEnvioResult = res.Content.ReadAsStringAsync().Result;
                        beCompaniaDeEnvio = JsonConvert.DeserializeObject<CompaniaEnvioBE>(CompaniaDeEnvioResult)!;
                        dtoCompaniaDeEnvio = _mapper.Map<CompaniaDeEnvioModel>(beCompaniaDeEnvio);
                    }
                }
                return dtoCompaniaDeEnvio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public async void Insert(string jsonCompaniaDeEnvio)
        {
            try
            {

                var dtoCompaniaDeEnvio = JsonConvert.DeserializeObject<CompaniaDeEnvioModel>(jsonCompaniaDeEnvio);

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var beCompaniaDeEnvio = _mapper.Map<ParametroBE>(dtoCompaniaDeEnvio);
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(beCompaniaDeEnvio), Encoding.UTF8, "application/json");
                    var res = await cliente.PostAsync("api/companiaDeEnvio/insert", jsonContent);
                    if (!res.IsSuccessStatusCode)
                    {
                        throw new Exception(res.StatusCode.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Route("update/{idCompaniaDeEnvio}")]
        public async Task Update(string idCompaniaDeEnvio, string jsonCompaniaDeEnvio)
        {
            var dtoCompaniaDeEnvio = JsonConvert.DeserializeObject<CompaniaDeEnvioModel>(jsonCompaniaDeEnvio);

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var beCompaniaDeEnvio = _mapper.Map<CompaniaEnvioBE>(dtoCompaniaDeEnvio);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(beCompaniaDeEnvio), Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync("api/companiaDeEnvio/update/" + idCompaniaDeEnvio, jsonContent);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }

    }
}
