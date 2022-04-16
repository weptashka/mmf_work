package com.bsu.java.vychka.lab1;
import com.bsu.java.vychka.lab1.Mobile;

public class Main {

    public static void main(String[] args) {
        Mobile mobile1 = new Mobile("Xiaomi", "RedmiNote8Pro");
        Mobile.Properties prop1 = mobile1.new Properties("June 2019", 200, "Grey", 500);
        prop1.showInfo();
    }

}
