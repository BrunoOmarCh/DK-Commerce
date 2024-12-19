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
        [HttpGet]// Método HTTP GET
        [Route("select-by-id/{idCategoria}")]// Ruta en la web del método
        public CategoriaBE SelectById(int idCategoria)
        {
            var blCategoria = new CategoriaBL();

            return blCategoria.SelectById(idCategoria);
        }


        [HttpPost]
        [Route("insert")]
        public void Insert(CategoriaBE beCategoria)
        {
            //Nota
            // Verificar que los campos obligatorios de la base de datos esten completos.
            // Api Rest no siempre informa de los errores.
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

        [HttpDelete]
        [Route("delete/{CategoriaId}")]
        public void Delete(int CategoriaId)
        {
            var blCategoria = new CategoriaBL();

            blCategoria.Delete(CategoriaId);
        }

    }
}
