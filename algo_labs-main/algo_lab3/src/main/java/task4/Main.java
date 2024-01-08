package task4;

import java.util.Arrays;

public class Main {
    public static void main(String[] args) throws Exception {

        int[][] graph = new int[][] {
                {2,3,15},
                {15,10,1},
                {15,2,6}};

        System.out.println(Arrays.toString(HungaryAlgorithm.KuhnMunkres(graph)));

    }
}
