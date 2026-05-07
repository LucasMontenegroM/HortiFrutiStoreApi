namespace HortiFrutiStore.Application.DTOs
{
    public class DtoBase
    {
        public bool IsValid { get; set; }
        public string MensagemErro { get; set; } = string.Empty;
    }
}
