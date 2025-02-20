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
    [Route("contactoCliente")]

    public class ContactoClienteController : Controller
    {
        private IMapper _mapper;
        public ContactoClienteController()
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
        [Route("editar/{idContactoCliente}")]
        public async Task<IActionResult> Editar(int idContactoCliente)
        {
            var dtoContactoCliente = new ContactoClienteModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/contactocliente/select-by-id/" + idContactoCliente + "/");
                if (res.IsSuccessStatusCode)
                {
                    var mainContactoClienteResult = await res.Content.ReadAsStringAsync();
                    var beContactoCliente = JsonConvert.DeserializeObject<ContactoClienteBE>(mainContactoClienteResult);

                    dtoContactoCliente = _mapper.Map<ContactoClienteModel>(beContactoCliente);
                }
            }

            // Asignar todos los valores del modelo a ViewBag
            ViewBag.ContactoId = dtoContactoCliente.ContactoId;
            ViewBag.NombreContacto = dtoContactoCliente.NombreContacto;
            ViewBag.CargoContacto = dtoContactoCliente.CargoContacto;
            ViewBag.TipoDocumento = dtoContactoCliente.TipoDocumento;
            ViewBag.NroDocumento = dtoContactoCliente.NroDocumento;

            return View(dtoContactoCliente);
        }


        [HttpGet]
        [Route("select-by-id/{idContactoCliente}")]
        public async Task<ContactoClienteModel> SelectById(int idContactoCliente)
        {
            try
            {
                ContactoClienteModel dtoContactoCliente = null;
                ContactoClienteBE beContactoCliente = null;

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await cliente.GetAsync("api/contactoCliente/select-by-id/" + idContactoCliente + "/");
                    if (res.IsSuccessStatusCode)
                    {
                        var contactoClienteResult = res.Content.ReadAsStringAsync().Result;
                        beContactoCliente = JsonConvert.DeserializeObject<ContactoClienteBE>(contactoClienteResult)!;
                        dtoContactoCliente = _mapper.Map<ContactoClienteModel>(beContactoCliente);
                    }
                }
                return dtoContactoCliente;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("insert")]
        public async void Insert(string jsonContactoCliente)
        {
            try
            {
                var dtoContactoCliente = JsonConvert.DeserializeObject<ContactoClienteModel>(jsonContactoCliente);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceApi"));
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var beContactoCliente = _mapper.Map<ContactoClienteBE>(dtoContactoCliente);
                    var content = new StringContent(JsonConvert.SerializeObject(beContactoCliente), Encoding.UTF8, "application/json");
                    var res = await client.PostAsync("api/contactoCliente/insert", content);
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
        [Route("update/{idContactoCliente}")]
        public async Task Update(int idContactoCliente, string jsonContactoCliente)
        {
            var dtoContactoCliente = JsonConvert.DeserializeObject<ContactoClienteModel>(jsonContactoCliente);

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKComerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var beContactoCliente = _mapper.Map<ContactoClienteBE>(dtoContactoCliente);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(beContactoCliente), Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync("api/contactoCliente/update/" + idContactoCliente, jsonContent);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }


    }
}
