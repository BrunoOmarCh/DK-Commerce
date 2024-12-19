using DKCommerceBussinesEntity;
using DKCommerceBussinesLogic;
using DKCommerceDataAccess;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("select-by-id/{categoriaId}")]
        public CategoriaBE SelectById(int categoriaId)
        {
            var blCategoria = new CategoriaBL();

            return blCategoria.SelectById(categoriaId);
        }

        [HttpPost]
        [Route("insert")]
        public void Insert(CategoriaBE beCategoria)
        {
            var blCategoria = new CategoriaBL();

            blCategoria.Insert(beCategoria);
        }
        [HttpPut]
        [Route("update/{CategoriaId}")]
        public void Update(int CategoriaId, CategoriaBE beCategoria)
        {
            var blCategoria = new CategoriaBL();

            blCategoria.Update(CategoriaId, beCategoria);
        }

    }
}
