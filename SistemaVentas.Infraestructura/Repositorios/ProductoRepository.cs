using Microsoft.EntityFrameworkCore;
using SistemaVentas.Aplicacion.Interfaces;
using SistemaVentas.Dominio.Entidades;
using SistemaVentas.Infraestructura.Persistencia;

namespace SistemaVentas.Infraestructura.Repositorios
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly AppDbContext _context;
        public ProductoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllActiveProductsAsync()
        {
            return await _context.Productos.Where(p => p.Acivo).ToListAsync();
        }
    }
}