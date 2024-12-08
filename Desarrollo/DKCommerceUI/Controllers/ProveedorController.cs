using AutoMapper;
using Libreria;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DKCommerceUI.Controllers
{
    [Route("proveedor")]

    public class ProveedorController : Controller
    {
        private readonly IMapper _mapper;

        public ProveedorController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
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
        [Route("editar/{idProveedor}")]
        public async Task<IActionResult> Editar(int idProveedor)
        {
            ViewBag.ProveedorId = idProveedor;

            var dtoProveedor = new ProveedorModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("PlutonApi"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/proveedor/select-by-id/" + idProveedor + "/");
                if (res.IsSuccessStatusCode)
                {
                    var mainProductoResult = await res.Content.ReadAsStringAsync();
                    var beProveedor = JsonConvert.DeserializeObject<Proveedor>(mainProductoResult);

                    dtoProveedor = _mapper.Map<ProveedorModel>(beProveedor);
                }
            }

            ViewBag.Proveedor = dtoProveedor;
            ViewBag.Nombre = dtoProveedor.Nombre;
            ViewBag.Ruc = dtoProveedor.Ruc;
            ViewBag.ContactoId = dtoProveedor.ContactoId;
            ViewBag.Direccion = dtoProveedor.Direccion;
            ViewBag.Ciudad = dtoProveedor.Ciudad;
            ViewBag.Region = dtoProveedor.Region;
            ViewBag.CodPostal = dtoProveedor.CodPostal;
            ViewBag.Pais = dtoProveedor.Pais;
            ViewBag.Telefono = dtoProveedor.Telefono;
            ViewBag.Fax = dtoProveedor.Fax;
            ViewBag.PaginaPrincipal = dtoProveedor.PaginaPrincipal;

            return View(dtoProveedor);
        }

    }
}
