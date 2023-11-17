namespace Megasave.Domain.Entities
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string ErrorMessage { get; set; }
        public string ErrorMessageDetail { get; set; }
    }
}