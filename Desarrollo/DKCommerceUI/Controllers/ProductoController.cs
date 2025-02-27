using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using DKCommerceUI.Models;
using DKCommerceBussinesEntity;
using Libreria;
using MercurioUI.Models;



namespace DKCommerceUI.Controllers
{
    [Route("producto")]

    public class ProductoController : Controller
    {
        private readonly IMapper _mapper;// Se define una interfaz para realizar el mapeo

        public ProductoController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            _mapper = config.CreateMapper();
        }


        [HttpGet]
        [Route("Index")]
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
        [Route("editar/{idProducto}")]
        public IActionResult Editar(int idProducto)
        {
            return View();
        }


        [HttpGet]
        [Route("select-by-id/{idProducto}")]
        public async Task<ProductoModel> SelectById(int idProducto)
        {
            try
            {
                // El pedido de un objeto ProductoModel se lo realizará desde la web, desde un código JavaScript
                ProductoModel dtoProducto = null;
                ProductoBE beProducto = null;

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));// Lee la url de la Api desde el archivo de configuracion
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));// Será un objeto JSON

                    var res = await cliente.GetAsync("api/producto/select-by-id/" + idProducto + "/");
                    if (res.IsSuccessStatusCode)
                    {
                        //ReadAsStringAsync: el producto la Api lo convierte en string y lo envia a través de la web en ese formato
                        var productoResult = res.Content.ReadAsStringAsync().Result;
                        //DeserializeObject<ProductoModel>: Convierte el string en el objeto indicado
                        beProducto = JsonConvert.DeserializeObject<ProductoBE>(productoResult)!;
                        dtoProducto = _mapper.Map<ProductoModel>(beProducto);
                    }
                }

                return dtoProducto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
