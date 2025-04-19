namespace api_mvc.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public double Precio { get; set; }

        public int Stock { get; set; }

        public int IdCategoria { get; set; } = 0;

        public Categoria Categoria { get; set; } = new Categoria();
    }
}