using api_mvc.Models;
using api_mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_mvc.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController: ControllerBase // El endpoint será lo que se encuentre antes de "Conroller". (Categorias)
{
    private readonly ApplicationDbContext _context;

    public CategoriasController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> GetCategorias() // Getter del datastore
    {
        return Ok(_context.Categorias.ToList());
    }

    [HttpGet("{categoriaId}")]
    public ActionResult<Categoria> GetCategoria(int categoriaId) 
    {
        var categoria = _context.Categorias.FirstOrDefault(x => x.Id == categoriaId);

        if (categoria == null)
            return NotFound("No se encontró la categoría");

        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult<Categoria> PostCategoria(Categoria categoria)
    {
        // var maxCategoriaId = 0;

        // if  (_context.Categorias.Count() != 0)
        //     maxCategoriaId = _context.Categorias.Max(x => x.Id);

        var categoriaNueva = new Categoria() {
            // Id = maxCategoriaId + 1, // Para tener manejo sobre el ID hay que descomentar la linea  de "SET IDENTITY_INSERT Categorias ON"
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion
        };
        
        // _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categorias ON");
        _context.Categorias.Add(categoriaNueva);
        _context.SaveChanges();
        // _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categorias OFF"); 

        return CreatedAtAction(nameof(GetCategoria),
            new { categoriaId = categoriaNueva.Id },
            categoriaNueva
        );
    }

    [HttpPut("{categoriaId}")]
    public ActionResult<Categoria> PutCategoria(int categoriaId, Categoria categoria)
    {
        var categoria_reference = _context.Categorias.FirstOrDefault(x => x.Id == categoriaId); //prductID se obtiene de la URL

        if (categoria_reference == null)
            return NotFound("No se encontró la categoría");

        categoria_reference.Nombre = categoria.Nombre;
        categoria_reference.Descripcion = categoria.Descripcion;

        _context.Categorias.Update(categoria_reference);
        _context.SaveChanges();

        return Ok(categoria_reference);
    }

    [HttpDelete("{categoriaId}")]
    public ActionResult DeleteCategoria(int categoriaId)
    {
        var categoria_reference = _context.Categorias.FirstOrDefault(x => x.Id == categoriaId); //prductID se obtiene de la URL

        if (categoria_reference == null)
            return NotFound("No se encontró la categoría");

        _context.Categorias.Remove(categoria_reference);
        _context.SaveChanges();

        return Ok(_context.Categorias.ToList());
    }

}