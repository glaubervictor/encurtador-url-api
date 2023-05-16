using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EncurtadorUrl.Api.Shared.Extensions
{
    public static class GenericExtensions
    {
        public static string ToJson<T>(this T obj) where T : class
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public static string GenerateShortUrl()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var id = new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return $"http://chr.dc/{id}";
        }
    }
}
