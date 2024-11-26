using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using DKCommerceDataAccess;
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

        [HttpPost]
        [Route("insert")]
        public void Insert(ProductoBE beProducto)
        {
            //Nota
            // Verificar que los campos obligatorios de la base de datos esten completos.
            // Api Rest no siempre informa de los errores.
            var blProducto = new ProductoBL();

            blProducto.Insert(beProducto);
        }

    }
}
