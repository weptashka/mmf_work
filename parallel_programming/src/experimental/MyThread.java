package experimental;

public class MyThread {
    public void run(){
        System.out.println("I'm thread named " + Thread.currentThread().getName());
    }
}
