package lab1;

public class FourThreads {
    public static void main(String[] args) {
        QuadraticEquationThread qet1 = new QuadraticEquationThread();
        QuadraticEquationThread qet2 = new QuadraticEquationThread();
        QuadraticEquationThread qet3 = new QuadraticEquationThread();
        QuadraticEquationThread qet4 = new QuadraticEquationThread();
        System.out.println("Hello world!");
        qet1.start();
        qet2.start();
        qet3.start();
        qet4.start();
    }
}