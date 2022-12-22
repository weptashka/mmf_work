package service;
public class Experiment {

    //эксперимент для поиска оптимального k
    public static int mergeInsertExperiment(int[] array){

        int minK = array.length;
        long currentTime = System.nanoTime();
        SortingAlg.mergeInsertSort(array,minK);
        long newTime = System.nanoTime();
        long minDelayArray = newTime - currentTime;

        //перебор всех возможных вариантов k
        for(int i = minK - 1; i > 0; i--){
            currentTime = System.nanoTime();
            SortingAlg.mergeInsertSort(array,i);
            newTime = System.nanoTime();
            long msDelayArray = newTime - currentTime;
            if(msDelayArray < minDelayArray){
                minDelayArray = msDelayArray;
                minK = i;
            }

        System.out.println(i + ":" + msDelayArray);

        }
        return minK;
    }

    public static int quickInsertExperiment(int[] array){

        int minK = array.length;
        long currentTime = System.nanoTime();
        SortingAlg.quickInsertSort(array,0,array.length - 1, minK);
        long newTime = System.nanoTime();
        long minDelayArray = newTime - currentTime;

        for(int i = minK - 1; i > 0; i--){
            currentTime = System.nanoTime();
            SortingAlg.quickInsertSort(array,0,array.length - 1,i);
            newTime = System.nanoTime();
            long msDelayArray = newTime - currentTime;
            if(msDelayArray < minDelayArray){
                minDelayArray = msDelayArray;
                minK = i;
            }

          System.out.println(i + ":" + msDelayArray);

        }
        return minK;
    }



}

