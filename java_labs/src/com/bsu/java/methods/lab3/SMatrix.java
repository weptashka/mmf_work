package com.bsu.java.methods.lab3;

public class SMatrix extends Matrix {


    public SMatrix(int n) throws MatrixException {
        super(n);
    }

    public double calc_det() throws MatrixException {
        double det = 0;
        int[][] A = this.getA();
        if(this.getN() == 1){
            det = A[0][0];
        }
        if(this.getN() == 2){
            det = A[0][0] * A [1][1] - A[0][1]*A[1][0];
        }
        if(this.getN() == 3){
            det = A[0][0]*(A[1][1]*A[2][2] - A[2][1]-A[1][2]) -
                    A[0][1]*(A[1][0]*A[2][2] - A[2][0]-A[1][2])+
                    A[0][2]*(A[1][0]*A[2][1] - A[2][0]-A[1][1]);
        }
        if(this.getN() > 3){
            System.out.println("max matrix range for det = 3");
        }
        return det;
    }

}
