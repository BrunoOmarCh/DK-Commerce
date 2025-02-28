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
    [Route("pedido")]
    public class PedidoController : Controller
    {
        private IMapper _mapper;
        public PedidoController()
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
        [Route("editar/{idPedido}")]
        public async Task<IActionResult> Editar(int idPedido)
        {
            ViewBag.PedidoId = idPedido;
            var dtoPedido = new PedidoModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("api/pedido/select-by-id/" + idPedido + "/");
                if (res.IsSuccessStatusCode)
                {
                    var mainPedidoResult = await res.Content.ReadAsStringAsync();
                    var bePedido = JsonConvert.DeserializeObject<PedidoBE>(mainPedidoResult);

                    dtoPedido = _mapper.Map<PedidoModel>(bePedido);
                }
            }
            ViewBag.Pedido = dtoPedido;
            ViewBag.ClienteId = dtoPedido.ClienteId;
            ViewBag.IdEmpleado = dtoPedido.IdEmpleado;
            ViewBag.FechaPedido = dtoPedido.FechaPedido;
            ViewBag.FechaEntrega = dtoPedido.FechaEntrega;
            ViewBag.FechaEnvío = dtoPedido.FechaEnvío;
            ViewBag.FormaEnvío = dtoPedido.FormaEnvío;
            ViewBag.Igv = dtoPedido.Igv;
            ViewBag.Isc = dtoPedido.Isc;
            ViewBag.MontoTotal = dtoPedido.MontoTotal;
            ViewBag.Destinatario = dtoPedido.Destinatario;
            ViewBag.DirecciónDestinatario = dtoPedido.DirecciónDestinatario;
            ViewBag.CiudadDestinatario = dtoPedido.CiudadDestinatario;
            ViewBag.RegiónDestinatario = dtoPedido.RegiónDestinatario;
            ViewBag.CódPostalDestinatario = dtoPedido.CódPostalDestinatario;
            ViewBag.PaísDestinatario = dtoPedido.PaísDestinatario;

            return View(dtoPedido);
        }


        [HttpGet]
        [Route("select-by-id/{idPedido}")]
        public async Task<PedidoModel> SelectById(int idPedido)
        {
            try
            {
                PedidoModel dtoPedido = null;
                PedidoBE bePedido = null;

                using (var cliente = new HttpClient())
                {

                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var res = await cliente.GetAsync("api/pedido/select-by-id/" + idPedido + "/");
                    if (res.IsSuccessStatusCode)
                    {
                        var pedidoResult = res.Content.ReadAsStringAsync().Result;
                        bePedido = JsonConvert.DeserializeObject<PedidoBE>(pedidoResult)!;
                        dtoPedido = _mapper.Map<PedidoModel>(bePedido);
                    }
                }
                return dtoPedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public async void Insert(string jsonPedido)
        {
            try
            {
                var dtoPedido = JsonConvert.DeserializeObject<PedidoModel>(jsonPedido);

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var bePedido = _mapper.Map<PedidoBE>(dtoPedido);
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(bePedido), Encoding.UTF8, "application/json");
                    var res = await cliente.PostAsync("api/pedido/insert", jsonContent);
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


    }
}
