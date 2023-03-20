using BiblosApp.Core.Application.ViewModels.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.ViewModels.Libro
{
    public class LibroViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Double Precio { get; set; }
        public int Num_paginas { get; set; }
        public string Link_portada { get; set; }
        public int Cantidad_inventario { get; set; }

        public AutorViewModel Autor { get; set; }
    }
}
