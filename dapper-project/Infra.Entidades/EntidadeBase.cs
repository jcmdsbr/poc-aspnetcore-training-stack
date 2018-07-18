using Dapper.Contrib.Extensions;

namespace Infra.Entidades
{
    public abstract class EntidadeBase
    {
        [Key]
        public int Codigo { get; set; }
    }
}