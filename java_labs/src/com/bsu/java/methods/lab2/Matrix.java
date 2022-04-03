package com.bsu.java.methods.lab2;//Lab 2 Var 2

//В следующих лабораторных работах необходимо разработать класс
//(например, класс com.bsu.java.methods.lab2.Matrix). Включить в класс несколько конструкторов.
//Обеспечить возможность клонирования объектов и получения случайных объектов.
//Включить в класс несколько методов, а также метод, указанный в задании.
//Обеспечить тестирование класса.

//Транспонировать квадратную матрицу и умножить исходную матрицу
//на транспонированную. Обеспечить ввод исходной матрицы с консоли.

//com.bsu.java.methods.lab2.Matrix Transposition And Multiplication


import java.util.Random;
import java.util.Scanner;

// Л: приваты к полям забыла дописать
public class Matrix implements Cloneable{
    private int n;
    private int [][] myMatrix;


    public void setN(int n){ this.n = n; }
    public int getN(){ return n; }

    //Л: n=0, myMatrix = null
    //Конструктор 0
    Matrix(){};

    //конструктор 1 (просто создаётсяматрица заданных размеров)
    Matrix(int n){
        this.n = n;
        this.myMatrix = new int[this.n][this.n];
    }

    //Л: random из пакета Math посмотреть
    //конструктор 2 (заполняется случайными значениями от -е до е)
    Matrix(int n, int e){
        Random random = new Random();
        this.n = n;
        this.myMatrix = new int[this.n][this.n];
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++) {
                this.myMatrix[i][j] = random.nextInt(e);
            }
        }
    }

    // Л: можно просто каждую строчу считывать и стразу в массив вносить
    //Конструктор 3
    Matrix(String str){
        String[] lines = str.split("\n");
        int n = lines.length;
        String[][] elements = new String[n][];
        for(int i = 0; i < n; i++){
            elements[i] = lines[i].split(" ");
        }
        this.myMatrix = new int[n][n];
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                this.myMatrix[i][j] = Integer.parseInt(elements[i][j]);
            }
        }
    }


    //В общем тут сложно и непонятно с этим clone
    @Override
    public Matrix clone(){
        Matrix buff = null;
        try{
            buff = (Matrix)super.clone();
            buff.myMatrix = (int[][])myMatrix.clone();
            for(int i = 0; i < this.getSquareMatrixLength(); i++){
                buff.myMatrix[i] = (int[])myMatrix[i].clone();
            }
        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }
        return buff;
    }

    public void transpose() {
        int[][] buff = new int[this.getN()][this.getN()];

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                buff[i][j] = this.getElement(i, j);
            }
        }

        for(int i = 0; i < n; i++){
            for (int j = 0; j < n; j++){
                this.setElement(j, i, buff[i][j]);;
            }
        }
    }



    public void multOnTrans(){
        //"транспонированный" массив
        int[][] buff = new int[this.getN()][this.getN()];

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                buff[j][i] = this.getElement(i, j);
            }
        }

        for(int i = 0; i < n; i++){
            for (int j = 0; j < n; j++){
                int buffEl = 0;
                for(int t = 0; t < n; t++){
                    buffEl += this.getElement(i, t) * buff[t][j];
                }
                this.setElement(i, j, buffEl);;
            }
        }
    }


    //Ввод с консоли
    public void enterMatrix(){
        int num = this.getN();

        Scanner s = new Scanner(System.in);

        System.out.println("Inter matrix: " + getN() + "x" + getN());
        //String enterChar = s.nextLine(); //почистится сборщиком

        String[] strLines = new String[n];
        for(int i = 0; i < num; i++){
            strLines[i] = s.nextLine();
        }

        String[][] strArr = new String[num][];
        for(int i = 0; i < num; i++){
            strArr[i] = strLines[i].split(" ");
        }

        int[][] intArr = new int[num][num];
        for(int i = 0; i < num; i++){
            for(int j = 0; j < num; j++){
                intArr[i][j] = Integer.parseInt(strArr[i][j]);
            }
        }

        this.myMatrix = intArr;

    }


    //достаём значение
    public int getElement(int n, int m){ return this.myMatrix[n][m]; }

    //закладываем значение
    public void setElement(int n, int m, int a){ this.myMatrix[n][m] = a; }

    //получить "длину" матрицы
    public int getSquareMatrixLength(){ return this.myMatrix[0].length; }


    //Л: это всё можно заменить как-то toString'ом
    //показать матрицу
    public void showMatrix(){
        for(int i=0; i<this.n; i++){
            for(int j=0; j < this.n; j++){
                System.out.print(this.getElement(i, j) + " ");
            }
            System.out.println();
        }
        System.out.println();
    }
    }
