namespace EncurtadorUrl.Api.Configurations.Helpers
{
    public class ResponsePayload
    {
        public ResponsePayload(bool success, object data, object errors, object payload)
        {
            Success = success;
            Data = data ?? new { };
            Errors = errors;
            Payload = payload ?? new { };
        }

        public bool Success { get; set; }
        public object Data { get; set; }
        public object Errors { get; set; }
        public object Payload { get; set; }
    }
}
