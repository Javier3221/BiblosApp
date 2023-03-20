using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.ViewModels.Autor
{
    public class AutorSaveViewModel
    {
        [Required(ErrorMessage = "Debe especificar un nombre")]
        [DataType (DataType.Text)]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        public int Num_publicaciones { get; set; }
    }
}
