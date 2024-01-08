package service;

import java.util.ArrayList;
import java.util.HashMap;

public class HashTable {
    public static final double KNUTH_CONST = 0.618033988749894;
    public static int count = 0;
    public HashMap<Integer, ArrayList<Integer>> hashCodeTable;
    public double MYCONST;
    public int sizeHashTable;

    public HashTable(int size, double MYCONST) {
        hashCodeTable = new HashMap();
        this.MYCONST = MYCONST;
        this.sizeHashTable = size;
    }

    public int getHash(int key) {
        double keys = key * MYCONST;
        return (int)(sizeHashTable * (keys - (int)keys));
    }

    public int getDoubleHash(int key){
        return getHash(getHash(key));
    }

    //если найден эл-т с таким же хэшем, добавляем его в коллекцию к предыдущему, если нет, создаем ее и кидаем туда эл-т и его хэш
    public void addElem(int elem){
        int elemHash = getHash(elem);
        if (hashCodeTable.containsKey(elemHash)){
            hashCodeTable.get(elemHash).add(elem);
        }
        else {
            ArrayList<Integer> arrayList = new ArrayList<>();
            arrayList.add(elem);
            hashCodeTable.put(elemHash, arrayList);
        }
    }


    //аналогично для двойного хэширования
    public void addElemWithDoubleHash(int elem){
        int elemHash = getDoubleHash(elem);
        if (hashCodeTable.containsKey(elemHash)){
            hashCodeTable.get(elemHash).add(elem);
        }
        else {
            ArrayList<Integer> arrayList = new ArrayList<>();
            arrayList.add(elem);
            hashCodeTable.put(elemHash, arrayList);
        }
    }

    //если ячейка занята, ищем соседнюю, пока не найдем пустую и помещаем туда элемент(линейное зондирование)
    public void addElemByLinearProbing(int elem) {
        int elemHash = getHash(elem);
        if (hashCodeTable.containsKey(elemHash)) {
            for (int key = elemHash + 1; key < sizeHashTable; key++) {
                count++;
                if (!hashCodeTable.containsKey(key)) {
                    ArrayList<Integer> arrayList = new ArrayList<>();
                    arrayList.add(elem);
                    hashCodeTable.put(elemHash, arrayList);
                    return;
                }
            }
            for (int key = 0; key < elemHash; key++) {
                count++;
                if (!hashCodeTable.containsKey(key)){
                    ArrayList<Integer> arrayList = new ArrayList<>();
                    arrayList.add(elem);
                    hashCodeTable.put(elemHash, arrayList);
                    return;
                }
            }
        } else {
            ArrayList<Integer> arrayList = new ArrayList<>();
            arrayList.add(elem);
            hashCodeTable.put(elemHash, arrayList);
        }
    }

    public void addCollisions(HashMap<Integer,Integer> collisions){

        for (ArrayList<Integer> elements: hashCodeTable.values()) {
            if (!collisions.containsKey(elements.size())) {
                collisions.put(elements.size(), 1);
            }
            else{
                collisions.replace(elements.size(), collisions.get(elements.size()) + 1);
            }
        }

    }


    //эксперименты
    public static void multipleMethod(int packsAmount, int keysAmount, int maxKeyValue, int tableSize, double CONST){


        HashMap<Integer,Integer> collisions = new HashMap<>();
        for (int j = 0; j < packsAmount; j++) {
            ArrayList<Integer> keysPack = new ArrayList<>(keysAmount);
            HashTable hashTable = new HashTable(tableSize, CONST);
            for (int i = 0; i < keysAmount; i++) {
                int value = (int) (Math.random() * maxKeyValue + 0);
                keysPack.add(value);
                hashTable.addElem(value);
            }

            hashTable.addCollisions(collisions);
        }
        double collSum = 0;
        double noColl = 0;

        for (Object key: collisions.keySet()){
            if (key.equals(1)){
                noColl += collisions.get(key);
            }

            collSum += collisions.get(key);
        }

        if (CONST == KNUTH_CONST){
            System.out.println("Средний показатель коллизий для константы Кнута:" + (100 - 100 * noColl / collSum));
        }
        else {
            System.out.println("Средний показатель коллизий для моей константы:" + (100 - 100 * noColl / collSum));
        }

    }

    public static void linearProbing(int packAmount, int keysAmount, int maxKeyValue, int tableSize, double CONST){

        HashMap<Integer,Integer> collisions = new HashMap<>();
        for (int j = 0; j < packAmount; j++) {
            ArrayList<Integer> array = new ArrayList<>(keysAmount);
            HashTable hashTable = new HashTable(tableSize, CONST);
            for (int i = 0; i < keysAmount; i++) {
                int value = (int) (Math.random() * maxKeyValue + 0);
                array.add(value);
                hashTable.addElemByLinearProbing(value);
            }
            hashTable.addCollisions(collisions);
        }

        if(collisions.size()==1){
            if (CONST == KNUTH_CONST){
                System.out.println("Линейное зондирование прошло успешно для константы Кнута с общим числом поиска:" + count);
            }
            else {
                System.out.println("Линейное зондирование прошло успешно для моей константы с общим числом поиска:" + count);
            }
        }
        else{
            System.out.println("Есть коллизии");
        }
    }

    public static void doubleHash(int packsAmount, int keysAmount, int maxKeyValue, int tableSize, double CONST){

        ArrayList<ArrayList<Integer>> arrays = new ArrayList<>();
        HashMap<Integer,Integer> collisions = new HashMap<>();
        for (int j = 0; j < packsAmount; j++) {
            ArrayList<Integer> array = new ArrayList<>(keysAmount);
            HashTable hashTable = new HashTable(tableSize, CONST);
            for (int i = 0; i < keysAmount; i++) {
                int value = (int) (Math.random() * maxKeyValue + 0);
                array.add(value);
                hashTable.addElemWithDoubleHash(value);
            }

            hashTable.addCollisions(collisions);
        }
        double collSum = 0;
        double noColl = 0;

        for (Object key: collisions.keySet()){
            if (key.equals(1)){
                noColl += collisions.get(key);
            }
            collSum += collisions.get(key);

        }
        if (CONST == KNUTH_CONST){
            System.out.println("Средний показатель коллизий для константы Кнута с двойным хешированием:" + (100 - 100 * noColl / collSum));
        }
        else {
            System.out.println("Средний показатель коллизий для моей константы с двойным хешированием:" + (100 - 100 * noColl / collSum));
        }

    }
}

