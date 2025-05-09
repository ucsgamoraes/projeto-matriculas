using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_matriculas.Interfaces
{
    public interface IObservavel<T>
    {
        void RegistraObservador(IObservador<T> o);
        void RemoveObservador(IObservador<T> o);
        void NotificaObservadores();        
    }
}
