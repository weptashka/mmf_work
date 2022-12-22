package service;

public class SortingAlg {

    //кол-во элементарных операций для сортировки вставками
    public static int operations = 0;
    //гибрид вставок и быстрой
    public static void quickInsertSort(int[] arr, int from, int to, int k) {

        if (from < to) {

            //используем сортировку вставками, если число эл-тов,что нужно отсортировать, меньше k
            if(to - from < k){
                insertSort(arr,from,to);

            }

            else {

                //выбираем опорный эл-т, все что меньше него влево, все что больше право
                int divideIndex = partition(arr, from, to);

                //делаем то же самое для правой и левой частей, пока будет что делить

                quickInsertSort(arr, from, divideIndex - 1, k);

                quickInsertSort(arr, divideIndex, to, k);
            }
        }
    }

    private static int partition(int[] arr, int from, int to) {
        int rightIndex = to;
        int leftIndex = from;

        int pivot = arr[from + (to - from) / 2];
        while (leftIndex <= rightIndex) {

            //двигаемся от начала массива к концу пока левый индекс не найдет элемент меньше опорного
            while (arr[leftIndex] < pivot) {
                leftIndex++;
            }

            //и правый больше опорного
            while (arr[rightIndex] > pivot) {
                rightIndex--;
            }

            // они меняются местами

            if (leftIndex <= rightIndex) {
                swap(arr, rightIndex, leftIndex);
                leftIndex++;
                rightIndex--;
            }
        }
        return leftIndex;
    }

    public static void mergeInsertSort(int[] arr, int k){

        if(arr.length < 2)
            return;

        //используем сортировку вставками, если число эл-тов,что нужно отсортировать, меньше k
        if(arr.length <= k){
            insertSort(arr, 0, arr.length - 1);
        }
        else {

            //разбиваем массив на 2 пополам
            int mid = arr.length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.length - mid];

            System.arraycopy(arr, 0, left, 0, mid);
            for (int i = mid; i < arr.length; i++) {
                right[i - mid] = arr[i];
            }
            //рекурсивно делаем это же для каждых его частей и тд, пока размер не будет меньше k
            mergeInsertSort(left, k);
            mergeInsertSort(right, k);
            merge(arr, left, right);
        }


    }

    public static void merge(int[] targetArray, int[] array1, int[] array2){
        int array1MinIndex = 0;
        int array2MinIndex = 0;

        int targetArrayMinIndex = 0;
        //алгоритм слияния(объединяем 2 массива таким образом, чтоб итоговый был отсортирован, те берем наименьшее из чисел из
        // обоих массивов и кладем его в новый и тд)

        while(array1MinIndex < array1.length && array2MinIndex < array2.length) {
            if (array1[array1MinIndex] <= array2[array2MinIndex]) {
                targetArray[targetArrayMinIndex] = array1[array1MinIndex];
                array1MinIndex++;
            } else {
                targetArray[targetArrayMinIndex] = array2[array2MinIndex];
                array2MinIndex++;
            }
            targetArrayMinIndex++;
        }

        while (array1MinIndex < array1.length){
            targetArray[targetArrayMinIndex] = array1[array1MinIndex];
            array1MinIndex++;
            targetArrayMinIndex++;
        }

        while (array2MinIndex < array2.length){
            targetArray[targetArrayMinIndex] = array2[array2MinIndex];
            array2MinIndex++;
            targetArrayMinIndex++;
        }


    }

    private static void swap(int[] array, int index1, int index2) {
        int tmp  = array[index1];
        array[index1] = array[index2];
        array[index2] = tmp;
    }

    //вставками
    private static void insertSort(int[] array, int from, int to){

        for(int i = from;i <= to; i++){
            operations += 4;
            for(int j = i; j > 0 && array[j - 1] > array[j]; j--){
                swap(array, j - 1, j);
                operations += 13;
            }
        }
    }

}
