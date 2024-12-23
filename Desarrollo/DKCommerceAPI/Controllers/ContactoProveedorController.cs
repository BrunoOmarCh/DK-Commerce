using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/contactoProveedor")]

    public class ContactoProveedorController : ControllerBase
    {
        [HttpGet]// Método HTTP GET
        [Route("select-by-id/{idContactoProveedor}")]// Ruta en la web del método
        public ContactoProveedorBE SelectById(int idContactoProveedor)
        {
            var blContactoProveedor = new ContactoProveedorBL();

            return blContactoProveedor.SelectById(idContactoProveedor);
        }
    }
}
