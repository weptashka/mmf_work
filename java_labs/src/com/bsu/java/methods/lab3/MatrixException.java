package com.bsu.java.methods.lab3;

public class MatrixException extends Exception{
    public MatrixException(){}
    public MatrixException(String message){
        super(message);
    }
    public MatrixException(Throwable cause){
        super(cause);
    }
}
