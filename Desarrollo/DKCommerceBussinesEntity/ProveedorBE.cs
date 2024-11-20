using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesEntity
{
    public class ProveedorBE
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string? Ruc { get; set; }
        public int ContactoId { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Region { get; set; }
        public string? CodPostal { get; set; }
        public string? Pais { get; set; }
        public string? Telefono { get; set; }
        public string? Fax { get; set; }
        public string? PaginaPrincipal { get; set; }

    }
}