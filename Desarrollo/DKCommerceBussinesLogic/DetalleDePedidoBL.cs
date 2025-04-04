﻿using DKCommerceBussinesEntity;
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
        public DetalleDePedidoBE SelectById(int idDetalleDePedido, int productoId)
        {
            try
            {
                var daDetalleDePedido = new DetalleDePedidoDA();
                DetalleDePedidoBE beDetalleDePedido;

                beDetalleDePedido = daDetalleDePedido.SelectById(idDetalleDePedido, productoId);
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
                var daDetalleDePedido = new DetalleDePedidoDA();
                daDetalleDePedido.Insert(beDetalleDePedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(int idDetalleDePedido, int productoId, DetalleDePedidoBE beDetalleDePedido)
        {
            try
            {
                var daDetalleDePedido = new DetalleDePedidoDA();
                daDetalleDePedido.Update(idDetalleDePedido, productoId, beDetalleDePedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int idDetalleDePedido, int productoId)
        {
            try
            {
                var daDetalleDePedido = new DetalleDePedidoDA();
                daDetalleDePedido.Delete(idDetalleDePedido, productoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

