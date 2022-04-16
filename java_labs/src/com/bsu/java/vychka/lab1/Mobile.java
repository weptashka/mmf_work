package com.bsu.java.vychka.lab1;
import java.util.Scanner;

//Вариант 10
//Создать класс Mobile с внутренним классом, с помощью объектов которого
//        можно хранить информацию о моделях телефонов и их свойствах

public class Mobile {
    private String brand;
    private String model;
    private boolean haveProperties = false;

    public Mobile(String brand, String model){
        this.brand = brand;
        this.model = model;
    }

    public void setBrand(String brand){ this.brand = brand;}
    public String getBrand() { return brand; }

    public void setModel(String model){ this.model = model;}
    public String getModel() { return model; }

    public boolean getHaveProperties(){ return this.haveProperties; };

    void addProperties(){
         this.haveProperties = true;
         Mobile.Properties prop = this.new Properties();
    }

    //Inner class
    public class Properties{

        private String releaseDate;
        private int weight;
        private String color;
        private int batteryAmp;

        public Properties(){}

        public Properties(String releaseDate, int weight, String color, int batteryAmp){
            Scanner s = new Scanner(System.in);
            this.releaseDate = releaseDate;
            this.weight = weight;
            this.color = color;
            this.batteryAmp = batteryAmp;
        }

        public String getReleaseDate() { return releaseDate; }
        public void setReleaseDate(String releaseDate) { this.releaseDate = releaseDate; }

        public int getWeight() {return weight;}
        public void setWeight(int weight) { this.weight = weight; }

        public String getColor() { return color; }
        public void setColor(String color) { this.color = color; }

        public int getBatteryAmp() { return batteryAmp; }
        public void setBatteryAmp(int batteryAmp) { this.batteryAmp = batteryAmp;}


        public void showInfo(){
            System.out.println("Brand: " + getBrand());
            System.out.println("Model: " + getModel() + "\n");
            System.out.println("Release Date: " + this.getReleaseDate());
            System.out.println("Weight: " + this.getWeight() + " g");
            System.out.println("Color: " + this.getColor());
            System.out.println("Battery: " + this.getBatteryAmp() + " mA⋅h");
        }
    }



    public void showInfo(){
        System.out.println("Brand: " + getBrand());
        System.out.println("Model: " + getModel());
    }


}
