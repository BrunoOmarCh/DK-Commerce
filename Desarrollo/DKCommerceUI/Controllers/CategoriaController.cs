using AutoMapper;
using DKCommerceBussinesEntity;
using Libreria;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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
            Categoria beCategoria = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("MercurioApi"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/categoria/select-by-id" + categoriaId + "/");
                if (res.IsSuccessStatusCode)
                {
                    var categoriaResult = res.Content.ReadAsStringAsync().Result;// Se lee la respuesta
                    beCategoria = JsonConvert.DeserializeObject<Categoria>(categoriaResult)!;
                    dtoCategoria = _mapper.Map<CategoriaModel>(beCategoria);

                }
            }

            return dtoCategoria;
        }
    }
}
