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
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/proveedor/select-by-id/" + idProveedor + "/");
                if (res.IsSuccessStatusCode)
                {
                    var mainProductoResult = await res.Content.ReadAsStringAsync();
                    var beProveedor = JsonConvert.DeserializeObject<ProveedorBE>(mainProductoResult);

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

        [HttpGet]
        [Route("select-by-id/{proveedorId}")]
        public async Task<ProveedorModel> SelectById(int proveedorId)
        {
            try
            {
                ProveedorModel dtoProveedor = null;
                ProveedorBE beProveedor = null;

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await cliente.GetAsync("api/proveedor/select-by-id/" + proveedorId + "/");
                    if (res.IsSuccessStatusCode)
                    {
                        var proveedorResult = await res.Content.ReadAsStringAsync();
                        beProveedor = JsonConvert.DeserializeObject<ProveedorBE>(proveedorResult)!;
                        dtoProveedor = _mapper.Map<ProveedorModel>(beProveedor);
                    }
                }
                return dtoProveedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public async Task Insert(string jsonProveedor)
        {
            try
            {
                var dtoProveedor = JsonConvert.DeserializeObject<ProveedorModel>(jsonProveedor);
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var beProveedor = _mapper.Map<ProveedorBE>(dtoProveedor);
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(beProveedor), Encoding.UTF8, "application/json");

                    var res = await cliente.PostAsync("api/proveedor/insert", jsonContent);
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
        [HttpDelete]
        [Route("delete/{proveedorId}")]
        public async Task Delete(int proveedorId)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await cliente.DeleteAsync("api/proveedor/delete/" + proveedorId + "/");
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }

    }
}
