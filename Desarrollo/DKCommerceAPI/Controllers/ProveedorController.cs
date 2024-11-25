using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using DKCommerceDataAccess;
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

        [HttpPost]
        [Route("insert")]
        public void Insert(ProveedorBE beProveedor)
        {
            var blProveedor = new ProveedorBL();
            blProveedor.Insert(beProveedor);
        }

        [HttpPut]
        [Route("update/{proveedorId}")]
        public void Update(int proveedorId, ProveedorBE beProveedor)
        {
            var blProveedor = new ProveedorBL();
            blProveedor.Update(proveedorId, beProveedor);
        }

        [HttpDelete]
        [Route("delete/{ProveedorId}")]
        public void Delete(int ProveedorId)
        {
            var blProveedor = new ProveedorBL();
            blProveedor.Delete(ProveedorId);
        }


    }
}
