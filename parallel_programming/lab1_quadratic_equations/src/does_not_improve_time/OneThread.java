package does_not_improve_time;

public class OneThread {
    static QuadraticEquation qe;
    public static void main(String[] args) {
        Thread myThread = new Thread(qe = new QuadraticEquation());
        myThread.start();
    }
}
