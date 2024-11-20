using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceBussinesEntity
{
    public class DetalleDePedido
    {
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public decimal PrecioNeto { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal? Igv {  get; set; }
        public decimal? Isc { get; set; }
        public decimal? MontoSubTotal {  get; set; }

    }
}
