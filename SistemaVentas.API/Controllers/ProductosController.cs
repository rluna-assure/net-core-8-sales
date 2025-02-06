using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Infraestructura.Persistencia;
using SistemaVentas.Dominio.Entidades;
using SistemaVentas.Aplicacion.Interfaces;

namespace SistemaVentas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await _unitOfWork.Productos.GetAllActiveProductsAsync();
            return Ok(productos);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {
            await _unitOfWork.Productos.AddAsync(producto);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }
    }
}