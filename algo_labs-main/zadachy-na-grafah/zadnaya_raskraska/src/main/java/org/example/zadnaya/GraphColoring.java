package org.example.zadnaya;


public class GraphColoring {
    private int numOfVertices;
    private int[] colors;
    private int[][] adjacencyMatrix;
    private int maxCol = 0;

    public GraphColoring(int[][] adjacencyMatrix) {
        this.adjacencyMatrix = adjacencyMatrix;
        this.numOfVertices = adjacencyMatrix.length;
        this.colors = new int[numOfVertices];  // сопоставление вершина-цвет
    }

    public void colorGraph() {
        for (int vertex = 0; vertex < numOfVertices; vertex++) {

            int avaliable[] = new int[vertex];
            int notAvaliable[] = new int[vertex];

            for(int i = 0; i < vertex; i++){
                if(adjacencyMatrix[vertex][i] == 0) {
                    avaliable[i] = colors[i];
                }
                if(adjacencyMatrix[vertex][i] == 1){
                    notAvaliable[i] = colors[i];
                }
            }

            System.out.println("/n" + vertex);

            for(int j = 0; j < avaliable.length; j++){
                System.out.print(avaliable[j] + " ");
            }
            System.out.println();

            for(int j = 0; j < notAvaliable.length; j++){
                System.out.print(notAvaliable[j] + " ");
            }
            System.out.println();



            for(int j = 0; j < avaliable.length; j++){
                if(avaliable[j] != 0 && colors[vertex] == 0){
                    colors[vertex] = avaliable[j];
                    //проверим - вдруг этот возможный цвет уже имеют смежные вершины
                    for (int k = 0; k < notAvaliable.length; k++){
                        System.out.println("aval: " + avaliable[j] + "    notAval: " + notAvaliable[k]);
                        if(notAvaliable[k] != 0 && avaliable[j] == notAvaliable[k]){
                            colors[vertex] = 0;
                        }
                    }
                    System.out.println("vertex" + vertex + " color is " + colors[vertex]);

                }
            }


            if(colors[vertex] == 0){
                System.out.println("Vertex " + vertex +  " color= " + (maxCol + 1));

                maxCol += 1;
                colors[vertex] = maxCol;
            }
        }

    }

    public void printColors() {
        System.out.println("Vertex\tColor");
        for (int vertex = 0; vertex < numOfVertices; vertex++) {
            System.out.println(vertex + "\t" + "\t" + colors[vertex]);
        }
    }

}