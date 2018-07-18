using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Infra.Entidades;

namespace DemoDapperCore.Models
{
    public class PessoaViewModel
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Por favor especifique o nome do proprietário.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor especifique a idade do proprietário.")]
        [Range(18, 99, ErrorMessage = "Por favor preencha uma idade valida.")]
        public int Idade { get; set; }

        public IEnumerable<CarroViewModel> Carros { get; set; }

        public static explicit operator PessoaViewModel(Pessoa entidade)
        {
            if (entidade == null)
                return null;

            var viewModel = new PessoaViewModel
            {
                Codigo = entidade.Codigo,
                Idade = entidade.Idade,
                Nome = entidade.Nome
            };

            return viewModel;
        }
    }
}