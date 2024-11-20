using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesEntity
{
    public class ClienteBE
    {
        public string ClienteId { get; set; }
        public string NombreRazonSocial { get; set; }
        public string? TipoDocumento { get; set; }   
        public string? NroDocumento { get; set; }
        public int? ContactoId { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Region { get; set; }
        public string? CodPostal { get; set; }
        public string? Pais { get; set; }
        public string? Telefono { get; set; }
        public string? Fax { get; set; }
    }

}
