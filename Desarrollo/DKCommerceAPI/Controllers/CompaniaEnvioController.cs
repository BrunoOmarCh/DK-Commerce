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
    }
}
