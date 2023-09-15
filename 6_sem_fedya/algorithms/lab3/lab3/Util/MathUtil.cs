namespace lab3.Util
{
    public class MathUtil
    {
        public static long Pow(long x, int pow)
        {
            long result = 1;
            for (var i = 0; i < pow; i++)
            {
                result *= x;
            }

            return result;
        }
    }
}