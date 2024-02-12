namespace POC.Negocio.ViewModels.ErrorsValidator
{
    public class ErrorValidator
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorValidator(string propriedade, string mensagem)
        {
            PropertyName = propriedade;
            ErrorMessage = mensagem;
        }
    }
}
