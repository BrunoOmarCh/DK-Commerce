using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesEntity
{
    public class ContactoCliente
    {
        public int ContactoId { get; set; }
        public string? NombreContacto { get; set; }
        public string? CargoContacto { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NroDocumento { get; set; }
    }

}
