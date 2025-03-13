using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class ParametroBL
    {
        public ParametroBE SelectById(string idParametro)
        {
            try
            {
                var daParametro = new ParametroDA();
                ParametroBE beParametro;

                beParametro = daParametro.SelectById(idParametro);
                return beParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
