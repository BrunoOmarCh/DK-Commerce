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
        [Route("select-by-id/{idDetalleDePedido}")]
        public DetalleDePedidoBE SelectById(int idDetalleDePedido)
        {
            var blDetalleDePedido = new DetalleDePedidoBL();

            return blDetalleDePedido.SelectById(idDetalleDePedido);
        }

        [HttpPost]
        [Route("insert")]
        public void Insert(DetalleDePedidoBE beDetalleDePedido)
        {
            var blDetalleDePedido = new DetalleDePedidoBL();

            blDetalleDePedido.Insert(beDetalleDePedido);
        }


    }
}
