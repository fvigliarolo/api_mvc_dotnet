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
        var  selected_categoria= CategoriaDataStore.Current.Categorias.FirstOrDefault(x => x.Id == productoInsert.IdCategoria);

        if (selected_categoria == null)
            return NotFound("No se encontró la categoría");

        var productoNuevo = new Producto() {
            Id = maxProductoId + 1,
            Nombre = productoInsert.Nombre,
            Descripcion = productoInsert.Descripcion,
            Precio = productoInsert.Precio,
            Stock = productoInsert.Stock,
            IdCategoria = productoInsert.IdCategoria,
            Categoria = selected_categoria,

            // Categoria = new Categoria()
            // {
            //     Id = productoInsert.Categoria.Id,
            //     Nombre = productoInsert.Categoria.Nombre,
            //     Descripcion = productoInsert.Categoria.Descripcion
            // }


        };
        ProductoDataStore.Current.Productos.Add(productoNuevo);

        return CreatedAtAction(nameof(GetProducto),
            new { productoId = productoNuevo.Id },
            productoNuevo
        );
    }
}