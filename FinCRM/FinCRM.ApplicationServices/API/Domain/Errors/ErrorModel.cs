namespace FinCRM.ApplicationServices.API.Domain.Errors
{
    public class ErrorModel
    {
        public ErrorModel(string error)
        {
            // w konstruktorze wyślemy ten błąd
            this.Error = error;
        }

        // który zostanie przypisany do Errora i będzie go można odczytać
        public string Error { get; }
    }
}