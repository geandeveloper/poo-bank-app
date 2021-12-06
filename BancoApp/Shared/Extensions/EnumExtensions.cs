namespace BancoApp.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this object? value) => (T)Enum.Parse(typeof(T), value?.ToString()!);
    }
}
