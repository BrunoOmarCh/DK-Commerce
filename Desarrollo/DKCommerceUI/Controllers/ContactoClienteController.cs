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
        public IActionResult Editar(int idContactoCliente)
        {
            return View();
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


        }

        [HttpDelete]
        [Route("delete/{idContactoCliente}")]
        public async Task Delete(int idContactoCliente)
        {

        }
    }
}
