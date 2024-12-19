namespace DKCommerceUI.Models
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int? ProveedorId { get; set; }
        public int? CategoriaId { get; set; }
        public string? CantidadPorUnidad { get; set; }
        public decimal? PrecioLista { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Igv { get; set; }
        public decimal? Isc { get; set; }
        public decimal? PrecioVenta { get; set; }
        public short? UnidadesEnExistencia { get; set; }
        public short? UnidadesEnPedido { get; set; }
        public short? NivelNuevoPedido { get; set; }
        public bool Suspendido { get; set; }
        public int? UsuarioId { get; set; }

        /*

        public string IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int ProveedorId { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        public string SubCategoriaNombre { get; set; }
        public string CantidadPorUnidad { get; set; }
        public decimal PrecioLista { get; set; }
        //decimal: Nro con parte decimal de alta precisión
        public decimal Descuento { get; set; }
        public decimal Igv { get; set; }
        public decimal Isc { get; set; }
        public decimal PrecioVenta { get; set; }
        //short: Entero corto
        public short UnidadesEnExistencia { get; set; }
        public short UnidadesEnPedido { get; set; }
        public int NivelNuevoPedido { get; set; }
        public bool Suspendido { get; set; }
        public int UsuarioId { get; set; }*/

    }
}
