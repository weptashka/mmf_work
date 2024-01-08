package service;

public class BinaryInterpolationSearch {
    private static int binaryComparisonOperationsCount = 0;
    private static int interpolationComparisonOperationsCount = 0;

    //бинарный поиск элемента в массиве(массив делится пополам до тех, пока не будет найден нужный эл-т, если не найден вернет 1)
    public static int binarySearch(int[] array, int elementToSearch){
        Sorting.sortArray(array, 0,array.length - 1);

        int resultIndex = -1;
        int startIndex = 0;
        int lastIndex = array.length - 1;

        while (startIndex <= lastIndex) {
            int mid = (startIndex + lastIndex) / 2;
            binaryComparisonOperationsCount++;
            if (array[mid] < elementToSearch) {
                startIndex = mid + 1;
                binaryComparisonOperationsCount++;
            } else if (array[mid] > elementToSearch) {
                lastIndex = mid - 1;
                binaryComparisonOperationsCount++;
            } else if (array[mid] == elementToSearch) {
                resultIndex = mid;
                binaryComparisonOperationsCount++;
                break;
            }
        }
        return resultIndex;
    }

    //интерполяционный поиск
    public static int interpolationSearch(int[] array, int elementToSearch) {
        Sorting.sortArray(array, 0,array.length - 1);

        int resultIndex = -1;
        int startIndex = 0;
        int lastIndex = array.length - 1;

        while ((startIndex <= lastIndex) && (elementToSearch >= array[startIndex]) &&
                (elementToSearch <= array[lastIndex])) {

            // используем формулу интерполяции для поиска возможной лучшей позиции для существующего элемента
            int pos = startIndex + (((lastIndex-startIndex) /
                    (array[lastIndex]-array[startIndex]))*
                    (elementToSearch - array[startIndex]));

            interpolationComparisonOperationsCount+=3;
            if (array[pos] == elementToSearch){
                resultIndex = pos;
                interpolationComparisonOperationsCount++;
            }

            if (array[pos] < elementToSearch){
                startIndex = pos + 1;
                interpolationComparisonOperationsCount++;
            }

            else
                lastIndex = pos - 1;
        }

        return resultIndex;
    }

    public static int getBinaryComparisonOperationsCount(){
        return binaryComparisonOperationsCount;
    }

    public static int getInterpolationComparisonOperationsCount(){
        return interpolationComparisonOperationsCount;
    }
}
