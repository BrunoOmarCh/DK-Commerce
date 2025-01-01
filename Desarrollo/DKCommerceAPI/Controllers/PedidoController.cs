using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        [HttpGet]
        [Route("select-by-id/{idPedido}")]
        public PedidoBE SelectById(int idPedido)
        {
            var blPedido = new PedidoBL();

            return blPedido.SelectById(idPedido);
        }

        [HttpPost]
        [Route("insert")]
        public void Insert(PedidoBE bePedido)
        {
            var blPedido = new PedidoBL();

            blPedido.Insert(bePedido);
        }

        [HttpPut]
        [Route("update/{idPedido}")]
        public void Update(int idPedido, PedidoBE bePedido)
        {
            var blPedido = new PedidoBL();

            blPedido.Update(idPedido, bePedido);
        }

        [HttpDelete]
        [Route("delete/{idPedido}")]
        public void Delete(int idPedido)
        {
            var blPedido = new PedidoBL();

            blPedido.Delete(idPedido);
        }
    }
}
