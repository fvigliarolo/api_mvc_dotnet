"use client";
import { useEffect, useState } from "react";

export default function CategoriasPage() {
  const [categorias, setCategorias] = useState([]);
  const [search, setSearch] = useState("");

  useEffect(() => {
    fetch("http://localhost:5056/api/Categorias")
      .then((res) => res.json())
      .then((data) => setCategorias(data))
      .catch((err) => console.error("Error al cargar categorías", err));
  }, []);

  const filtradas = categorias.filter((c) =>
    c.descripcion?.toLowerCase().includes(search.toLowerCase())
  );

  return (
    <div className="container mt-4">
      <h2>Categorías</h2>
      <input
        type="text"
        className="form-control my-3"
        placeholder="Buscar por descripción..."
        value={search}
        onChange={(e) => setSearch(e.target.value)}
      />
      <div className="row">
        {filtradas.map((categoria) => (
          <div key={categoria.id} className="col-md-4">
            <div className="card mb-3">
              <div className="card-body">
                <h5 className="card-title">{categoria.nombre}</h5>
                <p className="card-text">{categoria.descripcion}</p>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
