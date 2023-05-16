namespace EncurtadorUrl.Api.Configurations.Helpers
{
    public class ErrorPayload
    {
        public ErrorPayload(bool isValid, ErrorMessage error)
        {
            IsValid = isValid;
            Error = error;
        }

        public bool IsValid { get; set; }
        public ErrorMessage Error { get; set; }
    }
}
