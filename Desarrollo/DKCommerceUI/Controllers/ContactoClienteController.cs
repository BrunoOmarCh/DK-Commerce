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


    }
}
