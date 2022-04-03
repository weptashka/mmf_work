//Классы Matrix (матрица) и SMatrix (квадратная матрица).
// Добавить метод для вычисления определителя.


package com.bsu.java.methods.lab3;

public class Matrix {
    private int[][] a;

    //Конструктор 1
    public Matrix(int n, int m) throws MatrixException {
        if(n < 1 || m < 1) {
            throw new MatrixException("Error! m or n < 1");
        }
        a = new int[n][m];
    }

    //Конструктор 2
    public Matrix(int n) throws MatrixException {
        if(n < 1) {
            throw new MatrixException("Error! m or n < 1");
        }
        a = new int[n][n];
    }

    //Достать Столбцы, Строки
    public int getN(){ return a.length; }
    public int getM(){ return  a[0].length; }

    //Достать int матрицу
    public int[][] getA() throws MatrixException {
        int[][] A = new int[this.getN()][this.getM()];
        for(int i = 0; i < this.getN(); i++){
            for(int j = 0; j < this.getM(); j++){
                A[i][j] = this.getElement(i, j);
            }
        }
        return A;
    }

    //Достать Элемент
    public int getElement(int i,  int j) throws MatrixException {
        if (checkRange(i, j)) {
            return (a[i][j]);
        } else{
            throw new MatrixException();
        }
    }

    //Заменить/Вставить Элемент
    public void setElement(int i,  int j, int value) throws MatrixException {
        if (checkRange(i, j)) {
            a[i][j] = value;
        } else{
            throw new MatrixException();
        }
    }

    //Вывод матрицы как строки
    @Override
    public String toString(){
        final String BLANK = " ";
        StringBuilder s = new StringBuilder("\nMatrix: " + a.length + "x" + a[0].length + "\n");
            for(int[] row : a){
                for(int value : row){
                    s.append(value).append(BLANK);
                }
                s.append("\n");
            }
        return s.toString();
    }


    private boolean checkRange(int i, int j){
        if(i < 0 || j < 0 || i > a.length - 1 || j > a[0].length){
            return false;
        }
        else return true;
    }


}
