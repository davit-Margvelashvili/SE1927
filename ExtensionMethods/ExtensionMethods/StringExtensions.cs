namespace ExtensionMethods
{
    internal static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string self) => string.IsNullOrWhiteSpace(self);
    }
}