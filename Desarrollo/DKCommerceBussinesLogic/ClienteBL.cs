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

    }
}
