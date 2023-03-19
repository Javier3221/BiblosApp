using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblosApp.Core.Domain.Common;

namespace BiblosApp.Core.Domain.Entities
{
    public class Libro : EntidadBaseAuditable
    {
        public string Nombre { get; set; }
        public int Id_autor { get; set; }
        public Double Precio { get; set; }
        public int Num_paginas { get; set; }
        public string Link_portada { get; set; }
        public int Cantidad_inventario { get; set; }

        //Nav properties
        public Autor Autor { get; set; }
    }
}
