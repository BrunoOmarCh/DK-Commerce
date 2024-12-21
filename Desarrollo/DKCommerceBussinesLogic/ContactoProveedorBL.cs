using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class ContactoProveedorBL
    {
        public ContactoProveedorBE SelectById(int idContactoProveedor)
        {
            try
            {
                var daContactoProveedor = new ContactoProveedorDA();
                ContactoProveedorBE beContactoProveedor;

                beContactoProveedor = daContactoProveedor.SelectById(idContactoProveedor);
                return beContactoProveedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
