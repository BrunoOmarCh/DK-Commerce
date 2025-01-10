using AutoMapper;
using DKCommerceUI.Models;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;

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
        [Route("select-by-id/{EmpleadoId}")]
        public async Task<EmpleadoModel> SelectById(int EmpleadoId)
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
        public async void Insert(string empleado)
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
        public async Task Update(int idEmpleado, string empleado)
        {


        }

        [HttpDelete]
        [Route("delete/{idEmpleado}")]
        public async Task Delete(int idEmpleado)
        {

        }
    }
}
