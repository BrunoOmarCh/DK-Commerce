using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class ClienteBL
    {
        public ClienteBE SelectById(string clienteId)
        {
            try
            {
                var daCliente = new ClienteDA();
                ClienteBE beCliente;

                beCliente = daCliente.SelectById(clienteId);
                return beCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert(ClienteBE beCliente)
        {
            try
            {
                var daCliente = new ClienteDA();
                daCliente.Insert(beCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(string clienteId, ClienteBE beCliente)
        {
            try
            {
                var daCliente = new ClienteDA();
                daCliente.Update(clienteId, beCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
