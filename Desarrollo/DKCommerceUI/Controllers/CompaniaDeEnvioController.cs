﻿using AutoMapper;
using DKCommerceUI.Models;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{
    [Route("companiaDeEnvio")]

    public class CompaniaDeEnvioController : Controller
    {
            private IMapper _mapper;
            public CompaniaDeEnvioController()
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
        [Route("editar/{idCompaniaDeEnvio}")]
        public IActionResult Editar(int idCompaniaDeEnvio)
        {
            return View();
        }


        [HttpGet]
        [Route("select-by-id/{idCompaniaDeEnvio}")]
        public async Task<CompaniaDeEnvioModel> SelectById(int idCompaniaDeEnvio)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insert")]
        public async void Insert(string jsonCompaniaDeEnvio)
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
        [Route("update/{idCompaniaDeEnvio}")]
        public async Task Update(string idCompaniaDeEnvio, string jsonCompaniaDeEnvio)
        {


        }

        [HttpDelete]
        [Route("delete/{idCompaniaDeEnvio}")]
        public async Task Delete(int idCompaniaDeEnvio)
        {

        }
    }
}
