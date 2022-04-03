//Классы Matrix (матрица) и SMatrix (квадратная матрица).
// Добавить метод для вычисления определителя.

package com.bsu.java.methods.lab3;

public class TestClass {
    public static void main(String[] args) {
        try {
            //random filling
            MatrixCreator c = new MatrixCreator();
            Matrix m1 = new Matrix(3, 6);
            c.fillRandomized(m1, -5, 5);
            System.out.println(m1.toString());

//            //entering Matrix
//            Matrix m2 = new Matrix(2, 2);
//            c.enterMatrix(m2);
//            System.out.println(m2.toString());

            //entering SMatrix
            SMatrix s1 = new SMatrix(2);
            c.enterMatrix(s1);
            System.out.println(s1.toString());

            System.out.println(s1.calc_det());

        }catch (MatrixException e) {
            System.out.println("Error of creating matrix : " + e);
        }
    }
}
