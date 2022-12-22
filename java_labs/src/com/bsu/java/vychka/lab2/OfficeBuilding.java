package com.bsu.java.vychka.lab2;

public class OfficeBuilding extends House implements IOfficeBuilding {

    private boolean isRent;

    @Override
    public void rentBuilding() {
        this.isRent = true;
    }


}
