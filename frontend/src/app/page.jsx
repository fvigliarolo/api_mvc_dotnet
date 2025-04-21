export default function Home() {
    return (
      <div style={{ padding: "2rem" }}>
        <div>
  <h2>Documentación de Endpoints</h2>
  <h3>Endpoints de Categorías</h3>
  <ul>
    <li>
      <strong>GET /api/categorias</strong>: Obtiene una lista de todas las categorías.
      <ul>
        <li><strong>Parámetros:</strong> Ninguno.</li>
      </ul>
    </li>
    <li>
      <strong>GET /api/categorias/:id</strong>: Obtiene los detalles de una categoría específica.
      <ul>
        <li><strong>Parámetros:</strong></li>
        <li><code>id</code>: ID de la categoría (en la ruta).</li>
      </ul>
    </li>
    <li>
      <strong>POST /api/categorias</strong>: Crea una nueva categoría.
      <ul>
        <li><strong>Parámetros:</strong></li>
        <li><code>nombre</code>: Nombre de la categoría (en el cuerpo de la solicitud).</li>
      </ul>
    </li>
    <li>
      <strong>PUT /api/categorias/:id</strong>: Actualiza una categoría existente.
      <ul>
        <li><strong>Parámetros:</strong></li>
        <li><code>id</code>: ID de la categoría (en la ruta).</li>
        <li><code>nombre</code>: Nombre actualizado de la categoría (en el cuerpo de la solicitud).</li>
      </ul>
    </li>
    <li>
      <strong>DELETE /api/categorias/:id</strong>: Elimina una categoría específica.
      <ul>
        <li><strong>Parámetros:</strong></li>
        <li><code>id</code>: ID de la categoría (en la ruta).</li>
      </ul>
    </li>
  </ul>

  <h3>Endpoints de Productos</h3>
  <ul>
    <li>
      <strong>GET /api/productos</strong>: Obtiene una lista de todos los productos.
      <ul>
        <li><strong>Parámetros:</strong> Ninguno.</li>
      </ul>
    </li>
    <li>
      <strong>GET /api/productos/:id</strong>: Obtiene los detalles de un producto específico.
      <ul>
        <li><strong>Parámetros:</strong></li>
        <li><code>id</code>: ID del producto (en la ruta).</li>
      </ul>
    </li>
    <li>
      <strong>POST /api/productos</strong>: Crea un nuevo producto.
      <ul>
        <li><strong>Parámetros:</strong></li>
        <li><code>nombre</code>: Nombre del producto (en el cuerpo de la solicitud).</li>
        <li><code>precio</code>: Precio del producto (en el cuerpo de la solicitud).</li>
        <li><code>categoriaId</code>: ID de la categoría asociada (en el cuerpo de la solicitud).</li>
      </ul>
    </li>
    <li>
      <strong>PUT /api/productos/:id</strong>: Actualiza un producto existente.
      <ul>
        <li><strong>Parámetros:</strong></li>
        <li><code>id</code>: ID del producto (en la ruta).</li>
        <li><code>nombre</code>: Nombre actualizado del producto (en el cuerpo de la solicitud).</li>
        <li><code>precio</code>: Precio actualizado del producto (en el cuerpo de la solicitud).</li>
        <li><code>categoriaId</code>: ID actualizado de la categoría asociada (en el cuerpo de la solicitud).</li>
      </ul>
    </li>
    <li>
      <strong>DELETE /api/productos/:id</strong>: Elimina un producto específico.
      <ul>
        <li><strong>Parámetros:</strong></li>
        <li><code>id</code>: ID del producto (en la ruta).</li>
      </ul>
    </li>
  </ul>
</div>
      </div>
    );
  }

