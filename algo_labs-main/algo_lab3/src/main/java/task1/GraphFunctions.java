package task1;

public class GraphFunctions {


    // утилита для проверки на двудольность
    static boolean colorGraph(int[][] G, int[] color, int pos, int c)
    {
        if (color[pos] != -1 &&
                color[pos] != c)
            return false;

        color[pos] = c;
        boolean ans = true;
        for (int i = 0; i < G.length; i++)
        {
            if (G[pos][i] == 1)
            {
                if (color[i] == -1)
                    ans &= colorGraph(G, color, i, 1 - c);

                if (color[i] != -1 && color[i] != 1 - c)
                    return false;
            }
            if (!ans)
                return false;
        }
        return true;
    }


    //проверка на двудольность
    static boolean isBipartite(int[][] graph)
    {
        int[] color = new int[graph.length];
        for (int i = 0; i < graph.length; i++)
            color[i] = -1;

        int pos = 0;

        return colorGraph(graph, color, pos, 1);
    }
}
