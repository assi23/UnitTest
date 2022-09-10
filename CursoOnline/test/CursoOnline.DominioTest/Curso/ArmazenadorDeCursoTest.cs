using Bogus;
using CursoOnline.Aplicacao.Aplicacao;
using CursoOnline.Dominio;
using Moq;
using Xunit;

namespace CursoOnline.DominioTest.ArmazenadorDeCurso
{
    public class ArmazenadorDeCursoTest
    {
        private readonly ArmazenadorDeCursoAplicacao _armazenadorDeCurso;
        private readonly CursoDto _cursoDto;
        private readonly Faker _faker = new();
        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock = new Mock<ICursoRepositorio>();

        public ArmazenadorDeCursoTest()
        {
            _armazenadorDeCurso = new ArmazenadorDeCursoAplicacao(_cursoRepositorioMock.Object);

            _cursoDto = new CursoDto
            {
                Nome = _faker.Random.Words(),
                CargaHoraria = _faker.Random.Double(1, 900),
                PublicoAlvoId = 1,
                Valor = _faker.Random.Decimal(100, 5000),
                Descricao = _faker.Lorem.Paragraphs()
            };
        }

        [Fact]
        public void ArmazenarCurso()
        {
            //Arrange
           
            //Act
            _armazenadorDeCurso.Armazenar(_cursoDto);

            //Assert
            _cursoRepositorioMock.Verify(a => a.Adicionar(
                It.Is<Curso>(
                        a => a.Nome == _cursoDto.Nome &&
                        a.CargaHoraria == _cursoDto.CargaHoraria
                    )
                ));
        }
    }
}
