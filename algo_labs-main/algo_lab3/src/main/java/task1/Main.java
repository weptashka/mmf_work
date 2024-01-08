package task1;

public class Main {


    public static void main(String[] args) {
        int G[][] = { { 0, 1, 0, 1 },
                { 1, 0, 1, 0 },
                { 0, 1, 0, 1 },
                { 1, 1, 1, 0 } };

        Graph g1 = new Graph(5);
        g1.addEdge(1, 0);
        g1.addEdge(0, 2);
        g1.addEdge(2, 1);
        g1.addEdge(0, 3);
        g1.addEdge(3, 4);
        g1.showEulerTestResult();

        if (GraphFunctions.isBipartite(G))
            System.out.print("The graph is Bipartite");
        else
            System.out.print("The graph isn't Bipartite");
    }
}