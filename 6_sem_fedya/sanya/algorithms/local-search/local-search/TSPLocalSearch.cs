using System;

namespace local_search
{
    public class TSPLocalSearch
    {
        public static int[] Solve(int nodesCount, int[,] weights, int[] route)
        {
            int[] optimalRoute = new int[route.Length];
            route.CopyTo(optimalRoute, 0);
            
            int minRouteWeight = Route.GetRouteWeights(nodesCount, weights, route);
            Console.WriteLine("Initial weight:" + minRouteWeight);

            for (int i = 0; i < route.Length - 3; i += 1)
            {
                for (int j = i + 2; j < route.Length - 1; j += 1)
                {
                    int[] newPossibleRoute = Route.SwapNodes(optimalRoute, i + 1, j);

                    int newWeight = Route.GetRouteWeights(nodesCount, weights, newPossibleRoute);

                    if (newWeight == minRouteWeight)
                    {
                        break;
                    }

                    if (newWeight < minRouteWeight)
                    {
                        Console.WriteLine("Weight:" + newWeight);
                        Console.WriteLine("[{0}]", string.Join(", ", newPossibleRoute));
                        minRouteWeight = newWeight;
                        optimalRoute = newPossibleRoute;
                    }
                }
            }

            // Console.WriteLine("Optimal weight:" + minRouteWeight);
            return optimalRoute;
        }
    }
}