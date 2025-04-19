using api_mvc.Models;

namespace api_mvc.Services;

public class ProductoDataStore
{
    public List<Producto> Productos { get; set; }

    public static ProductoDataStore Current { get; } = new ProductoDataStore(); // Singleton. para que no se creen instancias de MandrilDataStore en cada llamada a la API.

    public ProductoDataStore()
    {
        Productos = new List<Producto>()
        {
            new Producto()
            {
                Id = 1,
                Nombre = "Detergente",
                Descripcion = "Detegerente liquido para lavar ropa",
                Precio = 10.0,
                Stock = 100,
                Categoria = new Categoria()
                {
                    Id = 1,
                    Nombre = "Limpieza",
                    Descripcion = "Productos de limpieza para el hogar"
                }
            },
            new Producto()
            {
                Id = 2,
                Nombre = "Arroz",
                Descripcion = "Arroz de grano largo",
                Precio = 20.0,
                Stock = 200,
                Categoria = new Categoria()
                {
                    Id = 2,
                    Nombre = "Alimentos",
                    Descripcion = "Productos alimenticios"
                }
            }
        };
    }
}
