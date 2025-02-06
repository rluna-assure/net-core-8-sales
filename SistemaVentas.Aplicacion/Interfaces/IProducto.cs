using SistemaVentas.Dominio.Entidades;

namespace SistemaVentas.Aplicacion.Interfaces
{
    public interface IProductoRepository : IRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetAllActiveProductsAsync();
    }
}