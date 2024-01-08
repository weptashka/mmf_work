//2.15. Г={0,1,2}. Считая непустое слово P записью положительного троичного
//        числа, уменьшить это число на 1.


import java.util.Scanner;
public class TuringMachine2 {
    //количество элементов в линии (-2)
    static int n = 7;
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        //массив строк (пушто с чарами сложно)
        String[] line = new String[n];

        //_ - blank
        line[0] = "_";
        line[n - 1] = "_";

        System.out.println("Inter " + (n - 2) + " symbols - '0' '1' or '2' :");
        for (int i = 1; i < n - 1; i++) {
            line[i] = scanner.nextLine();
        }

        System.out.println("Your line :");
        show(line);

        //указатель находится на этом элементе линии
        //кареткой будет цифра ячейки - num
        int num = 0;

        //начальное состояние
        String state = "start";
        start(line, num, state);
    }

    public static void show(String[] line){
        for(int i = 0; i < n; i++){
            System.out.print(line[i] + "");
        }
        System.out.println();
    }
    public static void start(String[] line, int num, String state){
        System.out.println("----start----");
        switch(line[num]){
            case "0":
                System.out.println("caret №" + num + " - 0 => num++");
                num++; // перевод каретки вправо
                show(line);
                check(line, num, state);
                break;
            case "1":
                System.out.println("caret №" + num + " - 1 => num++");
                num++;
                show(line);
                check(line, num, state);
                break;
            case "2":
                System.out.println("caret №" + num + " - 2 => num++");
                num++;
                show(line);
                check(line, num, state);
                break;
            case "_":
                System.out.println("caret №" + num + " - blank => num++");
                num++;
                show(line);
                check(line, num, state);
                break;
            default:
                System.out.print("element isn't  from set");
                state = "end";
                break;
        }
    }
     public static void check(String[] line, int num, String state){
         state = "check";
         System.out.println("----check----");
         switch(line[num]){
             case "0":
                 System.out.println("caret №" + num + " - 0 => num++");
                 num++;
                 show(line);
                 check(line, num, state);
                 break;
             case "1":
                 System.out.println("caret №" + num + " - 1 => num++");
                 num++;
                 show(line);
                 check(line, num, state);
                 break;
             case "2":
                 System.out.println("caret №" + num + " - 2 => num++");
                 num++;
                 show(line);
                 check(line, num, state);
                 break;
             case "_":
                 System.out.println("caret №" + num + " - blank => num--");
                 num--;
                 show(line);
                 replaceLast(line, num, state);
                 break;
             default:
                 System.out.print("element isn't  from set");
                 state = "end";
                 break;
         }
    }

    public static void replaceLast(String[] line, int num, String state){
        state = "replaceLast";
        System.out.println("----replaceLast----");
        switch(line[num]){
            case "0":
                System.out.println("caret №" + num + " - 0 => change to 2, num--");
                line[num] = "2";
                num--;
                show(line);
                replacePrevious(line, num, state);
                break;
            case "1":
                System.out.println("caret №" + num + " - 1 => change to 0, num++");
                line[num] = "0";
                num++;
                show(line);
                endY(line, num, state);
                break;
            case "2":
                System.out.println("caret №" + num + " - 2 => change to 1, num++");
                line[num] = "1";
                num++;
                show(line);
                endY(line, num, state);
                break;
            default:
                endN(line, num, state);
                break;
        }
    }

    public static void replacePrevious(String[] line, int num, String state){
        state = "replacePrevious";
        System.out.println("----replacePrevious----");
        switch(line[num]){
            case "0":
                System.out.println("caret №" + num + " - 0 => change to 2, num--");
                line[num] = "2";
                num--;
                show(line);
                replacePrevious(line, num, state);
                break;
            case "1":
                System.out.println("caret №" + num + " - 1 => change to 0, num++");
                line[num] = "0";
                num++;
                show(line);
                endY(line, num, state);
                break;
            case "2":
                System.out.println("caret №" + num + " - 2 => change to 1, num++");
                line[num] = "1";
                num++;
                show(line);
                endY(line, num, state);
                break;
            case "_":
                System.out.println("caret №" + num + " - blank => number should be >=1");
                num--;
                show(line);
                endN(line, num, state);
                break;
            default:
                endN(line, num, state);
                break;
        }
    }

    public static void endY(String[] line, int num, String state){
        state = "endY";
        System.out.println("----endY----");
        System.out.println("Program successfully ended!");

    }
    public static void endN(String[] line, int num, String state){
        state = "endN";
        System.out.println("----endN----");
        System.out.println("Program ended with error...");
    }
}