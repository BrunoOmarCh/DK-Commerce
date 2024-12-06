using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using DKCommerceUI.Models;
using DKCommerceBussinesEntity;
using Libreria;



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
        public IActionResult Index()// Corresponde a una página web
        {
            return View();// Retorna una vista
            // Es decir
            // Devuelve la página web al navegador en la pc del usuario
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
            ViewBag.IdProducto = idProducto;
            ViewBag.Nombre = "Manzana Roja";
            ViewBag.Precio = 3.59;

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
        [HttpPost]
        [Route("insert")]
        public async Task Insert(string producto)// Si el método es asíncrono y no devuelve valor debe ser Task
        {
            try
            {
                var dtoProducto = JsonConvert.DeserializeObject<ProductoModel>(producto);

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // Pendiente: Convertir de Model a Entity
                    //Encoding.UTF8: Tipo de texto con tíldes y dieresis
                    var beProducto = _mapper.Map<ProductoBE>(dtoProducto);
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(beProducto), Encoding.UTF8, "application/json");
                    var res = await cliente.PostAsync("api/producto/insert", jsonContent);
                    if (!res.IsSuccessStatusCode)// Si el mensaje indica no éxito, disparar una excepción.
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
        [Route("update/{idProducto}")]
        public async Task Update(int idProducto, string producto)
        {
            var dtoProducto = JsonConvert.DeserializeObject<ProductoModel>(producto);

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var beProducto = _mapper.Map<ProductoBE>(dtoProducto);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(beProducto), Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync("api/producto/update/" + idProducto, jsonContent);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }

        [HttpDelete]
        [Route("delete/{idProducto}")]
        public async Task Delete(int idProducto)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("MercurioApi"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await cliente.DeleteAsync("api/producto/delete/" + idProducto + "/");
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }


    }
}
