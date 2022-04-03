package com.bsu.java.methods.lab3;
import java.util.Scanner;

public class MatrixCreator {

    public void fillRandomized(Matrix matrix, int minValue, int maxValue) throws MatrixException {
        int n = matrix.getN();
        int m = matrix.getM();
        for (int i = 0; i < n; i++){
            for (int j = 0; j < m; j++){
                try {
                    int val = (int) ((Math.random() * (maxValue - minValue)) + minValue);
                    matrix.setElement(i, j, val);
                }catch(MatrixException e){
                    System.out.println(e);
                }
            }
        }
    }

    public void enterMatrix(Matrix matrix) throws MatrixException {
        int n = matrix.getN();
        int m = matrix.getM();

        Scanner s = new Scanner(System.in);
        if(n == m){
            System.out.println("Inter Square Matrix: " + n + "x" + m);
        }else{
        System.out.println("Inter Matrix: " + n + "x" + m);
        }

        String[] strLines = new String[n];
        for(int i = 0; i < n; i++){
            strLines[i] = s.nextLine();
        }

        String[][] strArr = new String[n][];
        for(int i = 0; i < n; i++){
            strArr[i] = strLines[i].split(" ");
        }

        int[][] intArr = new int[n][m];
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                intArr[i][j] = Integer.parseInt(strArr[i][j]);
                matrix.setElement(i, j, Integer.parseInt(strArr[i][j]));
            }
        }


    }
}
