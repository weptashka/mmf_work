package com.bsu.java.methods.lab1;//Lab 1 Var 2

//Ввести n строк с консоли (n – аргумент командной строки).
//Найти самую короткую строку. Вывести эту строку и ее длину.

import java.util.InputMismatchException;
import java.util.Scanner;
import static java.lang.System.exit;

public class FindShortestString {
    public static void main(String[] args) {

        System.out.println("Inter number of strings:");
        Scanner s = new Scanner(System.in);

        try {
            int n = s.nextInt();

            if(n <= 0){
                System.out.println("Only natural numbers can be entered.");
                exit(0);
            }

            System.out.println("Inter strings:");
            String[] arrStr = new String[n];

           // String enterChar = s.nextLine(); //почистится сборщиком

            for(int i = 0; i < n; i++){
                arrStr[i] = s.nextLine();
            }

            String shortStr = arrStr[0];
            for(int i = 1; i < n; i++){
                if(arrStr[i].length() < shortStr.length()) shortStr = arrStr[i];
            }

            System.out.println("\nThe shortest string(s):\n" + shortStr);

            //если много самых коротких строк
            for(int i = 0; i < n; i++){
                if((arrStr[i].length() == shortStr.length()) && (shortStr.compareTo(arrStr[i]) != 0))
                    System.out.println(arrStr[i]);;

            }
        }catch (InputMismatchException e){
            System.out.println("Only natural numbers can be entered.\nException: " + e);
        }
    }

}
