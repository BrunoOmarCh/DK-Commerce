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
    [Route("categoria")]
    public class CategoriaController : Controller
    {
        private IMapper _mapper;
        public CategoriaController()
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
        [Route("editar/{idCategoria}")]
        public async Task<IActionResult> Editar(int idCategoria)
        {
            var dtoCategoria = new CategoriaModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/categoria/select-by-id/" + idCategoria + "/");
                if (res.IsSuccessStatusCode)
                {
                    var mainResult = await res.Content.ReadAsStringAsync();
                    var beCategoria = JsonConvert.DeserializeObject<CategoriaBE>(mainResult);

                    dtoCategoria = _mapper.Map<CategoriaModel>(beCategoria);
                }
            }

            ViewBag.CategoriaId = dtoCategoria.CategoriaId;
            ViewBag.Nombre = dtoCategoria.Nombre;
            ViewBag.Descripcion = dtoCategoria.Descripcion;
            ViewBag.Suspendido = dtoCategoria.Suspendido;

            return View(dtoCategoria);
        }

        [HttpGet]
        [Route("select-by-id/{idCategoria}")]
        public async Task<CategoriaModel> SelectById(int idCategoria)
        {
            try
            {
                CategoriaModel dtoCategoria = null;
                CategoriaBE beCategoria = null;

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await cliente.GetAsync("api/categoria/select-by-id/" + idCategoria + "/");
                    if (res.IsSuccessStatusCode)
                    {
                        var categoriaResult = res.Content.ReadAsStringAsync().Result;
                        beCategoria = JsonConvert.DeserializeObject<CategoriaBE>(categoriaResult)!;
                        dtoCategoria = _mapper.Map<CategoriaModel>(beCategoria);
                    }
                }
                return dtoCategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public async void Insert(string jsonCategoria)// Javascript esta enviando un string por un método Ajax
        {
            try
            { 
                var dtoCategoria = JsonConvert.DeserializeObject<CategoriaModel>(jsonCategoria);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceApi"));
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var beCategoria = _mapper.Map<CategoriaBE>(dtoCategoria);
                    var content = new StringContent(JsonConvert.SerializeObject(beCategoria), Encoding.UTF8, "application/json");
                    var res = await client.PostAsync("api/categoria/insert", content);
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
        [Route("update/{idCategoria}")]
        public async Task Update(int idCategoria, string jsonCategoria)
        {
            var dtoCategoria = JsonConvert.DeserializeObject<CategoriaModel>(jsonCategoria);

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKComerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var beCategoria = _mapper.Map<CategoriaBE>(dtoCategoria);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(beCategoria), Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync("api/categoria/update/" + idCategoria, jsonContent);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }

        [HttpDelete]
        [Route("delete/{idCategoria}")]
        public async Task Delete(int idCategoria)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await cliente.DeleteAsync("api/categoria/delete/" + idCategoria + "/");
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }
    }
}
