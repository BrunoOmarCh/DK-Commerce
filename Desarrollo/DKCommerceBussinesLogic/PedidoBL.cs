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
        public void Insert(PedidoBE bePedido)
        {
            try
            {
                var daPedido = new PedidoDA();
                daPedido.Insert(bePedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(int idPedido, PedidoBE bePedido)
        {
            try
            {
                var daPedido = new PedidoDA();

                daPedido.Update(idPedido, bePedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int idPedido)
        {
            try
            {
                var daPedido = new PedidoDA();

                daPedido.Delete(idPedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
