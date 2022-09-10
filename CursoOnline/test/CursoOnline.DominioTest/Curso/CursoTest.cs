using Bogus;
using CursoOnline.Dominio;
using CursoOnline.DominioTest.Builders;
using ExpectedObjects;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTeste : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly Faker _faker = new();

        public CursoTeste(ITestOutputHelper output)
        {
            _output = output;

            _output.WriteLine("Construtor sendo executado");
        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }

        [Fact]
        public void CriarCurso()
        {
            //Arrange
            var novoCurso = new
            {
                Nome = _faker.Random.Word(),
                CargaHoraria = _faker.Random.Double(50, 1000),
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = _faker.Random.Decimal(100, 1000),
                Descricao = _faker.Lorem.Paragraph()
            };

            //Act
            var curso = new Curso(novoCurso.Nome, novoCurso.CargaHoraria, novoCurso.PublicoAlvo, novoCurso.Valor, novoCurso.Descricao);

            //Assert
            novoCurso.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CriarCursoComNomeInvalido_RetornaErro(string nomeInvalido)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComNome(nomeInvalido).Build()).WithMessage("Nome inválido ou vazio!");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-23)]
        [InlineData(-51)]
        public void CriarCursoComCargaHorariaInvalida_RetornaErro(int cargaHorariaInvalida)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build()).WithMessage("Carga horária inválida!");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-4)]
        [InlineData(-25)]
        public void CriarCursoComValorInvalido_RetornaErro(decimal valorInvalido)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComValor(valorInvalido).Build()).WithMessage("O valor informado é inválido, favor informa um favor válido!");
        }
    }
}
