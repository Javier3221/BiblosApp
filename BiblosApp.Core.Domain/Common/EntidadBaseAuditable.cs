using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Domain.Common
{
    public class EntidadBaseAuditable
    {
        public int Id { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
    }
}
