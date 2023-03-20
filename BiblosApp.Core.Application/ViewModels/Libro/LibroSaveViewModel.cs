using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.ViewModels.Libro
{
    public class LibroSaveViewModel
    {
        [Required(ErrorMessage = "Debe especificar el nombre del libro")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe especificar el autor del libro")]
        public int Id_autor { get; set; }

        [Required(ErrorMessage = "Debe especificar el precio del libro")]
        [DataType(DataType.Currency)]
        public Double Precio { get; set; }

        [Required(ErrorMessage = "Debe especificar la cantidad de paginas del libro")]
        public int Num_paginas { get; set; }

        [Required(ErrorMessage = "Debe incluir una portada para el libro")]
        [DataType(DataType.ImageUrl)]
        public string Link_portada { get; set; }

        [Required(ErrorMessage = "Debe especificar la cantidad del libro en inventario")]
        public int Cantidad_inventario { get; set; }
    }
}
