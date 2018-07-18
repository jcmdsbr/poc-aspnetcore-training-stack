using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Infra.Entidades;
using Newtonsoft.Json;

namespace DemoDapperCore.Models
{
    public class CarroViewModel
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Por favor especifique o fabricante do carro.")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Por favor especifique o modelo do carro.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Por favor especifique o ano de fabricação.")]
        [Range(1900, 9999, ErrorMessage = "Por favor preencha um ano valido.")]
        [DisplayName("Ano Fabricação")]
        public int? AnoFabricacao { get; set; }

        public PessoaViewModel Proprietario { get; set; }


        [DisplayName("Proprietário do Veículo")]
        [JsonProperty]
        public string ProprietarioCustomizado => Proprietario == null ? string.Empty : Proprietario.Nome;

        public static explicit operator CarroViewModel(Carro carro)
        {
            if (carro == null)
                return null;

            var viewModel = new CarroViewModel
            {
                Codigo = carro.Codigo,
                AnoFabricacao = carro.AnoFabricacao,
                Proprietario = (PessoaViewModel) carro.Proprietario,
                Fabricante = carro.Fabricante,
                Modelo = carro.Modelo
            };

            return viewModel;
        }
    }
}