using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Params;
using Infra.CrossCutting.Shared.Messages;
using Site.Helpers;

namespace Site.Models
{
    public class CustomerViewModel
    {
        [Key] public Guid Id { get; set; }

        [Required(ErrorMessage = SystemMessage.MsRequired)]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = SystemMessage.MsRequired)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = SystemMessage.MsData)]
        [DisplayName("BirthDate")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = SystemMessage.MsRequired)]
        [EmailAddress(ErrorMessage = SystemMessage.MsEmail)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = SystemMessage.MsRequired)]
        [Cpf]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        public static explicit operator CustomerParam(CustomerViewModel model)
        {
            model.BirthDate = model.BirthDate ?? DateTime.MinValue;

            return model == null
                ? null
                : new CustomerParam(model.Id, model.Name, model.BirthDate.Value, model.Email, model.Cpf);
        }
    }
}