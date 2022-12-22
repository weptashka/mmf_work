package com.bsu.java.vychka.lab2;

//Разработать проект управления процессами на основе создания и
//        реализации интерфейсов для следующих предметных областей:

//10. Дом. Возможности: построить дом; рассчитать цену за квадратный метр;
//        узнать сколько комнат; увеличить площадь; сдавать дом в аренду; сделать
//        ремонт (в какой-либо комнате). Добавить специализированные методы для
//        Дома, Офисного здания, Торгового центра.

public interface IHouse {
    void buildHouse(int roomNum, double area);
    void calcPricePerSqMeter(double wholePrice);
    void increaseArea(double plusArea);
    void makeRepair();
    void showInfo();
}
