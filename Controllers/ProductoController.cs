using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Para poder traer relaciones en las entidades.
using api_mvc.Services;
using api_mvc.Models;

namespace api_mvc.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController: ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductosController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProductos()
    {
        var productos = _context.Productos.Include(p => p.Categoria).ToList(); // LINQ para obtener productos con categoría
        return Ok(productos);
    }

    [HttpGet("{productoId}")]
    public ActionResult<Producto> GetProducto(int productoId) 
    {
        var producto = _context.Productos.Include(p => p.Categoria).FirstOrDefault(x => x.Id == productoId);

        if (producto == null)
            return NotFound("No se encontró el producto");

        return Ok(producto);
    }

    [HttpPost]
    public ActionResult<Producto> PostProducto(ProductoInsert productoInsert)
    {
        var categoria_reference = _context.Categorias.FirstOrDefault(x => x.Id == productoInsert.IdCategoria);

        if (categoria_reference == null)
            return NotFound("No se encontró la categoría");

        var productoNuevo = new Producto() {
            Nombre = productoInsert.Nombre,
            Descripcion = productoInsert.Descripcion,
            Precio = productoInsert.Precio,
            Stock = productoInsert.Stock,
            IdCategoria = productoInsert.IdCategoria,
            Categoria = categoria_reference,
        };

        _context.Productos.Add(productoNuevo);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetProducto),
            new { productoId = productoNuevo.Id },
            productoNuevo
        );
    }

    [HttpPut("{productoId}")]
    public ActionResult<Producto> PutProducto(int productoId, ProductoInsert productoInsert)
    {
        var producto = _context.Productos.Include(p => p.Categoria).FirstOrDefault(x => x.Id == productoId); //prductID se obtiene de la URL
        var categoria_reference = _context.Categorias.FirstOrDefault(x => x.Id == productoInsert.IdCategoria);

        if (producto == null)
            return NotFound("No se encontró el producto");

        if (categoria_reference == null)
            return NotFound("No se encontró la categoría");

        producto.Nombre = productoInsert.Nombre;
        producto.Descripcion = productoInsert.Descripcion;
        producto.Precio = productoInsert.Precio;
        producto.Stock = productoInsert.Stock;
        producto.IdCategoria = productoInsert.IdCategoria;
        producto.Categoria = categoria_reference;

        _context.Productos.Update(producto);
        _context.SaveChanges();

        return Ok(producto);
    }

    [HttpDelete("{productoId}")]
    public ActionResult DeleteProducto(int productoId)
    {
        var producto = _context.Productos.FirstOrDefault(x => x.Id == productoId);

        if (producto == null)
            return NotFound("No se encontró el producto");

        _context.Productos.Remove(producto);
        _context.SaveChanges();

        return Ok(_context.Productos.Include(p => p.Categoria).ToList()); // 204 No Content????
    }
}