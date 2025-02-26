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

    }
}
