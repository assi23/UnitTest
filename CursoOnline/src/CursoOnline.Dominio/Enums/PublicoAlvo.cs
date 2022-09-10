using System.ComponentModel;

namespace CursoOnline.Dominio
{
    public enum PublicoAlvo : short
    {
        [Description("Estudante")]
        Estudante = 0,

        [Description("Estudante de Faculdade")]
        Universitario= 1,

        [Description("Empregado de Empresa")]
        Empregado = 2,

        [Description("Empreendedor")]
        Empreendedor = 3
    }
}
