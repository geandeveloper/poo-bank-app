namespace BancoApp.Shared.Extensions;

public static class NullableExtensions
{
    public static T OrThrow<T>(this T? nullableObject, string message)
    {
        if (nullableObject == null)
            throw new Exception(message);

        return nullableObject;
    }
}

