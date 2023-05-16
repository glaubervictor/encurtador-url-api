using EncurtadorUrl.Api.Configurations.Helpers;
using EncurtadorUrl.Api.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace EncurtadorUrl.Api.Controllers.Base
{
    [ApiController, Route("[controller]"), Consumes("application/json"), Produces("application/json")]
    public abstract class ApiController : ControllerBase
    {
        private object _error;
        protected Collection<object> Errors;

        public ApiController()
        {
            Errors = new Collection<object>();
        }

        protected IActionResult Success(object data = null, object payload = null) => Payload(true, data, payload);

        protected IActionResult Error()
        {
            return Payload(false, null, null);
        }

        protected IActionResult Error(string message, object data = null, object payload = null)
        {
            _error = message;
            return Payload(false, data, payload);
        }

        protected IActionResult Payload(bool success, object data = null, object payload = null)
        {
            var errors = _error ?? (Errors.Any() ? Errors : null);
            var responsePayload = new ResponsePayload(success, data, errors, payload);

            if (_error != null)
                Errors.Add(_error);

            return new ContentResult
            {
                StatusCode = !success ? 400 : Request.Method.ToUpper() == "POST" ? 201 : 200,
                ContentType = "application/json",
                Content = responsePayload.ToJson()
            };
        }

        protected void SetError(string message, string field, string type)
        {
            _error = ErrorMessage.Create(message, field, type);
        }

        protected void AddError(bool isValid, string message, string field, string type)
        {
            Errors.Add(ErrorMessage.Create(isValid, message, field, type));
        }
    }
}
