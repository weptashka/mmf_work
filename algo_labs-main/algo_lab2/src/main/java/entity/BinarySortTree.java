package entity;

import java.util.*;

//класс самого дерева, состоящего из узлов
public class BinarySortTree {
    private static final int INCORRECT_ORDER = -1;
    private static final int ALLOWED_IMBALANCE = 1;
    private List<Integer> treeElementsIncreasing = new ArrayList<>();
    private List<Integer> treeElementsDecreasing = new ArrayList<>();

    //корень всего дерева(самый верхний узел)
    private Node treeNode;

    public Node getTreeNode() {
        return treeNode;
    }

    public BinarySortTree(Node node){
        this.treeNode = node;
    }

    public BinarySortTree(int[] array) {
        //с помощью LinkedHashSet избавляемся от повторяющихся значений
        Set<Integer> uniqueSet = new LinkedHashSet<>();
        for (int i = 0; i < array.length; i++){
            uniqueSet.add(array[i]);
        }

        for (int element : uniqueSet) {
            insertElement(element);
        }
    }

    // вставить узел в корень
    private void insertElement(int element) {
        this.treeNode = insertElement(this.treeNode, element);
    }


    private Node insertElement(Node node, int element) {
        //если изначальный узел null, создаем его
        if (node == null)
            return new Node(element);

            //если элемент, болльше чем в узле помещаем левее, если больше - правее
        else if (node.getValue() > element)
            node.setLeftChild(insertElement(node.getLeftChild(), element));
        else
            node.setRightChild(insertElement(node.getRightChild(), element));
        return node;
    }


    //обход всего дерева(насколько я понял по возрастанию узлов имеется в виду по возрастанию значений)
    public List<Integer> increasingTraversal(Node node) {

        if (node.getLeftChild() != null) {
            increasingTraversal(node.getLeftChild());
        }
        treeElementsIncreasing.add(node.getValue());

        if(node.getRightChild() != null){
            increasingTraversal(node.getRightChild());
        }

        return treeElementsIncreasing;
    }

    //аналогично, но по убыванию
    public List<Integer> decreasingTraversal(Node node){

        if (node.getRightChild() != null) {
            decreasingTraversal(node.getRightChild());
        }
        treeElementsDecreasing.add(node.getValue());

        if(node.getLeftChild() != null){
            decreasingTraversal(node.getLeftChild());
        }

        return treeElementsDecreasing;
    }

    //k-ый минимальный элемент в дереве находим
    public int getMinKey(int elementOrder){
        treeElementsIncreasing.clear();
        List<Integer> elements = increasingTraversal(treeNode);
        return elements.size() >= elementOrder ? elements.get(elementOrder) : INCORRECT_ORDER;
    }

    public void balanceTree(){
        treeElementsIncreasing.clear();
        this.treeNode = buildBalanceNode(0,increasingTraversal(treeNode).size()-1);
    }

    public Node buildBalanceNode(int startIndex, int endIndex){
        if(startIndex > endIndex)
            return null;

        int middleElementIndex = (startIndex + endIndex) / 2;
        Node node = new Node(getMinKey(middleElementIndex));
        node.setLeftChild(buildBalanceNode(startIndex, middleElementIndex - 1));
        node.setRightChild(buildBalanceNode(middleElementIndex + 1,endIndex));

        return balanceOneNode(node);
    }

    public Node balanceOneNode(Node node) {
        if (node == null) {
            return node;
        }

        // Разница в высоте между левым поддеревом и правым поддеревом превышает 1
        if (nodeHeight(node.getLeftChild()) - nodeHeight(node.getRightChild()) > ALLOWED_IMBALANCE) {
            if (nodeHeight(node.getLeftChild().getLeftChild()) >= nodeHeight(node.getRightChild().getRightChild()))
                node = rotateWithLeftChild(node);
            else
                node = doubleWithLeftChild(node);

        }
        else if (nodeHeight(node.getRightChild()) - nodeHeight(node.getLeftChild()) > ALLOWED_IMBALANCE) {
            if (nodeHeight(node.getRightChild().getRightChild()) >= nodeHeight(node.getRightChild().getRightChild()))
                node = rotateWithRightChild(node);
            else
                node = doubleWithRightChild(node);
        }

        return node;
    }

    // Одно вращение ---> Соответствующий дисбаланс: ---> Высота левого узла левого поддерева больше высоты правого узла левого поддерева
    private Node rotateWithLeftChild(Node nodeToRotate) {
        Node nodeToRotateLeftChild = nodeToRotate.getLeftChild();
        nodeToRotate.setLeftChild(nodeToRotateLeftChild.getRightChild());
        nodeToRotateLeftChild.setRightChild(nodeToRotate);
        return nodeToRotateLeftChild;
    }

    // Одиночное вращение ---> Соответствующий дисбаланс: ---> Высота правого узла правого поддерева больше, чем высота левого узла правого поддерева
    private Node rotateWithRightChild(Node nodeToRotate) {
        Node nodeToRotateRightChild = nodeToRotate.getRightChild();
        nodeToRotate.setRightChild(nodeToRotateRightChild.getLeftChild());
        nodeToRotateRightChild.setLeftChild(nodeToRotate);
        return nodeToRotateRightChild;
    }

    // Двойное вращение ---> Соответствующий дисбаланс: ---> Высота левого узла левого поддерева меньше высоты правого узла левого поддерева
    private Node doubleWithLeftChild(Node nodeToRotate) {
        nodeToRotate.setLeftChild(rotateWithLeftChild(nodeToRotate.getLeftChild()));
        return rotateWithLeftChild(nodeToRotate);
    }

    // Двойное вращение ---> Соответствующий дисбаланс: ---> Высота правого узла правого поддерева меньше высоты левого узла правого поддерева
    private Node doubleWithRightChild(Node nodeToRotate) {
        nodeToRotate.setRightChild(rotateWithLeftChild(nodeToRotate.getRightChild()));
        return rotateWithLeftChild(nodeToRotate);
    }

    private int nodeHeight(Node node)
    {
        if (node == null)
            return -1;

        return 1 + Math.max(nodeHeight(node.getLeftChild()),
                nodeHeight(node.getRightChild()));

    }


    @Override
    public String toString() {
        return "BinarySortTree{" +
                "treeNode=" + treeNode +
                '}';
    }
}
