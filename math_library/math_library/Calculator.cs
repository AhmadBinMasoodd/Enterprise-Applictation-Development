namespace math_library
{
    public class Calculator
    {
        public static double sum(params double[] array)
        {   
            double sum = 0;
            foreach(double number in array)
            {
                sum+= number;
            }
            return sum;
        }
    }
}
