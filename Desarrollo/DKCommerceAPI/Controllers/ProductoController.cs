using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]// Método HTTP GET
        [Route("select-by-id/{idProducto}")]// Ruta en la web del método
        public ProductoBE SelectById(int idProducto)
        {
            var blProducto = new ProductoBL();

            return blProducto.SelectById(idProducto);
        }

    }
}
