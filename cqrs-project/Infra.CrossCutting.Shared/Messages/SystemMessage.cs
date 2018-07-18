namespace Infra.CrossCutting.Shared.Messages
{
    public static class SystemMessage
    {
        public const string MsError = "Sistema Indisponível.";
        public const string MsEmail = "E-mail inválido.";
        public const string MsEmpty = "O campo {0} está vazio.";
        public const string MsRange = "O campo {0} deve conter no mínimo {1} e no máximo {2}.";
        public const string MsMinimumAge = "A idade mínima é 18 anos.";
        public const string MsCpfInvalid = "Cpf inválido.";
        public const string MsRequired = "Este campo é de preenchimento obrigatório.";
        public const string MsData = "Data inválida.";
        public const string MsSuccess = "Ação realizada com sucesso.";
    }
}