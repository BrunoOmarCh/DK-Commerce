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
    [Route("empleado")]

    public class EmpleadoController : Controller
    {
        private IMapper _mapper;
        public EmpleadoController()
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
        [Route("editar/{idEmpleado}")]
        public async Task<IActionResult> Editar(int idEmpleado)
        {
            var dtoEmpleado = new EmpleadoModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/empleado/select-by-id/" + idEmpleado + "/");
                if (res.IsSuccessStatusCode)
                {
                    var mainEmpleadoResult = await res.Content.ReadAsStringAsync();
                    var beEmpleado = JsonConvert.DeserializeObject<EmpleadoBE>(mainEmpleadoResult);

                    dtoEmpleado = _mapper.Map<EmpleadoModel>(beEmpleado);
                }
            }
            ViewBag.EmpleadoId = dtoEmpleado.EmpleadoId;
            ViewBag.Nombres = dtoEmpleado.Nombres;
            ViewBag.ApellidoPaterno = dtoEmpleado.ApellidoPaterno;
            ViewBag.ApellidoMaterno = dtoEmpleado.ApellidoMaterno;
            ViewBag.TipoDocIdentidad = dtoEmpleado.TipoDocIdentidad;
            ViewBag.NroDocIdentidad = dtoEmpleado.NroDocIdentidad;
            ViewBag.Cargo = dtoEmpleado.Cargo;
            ViewBag.Tratamiento = dtoEmpleado.Tratamiento;
            ViewBag.FechaNacimiento = dtoEmpleado.FechaNacimiento;
            ViewBag.FechaContratación = dtoEmpleado.FechaContratación;
            ViewBag.Dirección = dtoEmpleado.Dirección;
            ViewBag.Ciudad = dtoEmpleado.Ciudad;
            ViewBag.Región = dtoEmpleado.Región;
            ViewBag.CodPostal = dtoEmpleado.CodPostal;
            ViewBag.Pais = dtoEmpleado.Pais;
            ViewBag.TelefonoFijo = dtoEmpleado.TelefonoFijo;
            ViewBag.Anexo = dtoEmpleado.Anexo;
            ViewBag.Notas = dtoEmpleado.Notas;
            ViewBag.JefeId = dtoEmpleado.JefeId;
            ViewBag.Email = dtoEmpleado.Email;
            ViewBag.EstadoCivil = dtoEmpleado.EstadoCivil;

            return View(dtoEmpleado);
        }


        [HttpGet]
        [Route("select-by-id/{idEmpleado}")]
        public async Task<EmpleadoModel> SelectById(int idEmpleado)
        {
            try
            {
                EmpleadoModel dtoEmpleado = null;
                EmpleadoBE beEmpleado = null;

                using (var cliente = new HttpClient())
                {

                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await cliente.GetAsync("api/empleado/select-by-id/" + idEmpleado + "/");
                    if (res.IsSuccessStatusCode)
                    {
                        var EmpleadoResult = res.Content.ReadAsStringAsync().Result;
                        beEmpleado = JsonConvert.DeserializeObject<EmpleadoBE>(EmpleadoResult)!;
                        dtoEmpleado = _mapper.Map<EmpleadoModel>(beEmpleado);
                    }
                }
                return dtoEmpleado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public async void Insert(string jsonEmpleado)
        {
            try
            {
                var dtoEmpleado = JsonConvert.DeserializeObject<EmpleadoModel>(jsonEmpleado);

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var beEmpleado = _mapper.Map<EmpleadoBE>(dtoEmpleado);
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(beEmpleado), Encoding.UTF8, "application/json");
                    var res = await cliente.PostAsync("api/empleado/insert", jsonContent);
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
        [Route("update/{idEmpleado}")]
        public async Task Update(int idEmpleado, string jsonEmpleado)
        {
            var dtoEmpleado = JsonConvert.DeserializeObject<EmpleadoModel>(jsonEmpleado);

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var beEmpleado = _mapper.Map<EmpleadoBE>(dtoEmpleado);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(beEmpleado), Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync("api/empleado/update/" + idEmpleado, jsonContent);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }
        [HttpDelete]
        [Route("delete/{idEmpleado}")]
        public async Task Delete(int idEmpleado)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await cliente.DeleteAsync("api/empleado/delete/" + idEmpleado + "/");
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }
    }
}
