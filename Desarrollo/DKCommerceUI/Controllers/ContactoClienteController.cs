﻿using AutoMapper;
using DKCommerceUI.Models;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{
    [Route("contactoCliente")]

    public class ContactoClienteController : Controller
    {
        private IMapper _mapper;
        public ContactoClienteController()
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
        [Route("select-by-id/{ContactoClienteId}")]
        public async Task<ContactoClienteModel> SelectById(int ContactoClienteId)
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
        public async void Insert(string contactoCliente)
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
        [Route("update/{idContactoCliente}")]
        public async Task Update(int idContactoCliente, string contactoCliente)
        {


        }

        [HttpDelete]
        [Route("delete/{idContactoCliente}")]
        public async Task Delete(int idContactoCliente)
        {

        }
    }
}
