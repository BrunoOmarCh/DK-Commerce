using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesEntity
{
    public class Empleado
    {
        public int EmpleadoId { get; set; } 
        public string Nombres { get; set; } 
        public string? ApellidoPaterno { get; set; } 
        public string? ApellidoMaterno { get; set; } 
        public string? TipoDocIdentidad { get; set; } 
        public string? NroDocIdentidad { get; set; } 
        public string? Cargo { get; set; } 
        public string? Tratamiento { get; set; } 
        public DateTime? FechaNacimiento { get; set; } 
        public DateTime? FechaContratación { get; set; } 
        public string? Dirección { get; set; } 
        public string? Ciudad { get; set; } 
        public string? Región { get; set; } 
        public string? CodPostal { get; set; } 
        public string? País { get; set; } 
        public string? TelefonoFijo { get; set; } 
        public string? Anexo { get; set; } 
        public string? Notas { get; set; } 
        public int? JefeId { get; set; } 
        public string? Email { get; set; } 
        public string? EstadoCivil { get; set; }
    }

}
