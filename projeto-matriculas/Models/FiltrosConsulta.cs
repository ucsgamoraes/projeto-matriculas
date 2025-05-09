using projeto_matriculas.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_matriculas.Models
{
    public class FiltrosConsulta
    {
        public List<int> AnosDisponiveis { get; set; }
        public int? AnoIni { get; set; }
        public int? AnoFim { get; set; }
        public TipoConsulta TipoConsulta { get; set; }
        public bool IsPresencial { get; set; }
        public bool IsEAD { get; set; }
    }
}
