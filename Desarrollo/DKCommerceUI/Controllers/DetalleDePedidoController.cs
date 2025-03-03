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
    [Route("detalleDePedido")]

    public class DetalleDePedidoController : Controller
    {
        private IMapper _mapper;
        public DetalleDePedidoController()
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
        [Route("editar/{idDetalleDePedido}")]
        public async Task<IActionResult> Editar(int idDetalleDePedido)
        {
            var dtoDetalleDePedido = new DetalleDePedidoModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/detallepedido/select-by-id/" + idDetalleDePedido + "/");
                if (res.IsSuccessStatusCode)
                {
                    var mainDetalleResult = await res.Content.ReadAsStringAsync();
                    var beDetalleDePedido = JsonConvert.DeserializeObject<DetalleDePedidoBE>(mainDetalleResult);

                    dtoDetalleDePedido = _mapper.Map<DetalleDePedidoModel>(beDetalleDePedido);
                }
            }
            ViewBag.PedidoId = dtoDetalleDePedido.PedidoId;
            ViewBag.ProductoId = dtoDetalleDePedido.ProductoId;
            ViewBag.PrecioNeto = dtoDetalleDePedido.PrecioNeto;
            ViewBag.Cantidad = dtoDetalleDePedido.Cantidad;
            ViewBag.Descuento = dtoDetalleDePedido.Descuento;
            ViewBag.Igv = dtoDetalleDePedido.Igv;
            ViewBag.Isc = dtoDetalleDePedido.Isc;
            ViewBag.MontoSubTotal = dtoDetalleDePedido.MontoSubTotal;

            return View(dtoDetalleDePedido);
        }


        [HttpGet]
        [Route("select-by-id/{idDetalleDePedido}")]
        public async Task<DetalleDePedidoModel> SelectById(int idDetalleDePedido)
        {
            try
            {
                DetalleDePedidoModel dtoDetalleDePedido = null;
                DetalleDePedidoBE beDetalleDePedido = null;

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await cliente.GetAsync("api/detalleDePedido/select-by-id/" + idDetalleDePedido + "/");
                    if (res.IsSuccessStatusCode)
                    {
                        var DetalleDePedidoResult = res.Content.ReadAsStringAsync().Result;
                        beDetalleDePedido = JsonConvert.DeserializeObject<DetalleDePedidoBE>(DetalleDePedidoResult)!;
                        dtoDetalleDePedido = _mapper.Map<DetalleDePedidoModel>(beDetalleDePedido);
                    }
                }
                return dtoDetalleDePedido;            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public async void Insert(string jsonDetalleDePedido)
        {
            try
            {
                var dtoDetalleDePedido = JsonConvert.DeserializeObject<DetalleDePedidoModel>(jsonDetalleDePedido);

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var beDetalleDePedido = _mapper.Map<DetalleDePedidoBE>(dtoDetalleDePedido);
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(beDetalleDePedido), Encoding.UTF8, "application/json");
                    var res = await cliente.PostAsync("api/detalleDePedido/insert", jsonContent);
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
        [Route("update/{idDetalleDePedido}")]
        public async Task Update(int idDetalleDePedido, string jsonDetalleDePedido)
        {
            var dtoDetalleDePedido = JsonConvert.DeserializeObject<DetalleDePedidoModel>(jsonDetalleDePedido);

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var beDetalleDePedido = _mapper.Map<DetalleDePedidoBE>(dtoDetalleDePedido);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(beDetalleDePedido), Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync("api/detalleDePedido/update/" + idDetalleDePedido, jsonContent);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }

    }
}
