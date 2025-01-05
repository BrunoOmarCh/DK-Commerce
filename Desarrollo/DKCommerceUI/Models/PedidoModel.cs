namespace DKCommerceUI.Models
{
    public class PedidoModel
    {
        public int PedidoId { get; set; }
        public string ClienteId { get; set; }
        public int? IdEmpleado { get; set; }
        public DateTime? FechaPedido { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public DateTime? FechaEnvío { get; set; }
        public int? FormaEnvío { get; set; }
        public decimal? Igv { get; set; }
        public decimal? Isc { get; set; }
        public decimal? MontoTotal { get; set; }
        public string? Destinatario { get; set; }
        public string? DirecciónDestinatario { get; set; }
        public string? CiudadDestinatario { get; set; }
        public string? RegiónDestinatario { get; set; }
        public string? CódPostalDestinatario { get; set; }
        public string? PaísDestinatario { get; set; }
    }
}
