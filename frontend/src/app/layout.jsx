// app/layout.js
import "./globals.css";
export const metadata = {
    title: 'Mi App',
    description: 'Una app hecha con Next.js',
  };
  
  export default function RootLayout({ children }) {
    return (
      <html lang="es">
        <body>
          <header>
            <h1>Mi App</h1>
            <nav>
              <a href="/Categoria">Categorías</a> |{" "}
              <a href="/Producto">Productos</a>
            </nav>
          </header>
          <main style={{ padding: "1rem" }}>
            {children} {/* <- Acá se cargan las rutas como /categorias o /productos */}
          </main>
          <footer style={{ marginTop: "2rem" }}>
            <hr />
            <p>&copy; 2025 Mi App</p>
          </footer>
        </body>
      </html>
    );
  }
  