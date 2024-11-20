namespace Libreria
{
    public static class Conversiones
    {
        public static bool? ToNullableBool(string value)
        {
            bool? bValue = null;

            if (value == null || value == "null")
            {
                bValue = null;
            }
            else
            {
                bValue = bool.Parse(value);
            }

            return bValue;
        }

        public static string ToValueOrStringNull(bool? value)
        {
            if (!value.HasValue)
            {
                return "null";
            }
            else
            {
                return value.Value.ToString();
            }
        }
    }
}
