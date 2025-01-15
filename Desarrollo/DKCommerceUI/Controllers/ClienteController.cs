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
    [Route("cliente")]
    public class ClienteController : Controller
    {
        private IMapper _mapper;
        public ClienteController()
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
        [Route("editar/{idCliente}")]
        public IActionResult Editar(string idCliente)
        {
            return View();
        }

        [HttpGet]
        [Route("select-by-id/{clienteId}")]
        public async Task<ClienteModel> SelectById(string ClienteId)
        {
            try
            {
                ClienteModel dtoCliente = null;
                ClienteBE beCliente = null;

                using (var cliente = new HttpClient())
                {

                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await cliente.GetAsync("api/cliente/select-by-id/" + ClienteId + "/");
                    if (res.IsSuccessStatusCode)
                    {
                        var ClienteResult = res.Content.ReadAsStringAsync().Result;
                        beCliente = JsonConvert.DeserializeObject<ClienteBE>(ClienteResult)!;
                        dtoCliente = _mapper.Map<ClienteModel>(beCliente);
                    }
                }
                return dtoCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public async void Insert(string jsonCliente)
        {
            try
            {
                var dtoCliente= JsonConvert.DeserializeObject<ClienteModel>(jsonCliente);

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var beCliente = _mapper.Map<ClienteBE>(dtoCliente);
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(beCliente), Encoding.UTF8, "application/json");
                    var res = await cliente.PostAsync("api/cliente/insert", jsonContent);
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
        [Route("update/{idCliente}")]
        public async Task Update(string idCliente, string jsonCliente)
        {
            var dtoCliente = JsonConvert.DeserializeObject<ClienteModel>(jsonCliente);

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var beCliente = _mapper.Map<ClienteBE>(dtoCliente);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(beCliente), Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync("api/cliente/update/" + idCliente, jsonContent);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }

        [HttpDelete]
        [Route("delete/{idCliente}")]
        public async Task Delete(string idCliente)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await cliente.DeleteAsync("api/cliente/delete/" + idCliente + "/");
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }
    }
}
