package com.bsu.java.vychka.lab2;

public class House implements IHouse {

    private boolean isBuilt;
    private boolean isRepeared;
    private int rooms;
    private double area;
    private double pricePerSqMeter;

    House(){}

    House(int rooms, double area){
        this.rooms = rooms;
        this.area = area;
    }
    @Override
    public void buildHouse(int roomNum, double area) {
        this.rooms = roomNum;
        this.area = area;
        this.isBuilt = true;
    }


    @Override
    public void calcPricePerSqMeter(double wholePrice) {
        this.pricePerSqMeter = wholePrice/area;
    }



    @Override
    public void increaseArea(double plusArea) {
        if(plusArea > 0){this.area += plusArea; }
        else{
            System.out.println("Добавляемая площадь не может быть больше 0");
        }
    }

    @Override
    public void makeRepair() {
        this.isRepeared = true;
    }

    String toString(boolean a){
        String str = "No";
        if(a) str = "Yes";
        return str;
    }

    @Override
    public void showInfo() {
        System.out.println("\nAREA : " + this.area
        + "\nPRICE PER METER : " + this.pricePerSqMeter
        + "\nNUM of ROOMS : " + this.rooms
        + "\nIS BUILD : " + toString(this.isBuilt)
        + "\nIS REPEARED : " + toString(this.isRepeared)
        + "\n--------------------------------------------\n\n");
    }


}
