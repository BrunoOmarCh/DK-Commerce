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
        public async Task<IActionResult> Editar(string idCliente)
        {
            var dtoCliente = new ClienteModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/cliente/select-by-id/" + idCliente + "/");
                if (res.IsSuccessStatusCode)
                {
                    var mainResult = await res.Content.ReadAsStringAsync();
                    var beCliente = JsonConvert.DeserializeObject<ClienteBE>(mainResult);

                    dtoCliente = _mapper.Map<ClienteModel>(beCliente);
                }
            }

            ViewBag.ClienteId = dtoCliente.ClienteId;
            ViewBag.NombreRazonSocial = dtoCliente.NombreRazonSocial;
            ViewBag.TipoDocumento = dtoCliente.TipoDocumento;
            ViewBag.NroDocumento = dtoCliente.NroDocumento;
            ViewBag.ContactoId = dtoCliente.ContactoId;
            ViewBag.Direccion = dtoCliente.Direccion;
            ViewBag.Ciudad = dtoCliente.Ciudad;
            ViewBag.Region = dtoCliente.Region;
            ViewBag.CodPostal = dtoCliente.CodPostal;
            ViewBag.Pais = dtoCliente.Pais;
            ViewBag.Telefono = dtoCliente.Telefono;
            ViewBag.Fax = dtoCliente.Fax;

            return View(dtoCliente);
        }




    }
}
