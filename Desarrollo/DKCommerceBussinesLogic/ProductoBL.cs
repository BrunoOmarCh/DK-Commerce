using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class ProductoBL
    {
        public ProductoBE SelectById(int idProducto)
        {
            try
            {
                var daProducto = new ProductoDA();
                ProductoBE beProducto;

                beProducto = daProducto.SelectById(idProducto);
                return beProducto;
            }
            catch (Exception ex)
            {       
                throw ex;
            }
        }

    }
}
