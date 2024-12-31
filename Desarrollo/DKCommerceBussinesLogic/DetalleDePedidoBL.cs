using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class DetalleDePedidoBL
    {
        public DetalleDePedidoBE SelectById(int idDetalleDePedido)
        {
            try
            {
                var daDetalleDePedido = new DetalleDePedidoDA();
                DetalleDePedidoBE beDetalleDePedido;

                beDetalleDePedido = daDetalleDePedido.SelectById(idDetalleDePedido);
                return beDetalleDePedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(DetalleDePedidoBE beDetalleDePedido)
        {
            try
            {
                var daDetalleDePedido= new DetalleDePedidoDA();
                daDetalleDePedido.Insert(beDetalleDePedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(int idDetalleDePedido, DetalleDePedidoBE beDetalleDePedido)
        {
            try
            {
                var daDetalleDePedido = new DetalleDePedidoDA();
                daDetalleDePedido.Update(idDetalleDePedido, beDetalleDePedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int idDetalleDePedido)
        {
            try
            {
                var daDetalleDePedidoBE = new DetalleDePedidoDA();
                daDetalleDePedido.Delete(idDetalleDePedidoBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
}
