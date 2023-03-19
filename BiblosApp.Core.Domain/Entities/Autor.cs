using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblosApp.Core.Domain.Common;

namespace BiblosApp.Core.Domain.Entities
{
    public class Autor : EntidadBaseAuditable
    {
        public string Nombre { get; set; }
        public int Num_publicaciones { get; set; }

        //Nav Properties
        public ICollection<Libro> Libros { get; set; }
    }
}
