using System;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();

    // Генерация случайного графа
    static int[,] GenerateRandomGraph(int numVertices)
    {
        int[,] graph = new int[numVertices, numVertices];

        for (int i = 0; i < numVertices; i++)
        {
            for (int j = 0; j < numVertices; j++)
            {
                if (i == j)
                    graph[i, j] = 0;
                else
                    graph[i, j] = random.Next(1, 10); // Генерация случайного расстояния между вершинами
            }
        }

        return graph;
    }
    static void PrintGraph(int[,] graph)
    {
        int numVertices = graph.GetLength(0);

        for (int i = 0; i < numVertices; i++)
        {
            for (int j = 0; j < numVertices; j++)
            {
                Console.Write(graph[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void PrintColors(int[] colors)
    {
        Console.WriteLine("Vertex Colors:");
        for (int i = 0; i < colors.Length; i++)
        {
            Console.WriteLine("Vertex " + i + ": Color " + colors[i]);
        }
    }

    static int[] GetInitialPath(int numVertices)
    {
        int[] path = new int[numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            path[i] = i;
        }
        return path;
    }

    static void PrintPath(int[] path)
    {
        Console.WriteLine("Path:");
        Console.WriteLine(string.Join(" -> ", path));
    }

    // Алгоритм 2-замены для задачи коммивояжера
    static int[] TwoOpt(int[,] graph, int[] path)
    {
        int numVertices = graph.GetLength(0);
        int[] newPath = (int[])path.Clone();
        bool improved = true;

        while (improved)
        {
            improved = false;

            for (int i = 1; i < numVertices - 1; i++)
            {
                for (int j = i + 1; j < numVertices; j++)
                {
                    int[] newPathCandidate = TwoOptSwap(newPath, i, j);

                    int currentDistance = CalculatePathDistance(graph, newPath);
                    int candidateDistance = CalculatePathDistance(graph, newPathCandidate);

                    if (candidateDistance < currentDistance)
                    {
                        newPath = newPathCandidate;
                        improved = true;
                    }
                }
            }
        }

        return newPath;
    }

    // Обмен двух вершин в пути
    static int[] TwoOptSwap(int[] path, int i, int j)
    {
        int numVertices = path.Length;
        int[] newPath = new int[numVertices];

        for (int k = 0; k < i; k++)
            newPath[k] = path[k];

        int dec = 0;
        for (int k = i; k <= j; k++)
        {
            newPath[k] = path[j - dec];
            dec++;
        }

        for (int k = j + 1; k < numVertices; k++)
            newPath[k] = path[k];

        return newPath;
    }

    // Расчет длины пути
    static int CalculatePathDistance(int[,] graph, int[] path)
    {
        int distance = 0;
        int numVertices = path.Length;

        for (int i = 0; i < numVertices - 1; i++)
        {
            int source = path[i];
            int destination = path[i + 1];
            distance += graph[source, destination];
        }

        return distance;
    }


    // Алгоритм DSATUR
    static int[] DSATUR(int[,] graph)
    {
        int numVertices = graph.GetLength(0);
        int[] saturationDegree = new int[numVertices];
        int[] colors = new int[numVertices];
        bool[] availableColors = new bool[numVertices];

        // Инициализация
        for (int i = 0; i < numVertices; i++)
        {
            saturationDegree[i] = 0;
            colors[i] = -1;
            availableColors[i] = true;
        }

        // Назначение цветов вершинам
        colors[0] = 0;

        for (int vertex = 1; vertex < numVertices; vertex++)
        {
            // Подсчет насыщенности вершин
            for (int i = 0; i < numVertices; i++)
            {
                if (graph[vertex, i] == 1 && colors[i] != -1)
                    saturationDegree[vertex]++;
            }

            // Начинаем с максимальной насыщенности
            int maxSaturationVertex = GetMaxSaturationVertex(saturationDegree, colors);
            int color;

            // Находим доступный цвет
            for (color = 0; color < numVertices; color++)
            {
                if (availableColors[color])
                    break;
            }

            colors[maxSaturationVertex] = color;

            // Обновляем насыщенность
            for (int i = 0; i < numVertices; i++)
            {
                if (graph[maxSaturationVertex, i] == 1 && colors[i] != -1)
                    saturationDegree[i]++;
            }

            availableColors[color] = false;
        }

        return colors;
    }

    // Поиск вершины с максимальной насыщенностью
    static int GetMaxSaturationVertex(int[] saturationDegree, int[] colors)
    {
        int maxSaturation = -1;
        int maxSaturationVertex = -1;
        int numVertices = saturationDegree.Length;

        for (int i = 0; i < numVertices; i++)
        {
            if (colors[i] == -1 && saturationDegree[i] > maxSaturation)
            {
                maxSaturation = saturationDegree[i];
                maxSaturationVertex = i;
            }
        }

        return maxSaturationVertex;
    }

    // Алгоритм Кристофидеса для нахождения пути
    static int[] Christofides(int[,] graph)
    {
        int numVertices = graph.GetLength(0);
        int[] path = new int[numVertices + 1];
        List<int> oddVertices = GetOddDegreeVertices(graph);

        // Построение минимального остовного дерева
        int[,] minimumSpanningTree = MinimumSpanningTree(graph);

        // Поиск эйлерова цикла в минимальном остовном дереве
        int[] eulerianPath = EulerianPath(minimumSpanningTree);

        // Удаление повторяющихся вершин из эйлерова цикла
        List<int> uniqueVertices = RemoveDuplicates(eulerianPath);

        // Выделение вершин с нечетной степенью
        List<int> oddDegreeVertices = GetOddDegreeVertices(graph);

        // Построение совершенного паросочетания на вершинах с нечетной степенью
        int[,] perfectMatching = PerfectMatching(graph, oddDegreeVertices);

        // Объединение остовного дерева и совершенного паросочетания
        int[,] combinedGraph = CombineGraphs(minimumSpanningTree, perfectMatching);

        // Поиск эйлерова цикла в объединенном графе
        int[] eulerianCircuit = EulerianCircuit(combinedGraph);

        // Формирование пути с помощью эйлерова цикла
        int index = 0;
        for (int i = 0; i < eulerianCircuit.Length; i++)
        {
            if (!path.Contains(eulerianCircuit[i]))
            {
                path[index] = eulerianCircuit[i];
                index++;
            }
        }

        // Добавление первой вершины в конец пути
        path[numVertices] = path[0];

        return path;
    }

    // Построение минимального остовного дерева
    static int[,] MinimumSpanningTree(int[,] graph)
    {
        int numVertices = graph.GetLength(0);
        int[,] minimumSpanningTree = new int[numVertices, numVertices];

        bool[] visited = new bool[numVertices];
        int[] key = new int[numVertices];
        int[] parent = new int[numVertices];

        for (int i = 0; i < numVertices; i++)
        {
            key[i] = int.MaxValue;
            visited[i] = false;
        }

        key[0] = 0;
        parent[0] = -1;

        for (int count = 0; count < numVertices - 1; count++)
        {
            int minKey = GetMinKey(key, visited);
            visited[minKey] = true;

            for (int v = 0; v < numVertices; v++)
            {
                if (graph[minKey, v] != 0 && !visited[v] && graph[minKey, v] < key[v])
                {
                    parent[v] = minKey;
                    key[v] = graph[minKey, v];
                }
            }
        }

        for (int i = 1; i < numVertices; i++)
        {
            minimumSpanningTree[parent[i], i] = graph[i, parent[i]];
            minimumSpanningTree[i, parent[i]] = graph[i, parent[i]];
        }

        return minimumSpanningTree;
    }

    // Поиск вершины с минимальным ключом
    static int GetMinKey(int[] key, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;
        int numVertices = key.Length;

        for (int v = 0; v < numVertices; v++)
        {
            if (visited[v] == false && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    // Поиск эйлерова пути в графе
    static int[] EulerianPath(int[,] graph)
    {
        int numVertices = graph.GetLength(0);
        int[] path = new int[numVertices];
        int[] circuit = new int[numVertices * numVertices];
        int circuitIndex = 0;

        Stack<int> stack = new Stack<int>();

        // Находим вершину с нечетной степенью
        int startVertex = 0;
        for (int i = 0; i < numVertices; i++)
        {
            int degree = 0;
            for (int j = 0; j < numVertices; j++)
            {
                degree += graph[i, j];
            }

            if (degree % 2 != 0)
            {
                startVertex = i;
                break;
            }
        }

        stack.Push(startVertex);

        while (stack.Count > 0)
        {
            int v = stack.Peek();

            bool found = false;
            for (int u = 0; u < numVertices; u++)
            {
                if (graph[v, u] == 1)
                {
                    found = true;
                    stack.Push(u);
                    graph[v, u] = 0;
                    graph[u, v] = 0;
                    break;
                }
            }

            if (!found)
            {
                circuit[circuitIndex] = stack.Pop();
                circuitIndex++;
            }
        }

        // Обратный порядок вершин
        int index = 0;
        for (int i = circuitIndex - 1; i >= 0; i--)
        {
            path[index] = circuit[i];
            index++;
        }

        return path;
    }

    // Удаление повторяющихся вершин из пути
    static List<int> RemoveDuplicates(int[] path)
    {
        List<int> uniqueVertices = new List<int>();

        foreach (int vertex in path)
        {
            if (!uniqueVertices.Contains(vertex))
                uniqueVertices.Add(vertex);
        }

        return uniqueVertices;
    }

    // Получение вершин с нечетной степенью
    static List<int> GetOddDegreeVertices(int[,] graph)
    {
        List<int> oddDegreeVertices = new List<int>();
        int numVertices = graph.GetLength(0);

        for (int i = 0; i < numVertices; i++)
        {
            int degree = 0;
            for (int j = 0; j < numVertices; j++)
            {
                degree += graph[i, j];
            }

            if (degree % 2 != 0)
                oddDegreeVertices.Add(i);
        }

        return oddDegreeVertices;
    }

    // Построение совершенного паросочетания
    static int[,] PerfectMatching(int[,] graph, List<int> vertices)
    {
        int numVertices = graph.GetLength(0);
        int[,] perfectMatching = new int[numVertices, numVertices];

        bool[] visited = new bool[numVertices];

        foreach (int vertex in vertices)
        {
            visited[vertex] = true;

            int minDistance = int.MaxValue;
            int closestVertex = -1;

            for (int i = 0; i < numVertices; i++)
            {
                if (graph[vertex, i] != 0 && !visited[i] && graph[vertex, i] < minDistance)
                {
                    minDistance = graph[vertex, i];
                    closestVertex = i;
                }
            }

            perfectMatching[vertex, closestVertex] = 1;
            perfectMatching[closestVertex, vertex] = 1;
        }

        return perfectMatching;
    }

    // Объединение двух графов
    static int[,] CombineGraphs(int[,] graph1, int[,] graph2)
    {
        int numVertices = graph1.GetLength(0);
        int[,] combinedGraph = new int[numVertices, numVertices];

        for (int i = 0; i < numVertices; i++)
        {
            for (int j = 0; j < numVertices; j++)
            {
                if (graph1[i, j] != 0)
                    combinedGraph[i, j] = graph1[i, j];
                else if (graph2[i, j] != 0)
                    combinedGraph[i, j] = graph2[i, j];
            }
        }

        return combinedGraph;
    }

    // Поиск эйлерова цикла в графе
    static int[] EulerianCircuit(int[,] graph)
    {
        int numVertices = graph.GetLength(0);
        int[] circuit = new int[numVertices * numVertices];
        int circuitIndex = 0;

        Stack<int> stack = new Stack<int>();

        int startVertex = 0;
        stack.Push(startVertex);

        while (stack.Count > 0)
        {
            int v = stack.Peek();

            bool found = false;
            for (int u = 0; u < numVertices; u++)
            {
                if (graph[v, u] != 0)
                {
                    found = true;
                    stack.Push(u);
                    graph[v, u]--;
                    graph[u, v]--;
                    break;
                }
            }

            if (!found)
            {
                circuit[circuitIndex] = stack.Pop();
                circuitIndex++;
            }
        }

        return circuit;
    }

    static void Main(string[] args)
    {
        int numVertices = 10; // Количество вершин в графе

        int[,] graph = GenerateRandomGraph(numVertices);

        Console.WriteLine("Исходный граф:");
        PrintGraph(graph);

        Console.WriteLine();

        Console.WriteLine("Алгоритм 2-замены:");
        int[] initialPath = GetInitialPath(numVertices);
        int[] twoOptPath = TwoOpt(graph, initialPath);
        int twoOptDistance = CalculatePathDistance(graph, twoOptPath);
        PrintPath(twoOptPath);
        Console.WriteLine("Длина пути: " + twoOptDistance);

        Console.WriteLine();

        Console.WriteLine("Алгоритм DSATUR:");
        int[] dsaturColoring = DSATUR(graph);
        PrintColors(dsaturColoring);

        Console.WriteLine();

        Console.WriteLine("Алгоритм Кристофидеса:");
        int[] christofidesPath = Christofides(graph);
        int christofidesDistance = CalculatePathDistance(graph, christofidesPath);
        PrintPath(christofidesPath);
        Console.WriteLine("Длина пути: " + christofidesDistance);

        Console.ReadLine();
    }
}

