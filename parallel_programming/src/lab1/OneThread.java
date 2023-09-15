package lab1;

public class OneThread {
    public static void main(String[] args) {
        QuadraticEquationThread qet1 = new QuadraticEquationThread();
        System.out.println("Hello world!");
        qet1.start();
    }
}
