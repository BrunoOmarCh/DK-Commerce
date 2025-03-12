using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class ContactoClienteBL
    {
        public ContactoClienteBE SelectById(int idContactoCliente)
        {
            try
            {
                var daContactoCliente = new ContactoClienteDA();
                ContactoClienteBE beContactoCliente;

                beContactoCliente = daContactoCliente.SelectById(idContactoCliente);
                return beContactoCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(ContactoClienteBE beContactoCliente)
        {
            try
            {
                var daContactoCliente = new ContactoClienteDA();
                daContactoCliente.Insert(beContactoCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
