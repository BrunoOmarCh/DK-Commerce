using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/detalleDePedido")]

    public class DetalleDePedidoController : ControllerBase
    {
        [HttpGet]
        [Route("select-by-id/{idDetalleDePedido}/{productoId}")]
        public DetalleDePedidoBE SelectById(int idDetalleDePedido, int productoId)
        {
            var blDetalleDePedido = new DetalleDePedidoBL();

            return blDetalleDePedido.SelectById(idDetalleDePedido, productoId);
        }

        [HttpPost]
        [Route("insert")]
        public void Insert(DetalleDePedidoBE beDetalleDePedido)
        {
            var blDetalleDePedido = new DetalleDePedidoBL();

            blDetalleDePedido.Insert(beDetalleDePedido);
        }

        [HttpPut]
        [Route("update/{idDetalleDePedido}/{productoId}")]
        public void Update(int idDetalleDePedido, int productoId, DetalleDePedidoBE beDetalleDePedido)
        {
            var blDetalleDePedido = new DetalleDePedidoBL();

            blDetalleDePedido.Update(idDetalleDePedido,productoId, beDetalleDePedido);
        }

        [HttpDelete]
        [Route("delete/{idDetalleDePedido}/{productoId}")]
        public void Delete(int idDetalleDePedido, int productoId)
        {
            var blDetalleDePedido = new DetalleDePedidoBL();

            blDetalleDePedido.Delete(idDetalleDePedido, productoId);
        }
    }
}
