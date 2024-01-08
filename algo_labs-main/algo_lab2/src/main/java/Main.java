import entity.BinarySortTree;
import entity.Node;
import filling.FillingArray;
import service.BinaryInterpolationSearch;
import service.HashTable;

public class Main {
    public static void main(String[] args) {

        //Задание 1
        System.out.println("First Task:");
        int maxValue = 1000;
        int arrayLength = 1000;
        int elementToFind = 100;
        int[] arrayToFindElement = FillingArray.createRandomArray(arrayLength,maxValue);
        System.out.println(BinaryInterpolationSearch.binarySearch(arrayToFindElement, elementToFind));
        System.out.println(BinaryInterpolationSearch.interpolationSearch(arrayToFindElement,elementToFind));

        System.out.println("Operations for binary: " + BinaryInterpolationSearch.getBinaryComparisonOperationsCount());
        System.out.println("Operations for interpolation: " + BinaryInterpolationSearch.getInterpolationComparisonOperationsCount());



        //Задание 2
        System.out.println("\nSecond Task:");
        int[] array = new int[]{5,45,89,1,17};
        BinarySortTree binarySortTree = new BinarySortTree(array);
        System.out.println("Increasing traversal :" + binarySortTree.increasingTraversal(binarySortTree.getTreeNode()));
        System.out.println("Decreasing traversal :" + binarySortTree.decreasingTraversal(binarySortTree.getTreeNode()));

        Node node = binarySortTree.getTreeNode();
        System.out.println("Start tree: " + node);

        binarySortTree.balanceTree();

        System.out.println("Balanced tree " + binarySortTree);


        //задание 3
        System.out.println("\nThird Task:");

        double CONST = 0.6791154796032413;
        double KNUTH = 0.618033988749894;

        HashTable.multipleMethod(1000,1000,2000, 2500,CONST);
        HashTable.multipleMethod(1000,1000,2000, 2500,KNUTH);

        HashTable.linearProbing(1000,1000,2000, 2500,CONST);
        HashTable.count = 0;
        HashTable.linearProbing(1000,1000,2000, 2500,KNUTH);

        HashTable.doubleHash(1000,1000,2000, 2500,CONST);
        HashTable.doubleHash(1000,1000,2000, 2500,KNUTH);

    }
}
