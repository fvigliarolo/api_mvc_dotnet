using api_mvc.Models;
using api_mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_mvc.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController: ControllerBase // El endpoint será lo que se encuentre antes de "Conroller". (Categorias)
{
    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> GetCategorias() // Getter del datastore
    {
        return Ok(CategoriaDataStore.Current.Categorias);
    }

    [HttpGet("{categoriaId}")]
    public ActionResult<Categoria> GetCategoria(int categoriaId) 
    {
        var categoria = CategoriaDataStore.Current.Categorias.FirstOrDefault(x => x.Id == categoriaId);

        if (categoria == null)
            return NotFound("No se encontró la categoría");

        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult<Categoria> PostCategoria(Categoria categoria)
    {
        var maxCategoriaId = CategoriaDataStore.Current.Categorias.Max(x => x.Id);

        var categoriaNueva = new Categoria() {
            Id = maxCategoriaId + 1,
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion
        };
        CategoriaDataStore.Current.Categorias.Add(categoriaNueva);

        return CreatedAtAction(nameof(GetCategoria),
            new { categoriaId = categoriaNueva.Id },
            categoriaNueva
        );
    }

    [HttpPut("{categoriaId}")]
    public ActionResult<Categoria> PutCategoria(int categoriaId, Categoria categoria)
    {
        var categoria_reference = CategoriaDataStore.Current.Categorias.FirstOrDefault(x => x.Id == categoriaId); //prductID se obtiene de la URL

        if (categoria_reference == null)
            return NotFound("No se encontró la categoría");

        categoria_reference.Nombre = categoria.Nombre;
        categoria_reference.Descripcion = categoria.Descripcion;

        return Ok(categoria_reference);
    }

    [HttpDelete("{categoriaId}")]
    public ActionResult DeleteCategoria(int categoriaId)
    {
        var categoria_reference = CategoriaDataStore.Current.Categorias.FirstOrDefault(x => x.Id == categoriaId); //prductID se obtiene de la URL

        if (categoria_reference == null)
            return NotFound("No se encontró la categoría");

        CategoriaDataStore.Current.Categorias.Remove(categoria_reference);

        return Ok(CategoriaDataStore.Current.Categorias);
    }

}