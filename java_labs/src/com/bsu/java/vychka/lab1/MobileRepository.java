package com.bsu.java.vychka.lab1;


//Вариант 10
//Создать класс Mobile с внутренним классом, с помощью объектов которого
//        можно хранить информацию о моделях телефонов и их свойствах


import java.util.Map.Entry;
import java.util.HashMap;
import java.util.Scanner;

public class MobileRepository {
    private static Scanner scanner = new Scanner(System.in);
    private static HashMap<String, HashMap<String, Mobile>> mobiles = new HashMap<>();

    public MobileRepository(){
    }


    static void addMobileToRepository(){
        Mobile.fillMap();
    }

    static void showMobilesInRepo(){
        print();
    }
    static void print(){
        for(Entry<String, HashMap<String, Mobile>> element : mobiles.entrySet()){
            System.out.println("\n-------------------------------"
                    + "\nBrand: " + element.getKey());
            for(Entry<String, Mobile> innerElement : element.getValue().entrySet()){
                System.out.println("Model: " + innerElement.getKey());
                System.out.println("Properties: " + innerElement.getValue().toString());
            }
        }
    }

    static class Mobile{
        String[] properties;

        public Mobile(String[] properties) {
            this.properties = properties;
        }

        static void fillMap(){
            String brand = getBrandNameFromConsole();
            HashMap<String, Mobile> innerMap = fillInnerMap();
            mobiles.put(brand, innerMap);
        }

        private static HashMap<String, Mobile> fillInnerMap(){
            HashMap<String, Mobile> innerMap = new HashMap<>();
            String model = getModelNameFromConsole();
            innerMap.put(model, new Mobile(getPropertiesFromConsole()));
            return innerMap;
        }

        private static String getBrandNameFromConsole() {
            System.out.println("Input brand of this mobile: ");
            return scanner.next();
        }

        private static String getModelNameFromConsole() {
            System.out.println("Input model of this mobile: ");
            return scanner.next();
        }

        private static String[] getPropertiesFromConsole() {
            String enterChar = scanner.nextLine(); //почистится сборщиком(надо из-за nextLine)
            System.out.println("Input properties of this mobile (color, weight, Buttery Amp): ");
            String[] buffProperties = new String[3];
            for(int i = 0; i < 3; i++){
                buffProperties[i] = scanner.nextLine();
            }
            return buffProperties;
        }

        @Override
        public String toString() {
            return "\n    Color: " + properties[0]
                    + "\n    Weight: " + properties[1]
                    + "\n    Battery Amp: " + properties[2]
                    + "\n-------------------------------\n";
        }
    }
}

