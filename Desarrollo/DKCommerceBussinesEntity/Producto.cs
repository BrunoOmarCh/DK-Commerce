using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesEntity
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int? ProveedorId {  get; set; }   
        public int? CategoriaId { get; set; }
        public string? CantidadPorUnidad { get; set; }
        public decimal? PrecioLista { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Igv { get; set; }
        public decimal? Isc { get; set; }
        public decimal? PrecioVenta{ get; set;  }  
        public short? UnidadesEnexistencia { get; set; }
        public short? UnidadesEnPedido {  get; set; }
        public short? NivelNuevoPedido { get; set; }
        public bool Suspendido {  get; set; }
        public int? UsuarioId { get; set; }


    }
}
