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

        [HttpPost]
        [Route("insert")]
        public void Insert(ContactoProveedorBE beContactoProveedor)
        {
            //Nota
            // Verificar que los campos obligatorios de la base de datos esten completos.
            // Api Rest no siempre informa de los errores.
            var blContactoProveedor = new ContactoProveedorBL();

            blContactoProveedor.Insert(beContactoProveedor);
        }


        [HttpPut]
        [Route("update/{idContactoProveedor}")]
        public void Update(int idContactoProveedor, ContactoProveedorBE beContactoProveedor)
        {
            var blContactoProveedor = new ContactoProveedorBL();

            blContactoProveedor.Update(idContactoProveedor, beContactoProveedor);
        }



    }
}
