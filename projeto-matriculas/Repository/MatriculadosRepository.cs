using System.Collections.Generic;

namespace projeto_matriculas
{
    /// <summary>
    /// Repositório simples para encapsular o acesso via MatriculadosDAO.
    /// </summary>
    public class MatriculadosRepository
    {
        private readonly MatriculadosDAO _dao;

        public MatriculadosRepository()
        {
            _dao = new MatriculadosDAO();
        }

        /// <summary>
        /// Insere um novo registro de matriculado.
        /// </summary>
        public void Adicionar(Matriculados matriculado)
        {
            _dao.Inserir(matriculado);
        }

        /// <summary>
        /// Retorna o total de matriculados por ano (Brasil geral).
        /// </summary>
        public TotaisAnuais ObterTotaisAnuais()
        {
            return _dao.ObterTotaisAnuais();
        }

        /// <summary>
        /// Retorna o total de matriculados por ano para uma modalidade específica.
        /// </summary>
        public TotaisAnuais ObterTotaisAnuaisPorModalidade(string modalidade)
        {
            return _dao.ObterTotaisAnuaisPorModalidade(modalidade);
        }

        /// <summary>
        /// Obtém o ranking dos N cursos mais matriculados em 2022.
        /// </summary>
        public List<CursoTotal> ObterTopCursos2022(int topN = 10)
        {
            return _dao.ObterTopCursos2022(topN);
        }

        /// <summary>
        /// Obtém o ranking dos N cursos mais matriculados em 2022 para uma modalidade.
        /// </summary>
        public List<CursoTotal> ObterTopCursos2022PorModalidade(string modalidade, int topN = 10)
        {
            return _dao.ObterTopCursos2022PorModalidade(modalidade, topN);
        }

        /// <summary>
        /// Retorna totais de matriculados por ano para um estado específico.
        /// </summary>
        public TotaisPorEstado ObterTotaisPorEstado(string estado)
        {
            return _dao.ObterTotaisPorEstado(estado);
        }
    }
}
