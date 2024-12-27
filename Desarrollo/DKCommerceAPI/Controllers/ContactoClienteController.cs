using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/contactoCliente")]
    public class ContactoClienteController : ControllerBase
    {
        [HttpGet]
        [Route("select-by-id/{idContactoCliente}")]
        public ContactoClienteBE SelectById(int idContactoCliente)
        {
            var blContactoCliente= new ContactoClienteBL();

            return blContactoCliente.SelectById(idContactoCliente);
        }

        [HttpPost]
        [Route("insert")]
        public void Insert(ContactoClienteBE beContactoCliente)
        {
            var blContactoCliente = new ContactoClienteBL();

            blContactoCliente.Insert(beContactoCliente);
        }

    }
}
