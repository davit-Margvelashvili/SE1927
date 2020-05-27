using System.Text.Json;

namespace ExtensionMethods
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object self, bool writeIndented = false) =>
            JsonSerializer.Serialize(self, new JsonSerializerOptions { WriteIndented = writeIndented });

        public static T DeepCopy<T>(this T self)
        {
            var jsonText = JsonSerializer.Serialize(self);
            return JsonSerializer.Deserialize<T>(jsonText);
        }
    }
}