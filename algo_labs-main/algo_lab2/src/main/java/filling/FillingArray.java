package filling;

import java.util.Random;

public class FillingArray {
    //заполнить массив рандомными числами
    public static int[] createRandomArray(int arrayLength, int maxValue){
        int[] array = new int[arrayLength];
        long seed = 79287098;
        Random random = new Random(seed);
        for(int i = 0; i < arrayLength; i++){
            array[i] = (int)(random.nextDouble() * maxValue);
        }

        return array;
    }
}
