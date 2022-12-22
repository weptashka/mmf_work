package com.bsu.java.methods.lab4;

import java.io.IOException;

//В тексте после буквы Р, если она не последняя в слове,
//ошибочно напечатана буква А вместо О. Внести исправления в текст.

public class Main {

    public static void main(String[] args) {
        try {
            AOReplacing text1 = new AOReplacing("D:\\JAVAwork\\IDEAProjects\\java-labs\\src\\text.txt");
            text1.replaceao();
        } catch (IOException e) {
            System.out.println("Ошибка открытия файла");
        }
    }
}