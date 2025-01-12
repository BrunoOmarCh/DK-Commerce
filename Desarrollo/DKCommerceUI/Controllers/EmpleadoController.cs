﻿using AutoMapper;
using DKCommerceBussinesEntity;
using DKCommerceUI.Models;
using Libreria;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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
        public IActionResult Editar(int idEmpleado)
        {
            return View();
        }

        [HttpGet]
        [Route("select-by-id/{idEmpleado}")]
        public async Task<EmpleadoModel> SelectById(int idEmpleado)
        {
            try
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
                            var empleadoResult = res.Content.ReadAsStringAsync().Result;
                            beEmpleado = JsonConvert.DeserializeObject<EmpleadoBE>(empleadoResult)!;
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


        }

        [HttpDelete]
        [Route("delete/{idEmpleado}")]
        public async Task Delete(int idEmpleado)
        {

        }
    }
}
