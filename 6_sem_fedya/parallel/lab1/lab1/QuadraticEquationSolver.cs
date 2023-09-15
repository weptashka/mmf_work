using System;

namespace lab1
{
    public class QuadraticEquationSolver
    {
        private double a;
        private double b;
        private double c;
        
        public QuadraticEquationSolver(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public void Solve()
        {
            var discriminant = GetDiscriminant();
            
            if (discriminant >= 0)
            {
                var realSolutions = GetRealSolutions(discriminant);
            }
            else
            {
                var imaginarySolutions =  GetImaginarySolutions(discriminant);
            }
        }
        
        public void SolveAndOutputAnswer()
        {
            var discriminant = GetDiscriminant();
            
            if (discriminant >= 0)
            {
                var realSolutions = GetRealSolutions(discriminant);
                Console.WriteLine(realSolutions.Item1 + ", " + realSolutions.Item2);
            }
            else
            {
                var imaginarySolutions =  GetImaginarySolutions(discriminant);
                Console.WriteLine(imaginarySolutions.Item1 + " + " + imaginarySolutions.Item2 + " * i, " + imaginarySolutions.Item1 + " + " + imaginarySolutions.Item3 + " * i ");
            }
        }

        private (double, double) GetRealSolutions(double discriminant)
        {
            var x1 = (-b + Math.Sqrt(discriminant)) / 2 * a;
            var x2 = (-b - Math.Sqrt(discriminant)) / 2 * a;

            return (x1, x2);
        }

        private (double, double, double) GetImaginarySolutions(double discriminant)
        {
            var x1 = -b / (2 * a);
            discriminant = -discriminant ;
            var x2 = Math.Sqrt(discriminant) / (2 * a);
            var x3 = -Math.Sqrt(discriminant) / (2 * a);

            return (x1, x2, x3);
        }

        private double GetDiscriminant()
        {
            return Math.Pow(b, 2) - 4 * a * c;
        }
    }
}