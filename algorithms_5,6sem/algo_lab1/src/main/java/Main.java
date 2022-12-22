
import exception.IncorrectNumberException;
import service.Experiment;
import service.SortingAlg;

import java.util.Arrays;
import java.util.Scanner;

public class Main {
    public static void main(String... args) throws IncorrectNumberException {

        System.out.println("Enter amount of arrays:");

        Scanner in = new Scanner(System.in);
        //Количество массивов
        int R = in.nextInt();
        if (R <= 0)
            throw new IncorrectNumberException("Incorrect number");


        System.out.println("Enter size of array:");
        //максимальный размер массива
        int N = in.nextInt();
        if (N <= 0)
            throw new IncorrectNumberException("Incorrect number");


        System.out.println("Enter max element:");
        //максимальный элемент
        int M = in.nextInt();
        if (M <= 0)
            throw new IncorrectNumberException("Incorrect number");

        for(int i = 0; i < R; i++)
        {
            System.out.println("\n Sort array № " + (i + 1));
            int[] arr = fillArray(N, M);
            //оптимальные
            int minKMerge = Experiment.mergeInsertExperiment(arr);
            int minKQuick = Experiment.quickInsertExperiment(arr);

            SortingAlg.mergeInsertSort(arr, 500);
            System.out.println(Arrays.toString(arr));
            System.out.println("Amount of elementary operations: " + SortingAlg.operations);

            System.out.println("K for merge sorting: " + minKMerge);
            System.out.println("K for quick sorting: " + minKQuick);
        }

    }

    public static int[] fillArray ( int N, int M){
        int[] array = new int[N];
        for (int i = 0; i < N; i++) {
            array[i] = random(M);
        }
        return array;

    }

    public static int random ( int M){
        return (int) (Math.random() * M);
    }

}
