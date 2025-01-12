﻿using AutoMapper;
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
    [Route("Pedido")]
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
        public IActionResult Editar(int idPedido)
        {           
            return View();
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
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));// Será un objeto JSON

                    var res = await cliente.GetAsync("api/pedido/select-by-id/" + idPedido+ "/");
                    if (res.IsSuccessStatusCode)
                    {
                        //ReadAsStringAsync: el producto la Api lo convierte en string y lo envia a través de la web en ese formato
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
        [Route("update/{idPedido}")]
        public async Task Update(int idPedido, string jsonPedido)
        {

            var dtoPedido= JsonConvert.DeserializeObject<PedidoModel>(jsonPedido);

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var bePedido = _mapper.Map<PedidoBE>(dtoPedido);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(bePedido), Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync("api/pedido/update/" + idPedido, jsonContent);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }


        }

        [HttpDelete]
        [Route("delete/{idPedido}")]
        public async Task Delete(int idPedido)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("DKCommerceAPI"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await cliente.DeleteAsync("api/pedido/delete/" + idPedido + "/");
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }

    }
}
