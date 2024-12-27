using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/cliente")]

    public class ClienteController : ControllerBase
    {
        [HttpGet]// Método HTTP GET
        [Route("select-by-id/{idCliente}")]// Ruta en la web del método
        public ClienteBE SelectById(string idCliente)
        {
            var blCliente = new ClienteBL();

            return blCliente.SelectById(idCliente);
        }

        [HttpPost]
        [Route("insert")]
        public void Insert(ClienteBE beCliente)
        {
            var blCliente = new ClienteBL();

            blCliente.Insert(beCliente);
        }
        [HttpPut]
        [Route("update/{idCliente}")]
        public void Update(string idCliente, ClienteBE beCliente)
        {
            var blCliente = new ClienteBL();

            blCliente.Update(idCliente, beCliente);
        }

        [HttpDelete]
        [Route("delete/{idCliente}")]
        public void Delete(String idCliente)
        {
            var blCliente = new ClienteBL();

            blCliente.Delete(idCliente);
        }
    }
}
