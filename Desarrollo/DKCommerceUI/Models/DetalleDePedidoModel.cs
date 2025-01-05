namespace DKCommerceUI.Models
{
    public class DetalleDePedidoModel
    {
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public decimal PrecioNeto { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal? Igv { get; set; }
        public decimal? Isc { get; set; }
        public decimal? MontoSubTotal { get; set; }
    }
}
