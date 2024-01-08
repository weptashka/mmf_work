package task2;


class FloydWarshall
{
    final static int INF = 99999;

    void floydWarshall(int[][] graph)
    {
        int length = graph.length;
        int[][] dist = new int[length][length];
        int i, j, k;

        for (i = 0; i < length; i++)
            for (j = 0; j < length; j++){
                if(graph[i][j] == INF && graph[j][i] != INF)
                    graph[i][j] = graph[j][i];
            }


        for (i = 0; i < length; i++)
            for (j = 0; j < length; j++)
                dist[i][j] = graph[i][j];


        for (k = 0; k < length; k++)
        {

            for (i = 0; i < length; i++)
            {

                for (j = 0; j < length; j++)
                {
                    if (dist[i][k] + dist[k][j] < dist[i][j])
                        dist[i][j] = dist[i][k] + dist[k][j];
                }
            }
        }

        int[] max = new int[length];
        for (i = 0; i < length; i++) {
            max[i] = dist[i][0];
            for (j = 0; j < length; j++) {
                if (max[i]<dist[i][j])
                    max[i] = dist[i][j];
            }
        }
        int[] res = {INF,0};
        for (i = 0; i < length; i++){
            if (max[i]<res[0]){
                res[0] = max[i];
                res[1] = i;
            }
        }

        printSolution(dist,res);
    }

    void printSolution(int[][] dist, int[] minDist)
    {
        int V = dist.length;
        System.out.println("The following matrix shows the shortest "+
                "distances between every pair of vertices");
        for (int[] ints : dist) {
            for (int j = 0; j < V; ++j) {
                if (ints[j] == INF)
                    System.out.print("INF ");
                else
                    System.out.print(ints[j] + "   ");
            }
            System.out.println();
        }
        System.out.println("Min dist = "+minDist[0]+". Best crossroad: " + minDist[1]);
    }

}
