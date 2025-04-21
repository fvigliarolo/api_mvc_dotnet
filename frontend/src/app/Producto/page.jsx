"use client";
import React, { useState, useEffect } from "react";

export default function ProductoPage() {
    const [productos, setProductos] = useState([]);
    const [search, setSearch] = useState("");
    const [categoria, setCategoria] = useState([]);

    useEffect(() => {
        fetch("http://localhost:5056/api/Productos")
          .then((res) => res.json())
          .then((data) => setProductos(data))
          .catch((err) => console.error("Error al cargar categorías", err));
      }, []);

    useEffect(() => {
        fetch("http://localhost:5056/api/Categorias")
          .then((res) => res.json())
          .then((data) => setCategoria(data))
          .catch((err) => console.error("Error al cargar categorías", err));
      }, []);
    const filtrados = productos.filter((p) =>
        p.descripcion?.toLowerCase().includes(search.toLowerCase())
    );
    const categorias = categoria.filter((c) =>
        c.descripcion?.toLowerCase().includes(search.toLowerCase())
    );
    return (
        // mostramos los productos por categoria unicamente
        <div>
            <h1>Productos</h1>
            <input
                type="text"
                placeholder="Buscar producto"
                value={search}
                onChange={(e) => setSearch(e.target.value)}
            />
            <div className="grid grid-cols-3 gap-4">
                {filtrados.map((p) => (
                    <div key={p.id} className="border p-4">
                        <h2>{p.nombre}</h2>
                        <p>Precio: {p.precio}</p>
                        <p>Categoria: {p.categoria.descripcion}</p>
                    </div>
                ))}
            </div>
        </div>

        
    );
}
