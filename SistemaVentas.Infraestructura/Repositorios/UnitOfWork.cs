using SistemaVentas.Aplicacion.Interfaces;
using SistemaVentas.Dominio.Entidades;
using SistemaVentas.Infraestructura.Persistencia;

namespace SistemaVentas.Infraestructura.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductoRepository? _productos;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        
        public IProductoRepository Productos => _productos ?? new ProductoRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}