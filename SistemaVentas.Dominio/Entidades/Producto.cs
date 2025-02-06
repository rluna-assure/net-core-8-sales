namespace SistemaVentas.Dominio.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Acivo { get; set; }
    }
}