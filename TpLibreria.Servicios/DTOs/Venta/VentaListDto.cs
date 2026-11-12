namespace TpLibreria.Servicios.DTOs.Venta
{
    public class VentaListDto
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } = null!;
        public string TipoVenta { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public int CantidadLibros { get; set; }
        public decimal ImporteTotal { get; set; }
    }
}
