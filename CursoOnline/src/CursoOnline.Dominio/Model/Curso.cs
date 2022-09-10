using CursoOnline.Infra;

namespace CursoOnline.Dominio
{
    public class Curso
    {
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public PublicoAlvo PublicoAlvo { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, decimal valor, string descricao)
        {
            ValidarNome(nome);
            ValidarCargaHoraria(cargaHoraria);
            ValidarValor(valor);

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
            Descricao = descricao;
        }

        private void ValidarNome(string nome)
        {
            if (!nome.HasValue())
                throw new ArgumentException("Nome inválido ou vazio!");
        }

        private void ValidarCargaHoraria(double cargaHoraria)
        {
            if(cargaHoraria < 1)
                throw new ArgumentException("Carga horária inválida!");
        }

        private void ValidarValor(decimal valor)
        {
            if (valor < 1)
                throw new ArgumentException("O valor informado é inválido, favor informa um favor válido!");
        }
    }
}