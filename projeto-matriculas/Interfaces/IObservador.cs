namespace projeto_matriculas.Interfaces
{
    public interface IObservador<T>
    {
        void Atualizar(T dados);
    }
}