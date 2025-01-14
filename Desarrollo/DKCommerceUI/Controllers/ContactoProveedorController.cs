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

    [Route("contactoProveedor")]
    public class ContactoProveedorController : Controller
    {
        private IMapper _mapper;
        public ContactoProveedorController()
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
        [Route("editar/{idContactoProveedor}")]
        public IActionResult Editar(int idContactoProveedor)
        {
            return View();
        }

        [HttpGet]
        [Route("select-by-id/{idContactoProveedor}")]
        public async Task<ContactoProveedorModel> SelectById(int idContactoProveedor)
        {
            try
            {
                ContactoProveedorModel dtoContactoProveedor = null;
                ContactoProveedorBE beContactoProveedor = null;

                using (var cliente = new HttpClient())
                {

                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await cliente.GetAsync("api/contactoProveedor/select-by-id/" + idContactoProveedor + "/");
                    if (res.IsSuccessStatusCode)
                    {
                        var ContactoProveedorResult = res.Content.ReadAsStringAsync().Result;
                        beContactoProveedor = JsonConvert.DeserializeObject<ContactoProveedorBE>(ContactoProveedorResult)!;
                        dtoContactoProveedor = _mapper.Map<ContactoProveedorModel>(beContactoProveedor);
                    }
                }
                return dtoContactoProveedor;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public async void Insert(string jsonContactoProveedor)
        {
            try
            {
                var dtoContactoProveedor = JsonConvert.DeserializeObject<ContactoProveedorModel>(jsonContactoProveedor);

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var beContactoProveedor = _mapper.Map<ContactoProveedorBE>(dtoContactoProveedor);
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(beContactoProveedor), Encoding.UTF8, "application/json");
                    var res = await cliente.PostAsync("api/contactoProveedor/insert", jsonContent);
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
        [Route("update/{idContactoProveedor}")]
        public async Task Update(int idContactoProveedor, string  jsonContactoProveedor)
        {
            var dtoContactoProveedor = JsonConvert.DeserializeObject<ContactoProveedorModel>(jsonContactoProveedor);

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var beContactoProveedor = _mapper.Map<ContactoProveedorBE>(dtoContactoProveedor);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(beContactoProveedor), Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync("api/contactoProveedor/update/" + idContactoProveedor, jsonContent);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }

        [HttpDelete]
        [Route("delete/{idContactoProveedor}")]
        public async Task Delete(int idContactoProveedor)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await cliente.DeleteAsync("api/contactoProveedor/delete/" + idContactoProveedor + "/");
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }
    }
}
