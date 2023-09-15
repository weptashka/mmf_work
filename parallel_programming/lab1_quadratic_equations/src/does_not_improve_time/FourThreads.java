package does_not_improve_time;

public class FourThreads {
    // создаём объекты класса, реализующего интерфейс Runnable
    static QuadraticEquation qe1;
    static QuadraticEquation qe2;
    static QuadraticEquation qe3;
    static QuadraticEquation qe4;
    public static void main(String[] args) {

        qe1 = new QuadraticEquation();
        qe2 = new QuadraticEquation();
        qe3 = new QuadraticEquation();
        qe4 = new QuadraticEquation();

        // создаём 4 потока
        Thread myThread1 = new Thread(qe1);
        Thread myThread2 = new Thread(qe2);
        Thread myThread3 = new Thread(qe3);
        Thread myThread4 = new Thread(qe4);

        myThread1.start();
        myThread2.start();
        myThread3.start();
        myThread4.start();

    }
}