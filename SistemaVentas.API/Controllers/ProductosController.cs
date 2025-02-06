using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Infraestructura.Persistencia;
using SistemaVentas.Dominio.Entidades;

namespace SistemaVentas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var productos = _context.Productos.ToList();
            return Ok(productos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            //return Ok();
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }
    }
}