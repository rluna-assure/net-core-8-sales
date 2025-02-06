using SistemaVentas.Dominio.Entidades;

namespace SistemaVentas.Aplicacion.Interfaces
{
    public interface IUnitOfWork
    {
        IProductoRepository Productos { get; }
        Task<int> SaveChangesAsync();
    }
}