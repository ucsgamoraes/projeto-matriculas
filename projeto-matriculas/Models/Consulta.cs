using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_matriculas.Models
{
    public class Consulta
    {
        public List<string> Resultados { get; set; }
        public Consulta()
        {
            Resultados = new List<string>();
        }
    }
}
