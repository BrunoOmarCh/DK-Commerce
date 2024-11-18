using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerce_Bussines_Entity
{
    public class Categoria
    {
        public int CategoriaId { get; set; } 
        public string Nombre { get; set; } 
        public string Descripcion { get; set; } 
        public bool Suspendido { get; set; } 
    }
}
