using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Infra.Entidades
{
    [Table("Pessoa")]
    public class Pessoa : EntidadeBase
    {
        public string Nome { get; set; }

        public int Idade { get; set; }

        [Write(false)]
        [Computed]
        public List<Carro> Carros { get; set; }
    }
}