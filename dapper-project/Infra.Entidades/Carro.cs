using Dapper.Contrib.Extensions;

namespace Infra.Entidades
{
    [Table("Carro")]
    public class Carro : EntidadeBase
    {
        public string Fabricante { get; set; }

        public string Modelo { get; set; }

        public int AnoFabricacao { get; set; }

        [Write(false)]
        [Computed]
        public Pessoa Proprietario { get; set; }
    }
}