using api_mvc.Models;
using api_mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_mvc.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController: ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Producto>> GetProductos() // Getter del datastore
    {
        return Ok(ProductoDataStore.Current.Productos);
    }

    [HttpGet("{productoId}")]
    public ActionResult<Producto> GetProducto(int productoId) 
    {
        var producto = ProductoDataStore.Current.Productos.FirstOrDefault(x => x.Id == productoId);

        if (producto == null)
            return NotFound("No se encontró el producto");

        return Ok(producto);
    }

    [HttpPost]
    public ActionResult<Producto> PostProducto(ProductoInsert productoInsert)
    {
        var maxProductoId = ProductoDataStore.Current.Productos.Max(x => x.Id);
        var  categoria_reference= CategoriaDataStore.Current.Categorias.FirstOrDefault(x => x.Id == productoInsert.IdCategoria);

        if (categoria_reference == null)
            return NotFound("No se encontró la categoría");

        var productoNuevo = new Producto() {
            Id = maxProductoId + 1,
            Nombre = productoInsert.Nombre,
            Descripcion = productoInsert.Descripcion,
            Precio = productoInsert.Precio,
            Stock = productoInsert.Stock,
            IdCategoria = productoInsert.IdCategoria,
            Categoria = categoria_reference,
        };
        ProductoDataStore.Current.Productos.Add(productoNuevo);

        return CreatedAtAction(nameof(GetProducto),
            new { productoId = productoNuevo.Id },
            productoNuevo
        );
    }

    [HttpPut("{productoId}")]
    public ActionResult<Producto> PutProducto(int productoId, ProductoInsert productoInsert)
    {
        var producto = ProductoDataStore.Current.Productos.FirstOrDefault(x => x.Id == productoId); //prductID se obtiene de la URL
        var categoria_reference = CategoriaDataStore.Current.Categorias.FirstOrDefault(x => x.Id == productoInsert.IdCategoria);

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

        return Ok(producto);
    }

    [HttpDelete("{productoId}")]
    public ActionResult DeleteProducto(int productoId)
    {
        var producto = ProductoDataStore.Current.Productos.FirstOrDefault(x => x.Id == productoId);

        if (producto == null)
            return NotFound("No se encontró el producto");

        ProductoDataStore.Current.Productos.Remove(producto);

        return Ok(ProductoDataStore.Current.Productos); // 204 No Content
    }
}