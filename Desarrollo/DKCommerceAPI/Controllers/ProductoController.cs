using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using DKCommerceDataAccess;
using Libreria;
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

        [HttpGet]
        [Route("paginacion/{texto}/{tamañoPagina}/{nroPagina}/{nombreColumna}/{orderBy}")]
        public List<ProductoBE> Paginacion(string texto, int tamañoPagina,
            int nroPagina, string nombreColumna, string orderBy)
        {
            var blProducto = new ProductoBL();
            bool? bOrderBy;

            bOrderBy = Conversiones.ToNullableBool(orderBy);

            return blProducto.Paginacion(texto, tamañoPagina, nroPagina, nombreColumna, bOrderBy);
        }

        [HttpPut]
        [Route("update/{idProducto}")]
        public void Update(int idProducto, ProductoBE beProducto)
        {
            var blProducto = new ProductoBL();

            blProducto.Update(idProducto, beProducto);
        }

        [HttpDelete]
        [Route("delete/{idProducto}")]
        public void Delete(int idProducto)
        {
            var blProducto = new ProductoBL();

            blProducto.Delete(idProducto);
        }

    }
}
