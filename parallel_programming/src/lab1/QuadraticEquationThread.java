package lab1;

public class QuadraticEquationThread extends Thread{
    public void run()
    {
        long n = 100000;

        long m = System.currentTimeMillis();

        for(long i = 0; i < n; i++){
            //генерация целых чисел в промежутке [0,19]
            int a = (int) (( Math.random() * 20 ) + 1);
            int b = (int) (( Math.random() * 20 ) + 1);
            int c = (int) (( Math.random() * 20 ) + 1);

            double D = b*b - 4*a*c;

            if(D > 0){
                double x1 = (- b + Math.sqrt(D)) / (2 * a);
                double x2 = (- b - Math.sqrt(D)) / (2 * a);
                System.out.println(Thread.currentThread() + "   x1: " + x1 + "   x2: " + x2);
            }else if(D == 0){
                double x = (- b + Math.sqrt(D)) / (2 * a);
                System.out.println(Thread.currentThread() + "   x1: " + x + "   x2: " + x );
            }else if(D < 0){
                double d = Math.sqrt(Math.abs(D));
                System.out.println(Thread.currentThread() + "   x1: " + -b/2 + "+" + d/2 + "   x2: " + -b/2 + "-" + d/2);
            }else{
                System.out.println("Something went wrong with discriminant");
            }
        }
        //считаем время работы потока
        double time = (double) (System.currentTimeMillis() - m);
        try {
            Thread.sleep(1000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        System.out.println(Thread.currentThread().getName() + "   " + time + " for " + n + " equations");
    }
}
