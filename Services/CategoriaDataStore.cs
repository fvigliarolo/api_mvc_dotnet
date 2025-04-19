using api_mvc.Models;

namespace api_mvc.Services;

public class CategoriaDataStore
{
    public List<Categoria> Categorias { get; set; }

    public static CategoriaDataStore Current { get; } = new CategoriaDataStore();


    public CategoriaDataStore()
    {
        Categorias = new List<Categoria>()
        {
            new Categoria()
            {
                Id = 1,
                Nombre = "Electrónica",
                Descripcion = "Dispositivos electrónicos y gadgets"
            },
            new Categoria()
            {
                Id = 2,
                Nombre = "Ropa",
                Descripcion = "Prendas de vestir y accesorios"
            },
            new Categoria()
            {
                Id = 3,
                Nombre = "Alimentos",
                Descripcion = "Comida y bebidas"
            }
        };
    }
}