namespace FIIGetter.Extensions;

public static class StringExtensions
{
    public static float? ToFloatOrNull(this string text)
    {
        if (float.TryParse(text, out var result))
        {
            return result;
        }

        return null;
    }
}
