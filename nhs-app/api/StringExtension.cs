namespace api
{
    public static class StringExtensions
    {
        public static bool ContainsAny(this string str, params string[] values)
        {
            if (!string.IsNullOrEmpty(str) || values.Length > 0)
                foreach (var value in values)
                    if (str.Contains(value))
                        return true;

            return false;
        }
    }
}