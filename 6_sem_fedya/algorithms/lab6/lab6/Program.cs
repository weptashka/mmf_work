using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Main
{
    private static int n;
    private static List<int>[] arr;
    private static int[] ans;
    
    private static void Main()
    {
        Solve();
    }

    private static int GetRandomNumber(int min, int max)
    {
        return new Random().Next() * (max - min) + min;
    }

    private static void Solve()
    {
        FileWriter myWriter = new FileWriter("E:/Java Projects/Greedy/src/by/bsu/matrix.txt");
        n = GetRandomNumber(5, 6);
        myWriter.write(n + "");
        myWriter.write("\n");

        var array = new int[n, n];

        for (var i = 0; i < array.Length; i++)
        {
            for (var j = 0; j <= i; j++)
            {
                var x = GetRandomNumber(0, 2);
                if (i == j)
                {
                    x = 1;
                }

                array[i, j] = x;
                if (i != j)
                {
                    array[j, i] = x;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                myWriter.write(array[i, j] + " ");
            }

            myWriter.write("\n");
        }

        Console.WriteLine(n);
        myWriter.close();
        var matrix = new File("E:/Java Projects/Greedy/src/by/bsu/matrix.txt");
        Scanner sc = new Scanner(matrix);
        n = sc.nextInt();
        var arr = new List<int>[n];
        ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            arr[i] = new List<int>();
            for (var j = 0; j < n; j++)
            {
                if (sc.nextInt() == 1)
                {
                    arr[i].Add(j);
                }
            }
        }

        for (var i = 0; i < n; i++)
        {
            if (ans[i] == 0)
            {
                dfs(i);
            }
        }

        foreach (var h in ans)
        {
            Console.WriteLine(h + " ");
        }
    }

    private static void dfs(int index)
    {
        var m = new bool[n + 1];
        foreach (var t in arr[index])
        {
            m[ans[t]] = true;
        }

        for (var i = 1; ans[index] == 0; i++)
        {
            if (!m[i])
            {
                ans[index] = i;
                break;
            }
        }

        foreach (var t in arr[index].Where(t => ans[t] == 0))
        {
            dfs(t);
        }
    }
}
