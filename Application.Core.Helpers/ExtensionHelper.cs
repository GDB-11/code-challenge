using System.Text.Json;

namespace Application.Core.Helpers
{
    public static class ExtensionHelper
    {
        public static string ToJson(this object obj)
        {
            var response = default(string);

            var netJsonSerializer = new JsonSerializerOptions
            {
                MaxDepth = 64
            };

            if (obj is not null)
                response = JsonSerializer.Serialize(obj, netJsonSerializer);

            return response;
        }
    }
}
