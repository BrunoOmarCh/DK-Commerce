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
        public CategoriaBE SelectById(int categoriaId)
        {
            var daCategoria = new CategoriaDA();

            return daCategoria.SelectById(categoriaId);
        }

        public void Insert(CategoriaBE beCategoria)
        {
            var daCategoria = new CategoriaDA();

            daCategoria.Insert(beCategoria);
        }
    }
}
