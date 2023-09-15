namespace GeneticAlgorithm.utils
{
    public class MathUtil
    {
        public static long Pow(long x, int pow)
        {
            long result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= x;
            }

            return result;
        }

    }
}