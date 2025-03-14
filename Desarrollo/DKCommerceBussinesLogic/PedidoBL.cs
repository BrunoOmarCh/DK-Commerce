using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class PedidoBL
    {
        public PedidoBE SelectById(int idPedido)
        {
            try
            {
                var daPedido = new PedidoDA();
                PedidoBE bePedido;

                bePedido = daPedido.SelectById(idPedido);
                return bePedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
