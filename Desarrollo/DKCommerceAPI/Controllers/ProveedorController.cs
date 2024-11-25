using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/proveedor")]

    public class ProveedorController
    {
        [HttpGet]
        [Route("select-by-id/{ProveedorId}")]// Ruta en la web del método

        public ProveedorBE SelectById(int ProveedorId)
        {
            var blProveedor = new ProveedorBL();
            return blProveedor.SelectById(ProveedorId);

        }

    }
}
