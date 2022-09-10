using CursoOnline.Dominio;

namespace CursoOnline.Aplicacao.Aplicacao
{
    public class ArmazenadorDeCursoAplicacao
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCursoAplicacao(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            var curso = new Curso(cursoDto.Nome, cursoDto.CargaHoraria, PublicoAlvo.Estudante, cursoDto.Valor, cursoDto.Descricao);
            _cursoRepositorio.Adicionar(curso);
        }
    }
}