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
        private IMapper _mapper;// IMapper: Es una interfaz, es decir, permite 'herededar' de una clase adicional

        public CategoriaController()
        {
            var config = new MapperConfiguration(
                x =>
                {
                    x.AddProfile(new MappingProfile());
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
            return View();// Vista -> Página web
        }
        [HttpGet]
        [Route("select-by-id/{categoriaId}")]
        public async Task<CategoriaModel> SelectById(int categoriaId)
        {
            CategoriaModel dtoCategoria = null;
            CategoriaBE beCategoria = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceApi"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/categoria/select-by-id" + categoriaId + "/");
                if (res.IsSuccessStatusCode)
                {
                    var categoriaResult = res.Content.ReadAsStringAsync().Result;// Se lee la respuesta
                    beCategoria = JsonConvert.DeserializeObject<CategoriaBE>(categoriaResult)!;
                    dtoCategoria = _mapper.Map<CategoriaModel>(beCategoria);

                }
            }

            return dtoCategoria;
        }
        [HttpPost]
        [Route("insert")]
        public async void Insert(string categoria)// Javascript esta enviando un string por un método Ajax
        {
            var dtoCategoria = JsonConvert.DeserializeObject<CategoriaModel>(categoria);
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
    }
}
