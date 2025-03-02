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

                    var res = await cliente.GetAsync("api/parametro/select-by-id/" + stringParametro + "/");
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
        public async void Insert(string jsonParametro)
        {
            try
            {
                var dtoParametro = JsonConvert.DeserializeObject<ParametroModel>(jsonParametro);

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var beParametro = _mapper.Map<ParametroBE>(dtoParametro);
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(beParametro), Encoding.UTF8, "application/json");
                    var res = await cliente.PostAsync("api/parametro/insert", jsonContent);
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
        [Route("update/{stringParametro}")]
        public async Task Update(string stringParametro, string jsonParametro)
        {
            var dtoParametro = JsonConvert.DeserializeObject<ParametroModel>(jsonParametro);

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var beParametro = _mapper.Map<ParametroBE>(dtoParametro);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(beParametro), Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync("api/parametro/update/" + stringParametro, jsonContent);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }


    }
}
