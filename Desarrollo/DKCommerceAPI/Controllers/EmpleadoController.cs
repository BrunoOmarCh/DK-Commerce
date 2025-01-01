using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/empleado")]
    public class EmpleadoController : ControllerBase
    {
        [HttpGet]
        [Route("select-by-id/{idEmpleado}")]
        public EmpleadoBE SelectById(int idEmpleado)
        {
            var blEmpleado = new EmpleadoBL();

            return blEmpleado.SelectById(idEmpleado);
        }

        [HttpPost]
        [Route("insert")]
        public void Insert(EmpleadoBE beEmpleado)
        {
            var blEmpleado = new EmpleadoBL();

            blEmpleado.Insert(beEmpleado);
        }

        [HttpPut]
        [Route("update/{idEmpleado}")]
        public void Update(int idEmpleado, EmpleadoBE beEmpleado)
        {
            var blEmpleado = new EmpleadoBL();

            blEmpleado.Update(idEmpleado, beEmpleado);
        }

        [HttpDelete]
        [Route("delete/{idEmpleado}")]
        public void Delete(int idEmpleado)
        {
            var blEmpleado = new EmpleadoBL();

            blEmpleado.Delete(idEmpleado);
        }
    }
}
