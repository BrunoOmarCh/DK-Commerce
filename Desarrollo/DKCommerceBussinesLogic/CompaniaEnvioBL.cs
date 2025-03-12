using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class CompaniaEnvioBL
    {
        public CompaniaEnvioBE SelectById(int idCompaniaEnvio)
        {
            try
            {
                var daCompaniaEnvio = new CompaniaEnvioDA();
                CompaniaEnvioBE beCompaniaEnvio;

                beCompaniaEnvio = daCompaniaEnvio.SelectById(idCompaniaEnvio);
                return beCompaniaEnvio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert(CompaniaEnvioBE beCompaniaEnvio)
        {
            try
            {
                var daCompaniaEnvio = new CompaniaEnvioDA();
                daCompaniaEnvio.Insert(beCompaniaEnvio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(int idCompaniaEnvio, CompaniaEnvioBE beCompaniaEnvio)
        {
            try
            {
                var daCompaniaEnvio = new CompaniaEnvioDA();
                daCompaniaEnvio.Update(idCompaniaEnvio, beCompaniaEnvio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
