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
            try
            {
                var daCategoria = new CategoriaDA();
                CategoriaBE beCategoria;

                beCategoria = daCategoria.SelectById(idCategoria);
                return beCategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert(CategoriaBE beCategoria)
        {
            try
            {
                var daCategoria = new CategoriaDA();
                daCategoria.Insert(beCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
