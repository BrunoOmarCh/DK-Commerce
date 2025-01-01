using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/parametro")]
    public class ParametroController : ControllerBase
    {
        [HttpGet]// Método HTTP GET
        [Route("select-by-id/{idParametro}")]// Ruta en la web del método
        public ParametroBE SelectById(string idParametro)
        {
            var blParametro= new ParametroBL();

            return blParametro.SelectById(idParametro);
        }

        [HttpPost]
        [Route("insert")]
        public void Insert(ParametroBE beParametro)
        {
            var blParametro = new ParametroBL();

            blParametro.Insert(beParametro);
        }
        [HttpPut]
        [Route("update/{idParametro}")]
        public void Update(string idParametro, ParametroBE beParametro)
        {
            var blParametro = new ParametroBL();

            blParametro.Update(idParametro, beParametro);
        }

        [HttpDelete]
        [Route("delete/{idParametro}")]
        public void Delete(string idParametro)
        {
            var blParametro = new ParametroBL();

            blParametro.Delete(idParametro);
        }

    }
}
