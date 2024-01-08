package task2;

public class Main {
    final static int INF = 99999;
    public static void main (String[] args)
    {

        //задаем матрицу
        int[][] graph = {{0, INF, INF, INF, INF, 3, 7},
                {INF, 0, 3, 1, INF, INF, INF},
                {INF, 6, 0, INF, INF, INF, INF},
                {INF, INF, 4, 0, INF, INF, 3},
                {INF, INF, INF, 1, 0, 1, INF},
                {5, INF, INF, INF, INF, 0, INF},
                {6, 9, INF, 11, INF, INF, 0}};
        FloydWarshall a = new FloydWarshall();

        a.floydWarshall(graph);
    }
}

