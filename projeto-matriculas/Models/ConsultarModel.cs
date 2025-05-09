using projeto_matriculas.Enums;
using projeto_matriculas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_matriculas.Models
{
    public class ConsultarModel : IObservavel<ConsultarModel>
    {
        public List<IObservador<ConsultarModel>> _observadores;
        public FiltrosConsulta Filtros { get; set; }
        public Consulta Consulta1 { get; set; }
        public Consulta Consulta2 { get; set; }

        public ConsultarModel()
        {
            _observadores = new List<IObservador<ConsultarModel>>();
        }

        public void NotificaObservadores()
        {
            foreach (IObservador<ConsultarModel> item in _observadores)
            {
                item.Atualizar(this);
            }
        }

        public void RegistraObservador(IObservador<ConsultarModel> o)
        {
            _observadores.Add(o);
        }

        public void RemoveObservador(IObservador<ConsultarModel> o)
        {
            _observadores.Remove(o);
        }
        public void ConsultarAnosDisponiveis()
        {
            //implementar consulta de anos
            Filtros.AnosDisponiveis = new List<int>();
        }

        public void Consultar()
        {
            NotificaObservadores();
        }
    }
}
