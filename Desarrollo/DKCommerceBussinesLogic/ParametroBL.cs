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

        public void Insert(ParametroBE beParametro)
        {
            try
            {
                var daParametro = new ParametroDA();
                daParametro.Insert(beParametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(string idParametro, ParametroBE beParametro)
        {
            try
            {
                var daParametro= new ParametroDA();
                daParametro.Update(idParametro, beParametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(string idParametro)
        {
            try
            {
                var daParametro = new ParametroDA();
                daParametro.Delete(idParametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
