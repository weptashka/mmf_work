namespace lab4
{
    public class Route
    {
        public static int GetDistanceBetweenNodes(int[,] weights, int index1, int index2)
        {
            return weights[index1, index2];
        }

        public static int GetRouteWeights(int nodesCount, int[,] weights, int[] route)
        {
            var weight = 0;

            for (var i = 0; i < route.Length - 1; i += 1)
            {
                var currentNodeIndex = route[i];
                var nextNodeIndex = route[i + 1];

                weight += weights[currentNodeIndex, nextNodeIndex];
            }

            weight += weights[nodesCount - 1, route[0]];

            return weight;
        }

        public static int[] SwapNodes(int[] route, int index1, int index2)
        {
            var newRoute = new int[route.Length];

            route.CopyTo(newRoute, 0);

            (newRoute[index1], newRoute[index2]) = (newRoute[index2], newRoute[index1]);

            return newRoute;
        }
    }
}