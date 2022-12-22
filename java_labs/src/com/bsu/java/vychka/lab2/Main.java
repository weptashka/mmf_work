package com.bsu.java.vychka.lab2;

//Разработать проект управления процессами на основе создания и реализации интерфейсов
//для следующих предметных областей:
//        Дом. Возможности: построить дом; рассчитать цену за квадратный метр;
//        узнать сколько комнат; увеличить площадь; сдавать дом в аренду; сделать
//        ремонт (в какой-либо комнате). Добавить специализированные методы для
//        Дома, Офисного здания, Торгового центра.

public class Main {
    public static void main(String[] args) {

        House h1 = new House();
        h1.buildHouse(4, 344);
        h1.increaseArea(345);
        h1.makeRepair();
        h1.calcPricePerSqMeter(432);

        h1.showInfo();


        OfficeBuilding off1 = new OfficeBuilding();
        off1.buildHouse(4, 344);
        off1.increaseArea(345);
        off1.makeRepair();
        off1.calcPricePerSqMeter(432);
        off1.rentBuilding();

        off1.showInfo();
    }
}
