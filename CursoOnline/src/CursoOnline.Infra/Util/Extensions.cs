namespace CursoOnline.Infra
{
    public static class Extensions
    {
        public static bool HasValue(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return false;

            return true;
        }
    }
}