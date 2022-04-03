package com.bsu.java.methods.lab2;

public class MatrixMain {
    public static void main(String[] args) {
        Matrix m = new Matrix(3, 17);
        System.out.println("Random Matrix");
        m.showMatrix();

        Matrix p = (Matrix)m.clone();
        System.out.println("Matrix - Clone");
        p.showMatrix();

        p.transpose();
        System.out.println("Transpose Matrix p");
        p.showMatrix();


        System.out.println("Matrix m");
        m.showMatrix();

//        Matrix n1 = new Matrix(3);
//        n1.enterMatrix();
//        n1.showMatrix();
//
//        n1.transpose();
//        System.out.println("Transpose Matrix");
//        n1.showMatrix();
//
//        Matrix n2 = new Matrix(3);
//        n2.enterMatrix();
//        n2.showMatrix();
//
//        Matrix n2 = new Matrix(2, 3);
//        System.out.println("Random Matrix");
//        n2.showMatrix();
//
//        n2.multOnTrans();
//        System.out.println("Multiplied on Transpose Matrix");
//        n2.showMatrix();

    }
}
