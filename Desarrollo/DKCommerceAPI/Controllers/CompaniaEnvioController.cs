using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/companiaEnvio")]
    public class CompaniaEnvioController : ControllerBase
    {
        [HttpGet]
        [Route("select-by-id/{idCompaniaEnvio}")]
        public CompaniaEnvioBE SelectById(int idCompaniaEnvio)
        {
            var blCompaniaEnvio = new CompaniaEnvioBL();

            return blCompaniaEnvio.SelectById(idCompaniaEnvio);
        }

        [HttpPost]
        [Route("insert")]
        public void Insert(CompaniaEnvioBE beCompaniaEnvio)
        {
            var blCompaniaEnvio = new CompaniaEnvioBL();

            blCompaniaEnvio.Insert(beCompaniaEnvio);
        }
        [HttpPut]
        [Route("update/{idCompaniaEnvio}")]
        public void Update(int idCompaniaEnvio, CompaniaEnvioBE beCompaniaEnvio)
        {
            var blCompaniaEnvio = new CompaniaEnvioBL();

            blCompaniaEnvio.Update(idCompaniaEnvio, beCompaniaEnvio);
        }

        [HttpDelete]
        [Route("delete/{idCompaniaEnvio}")]
        public void Delete(int idComapaniaEnvio)
        {
            var blCompaniaEnvio = new CompaniaEnvioBL();

            blCompaniaEnvio.Delete(idComapaniaEnvio);
        }
    }
}
}
