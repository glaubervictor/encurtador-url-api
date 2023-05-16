namespace EncurtadorUrl.Api.Configurations.Helpers
{
    public class ErrorMessage
    {
        public ErrorMessage(string message, string field, string type)
        {
            Message = message;
            Field = field;
            Type = type;
        }

        public string Message { get; set; }
        public string Field { get; set; }
        public string Type { get; set; }

        public static ErrorMessage Create(string message, string field, string type)
        {
            return new ErrorMessage(message, field, type);
        }

        public static ErrorPayload Create(bool isValid, string message, string field, string type)
        {
            return new ErrorPayload(isValid, Create(message, field, type));
        }
    }
}
