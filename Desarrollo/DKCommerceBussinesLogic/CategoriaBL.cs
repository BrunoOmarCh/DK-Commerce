using DKCommerceBussinesEntity;
using DKCommerceDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesLogic
{
    public class CategoriaBL
    {
        public CategoriaBE SelectById(int idCategoria)
        {
            var daCategoria = new CategoriaDA();

            return daCategoria.SelectById(idCategoria);
            /*try
            {
                var daCategoria = new CategoriaDA();
                Categoria beCategoria;

                beCategoria = daCategoria.SelectById(idCategoria);
                return beCategoria;
            }
            catch (Exception ex)
            {
                // Se habilita un log de eventos

                throw ex;
            }*/
        }

        public void Insert(CategoriaBE beCategoria)
        {
            var daCategoria = new CategoriaDA();
            daCategoria.Insert(beCategoria);
            /*try
            {

                var daCategoria = new CategoriaDA();

                daCategoria.Insert(beCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }*/
        }
        public void Update(int idCategoria, CategoriaBE beCategoria)
        {
            try
            {
                var daCategoria = new CategoriaDA();

                daCategoria.Update(idCategoria, beCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int idCategoria)
        {
            try
            {
                var daCategoria = new CategoriaDA();

                daCategoria.Delete(idCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
