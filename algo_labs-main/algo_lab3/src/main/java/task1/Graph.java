package task1;

import java.util.Arrays;
import java.util.LinkedList;

public class Graph {
    private int verticesAmount;   // кол-во вершин графа

    // Массив списков смежности вершин
    private LinkedList<Integer> vertices[];


    Graph(int vertices) {
        verticesAmount = vertices;
        this.vertices = new LinkedList[vertices];
        for (int i = 0; i < vertices; ++i)
            this.vertices[i] = new LinkedList();
    }

    //добавление ребра в граф
    void addEdge(int v, int w) {
        vertices[v].add(w);
        vertices[w].add(v);
    }

    // обход графа
    void traversal(int v, boolean[] visited) {
        // помечаем текущую вершину пройденной
        visited[v] = true;

        // рекурсивно для всех вершин смежных с данной
        for (int n : vertices[v]) {
            if (!visited[n])
                traversal(n, visited);
        }
    }

    // является ли граф связным
    boolean isConnected() {
        // Все вершины помечаются не посещенными
        boolean[] visited = new boolean[verticesAmount];
        int i;
        for (i = 0; i < verticesAmount; i++)
            visited[i] = false;

        // ищем вершину с ненулевой степенью
        for (i = 0; i < verticesAmount; i++)
            if (vertices[i].size() != 0)
                break;

        // если таких не оказалось, граф связный
        if (i == verticesAmount)
            return true;

        // начинаем обход с вершины с ненулевой степенью
        traversal(i, visited);

        // посещены ли все вершины ненулевой степени
        for (i = 0; i < verticesAmount; i++)
            if (!visited[i] && vertices[i].size() > 0)
                return false;

        return true;
    }

    /*
       0 --> If graph is not Eulerian
       1 --> If graph has an Euler path (Semi-Eulerian)
       2 --> If graph has an Euler Circuit (Eulerian)  */
    int isEulerian() {
        // если не связный -> не эйлеров
        if (!isConnected())
            return 0;

        // Считает вершины с четной степенью
        int odd = 0;
        for (int i = 0; i < verticesAmount; i++)
            if (vertices[i].size() % 2 != 0)
                odd++;

        // если вершин больше 2 -> не явл. эйлеровым
        if (odd > 2)
            return 0;

        // Если  2, то полуэйлеров.
        // Если 0, то эйлеров
        // 1 получиться не может
        return (odd == 2) ? 1 : 2;
    }

    // показывает результат проверки
    void showEulerTestResult() {
        int res = isEulerian();
        if (res == 0)
            System.out.println("graph is not Eulerian for graph" + this.toString());
        else if (res == 1)
            System.out.println("graph has a Euler path for graph" + this.toString());
        else
            System.out.println("graph has a Euler cycle for graph" + this.toString());
    }


    @Override
    public String toString() {
        return "Graph{" +
                "verticesAmount=" + verticesAmount +
                ", vertices=" + Arrays.toString(vertices) +
                '}';
    }
}
