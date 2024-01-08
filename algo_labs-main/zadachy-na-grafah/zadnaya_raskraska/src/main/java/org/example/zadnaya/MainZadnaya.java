package org.example.zadnaya;

public class MainZadnaya {
    public static void main(String[] args) {
        System.out.println("Hello world!");


        int[][] adjacencyMatrix =
        {
            {0, 1, 1, 0, 1},
            {1, 0, 1, 1, 1},
            {1, 1, 0, 1, 0},
            {0, 1, 1, 0, 0},
            {1, 1, 0, 0, 0},
        };

//                {
//                        {0, 1, 0, 0, 0},
//                        {1, 0, 1, 0, 0},
//                        {0, 1, 0, 1, 0},
//                        {0, 0, 1, 0, 1},
//                        {0, 0, 0, 1, 0},
//                };

        GraphColoring graphColoring = new GraphColoring(adjacencyMatrix);
        graphColoring.colorGraph();
        graphColoring.printColors();
    }

}