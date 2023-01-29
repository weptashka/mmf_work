#pragma once

using namespace System;
using namespace System::Windows::Forms;

ref class Vector //Класс "вектор"
{
	array<int>^ vect; //Значения вектора
	bool checked; //Был ли проверен вектор или нет
public:
	Vector(); //Конструктор по умолчанию
	Vector(String^ vecstr); //Констурктор по строке с элементами

	int getSize() { return vect->Length; } //Узнаём длину вектора
	bool isCollinear(Vector^ v2); // Сравниваем два вектора

	String^ format(); //Переобразование в строку

	bool isChecked() { return checked; } //Был ли проверен?
	void Check() { checked = true; } //Установить, что был проверен

	bool isZero(); // Нельзя, чтоб вектор был нулевым - нулевые и так всему коллинеарны
};

Vector::Vector()
{
	vect = gcnew array<int>(0);
	checked = false;
}

Vector::Vector(String^ vecstr) //Констурктор по строке с элементами
{
	array<Char>^ delim = { ' ' }; //Разделитель
	array<String^>^ vechelp = vecstr->Trim()->Split(delim); //Разделяем строку на значения// vchelp - массив символов  
	

	//Функция Trim без параметров обрезает начальные и конечные пробелы и возвращает обрезанную строку

	//С помощью функции Split мы можем разделить строку на массив подстрок. (тут ориентируясь на delim, т е на пробел)
	//В качестве параметра функция Split принимает массив символов или строк, которые и будут служить разделителями.

	vect = gcnew array<int>(vechelp->Length); //Выделяем память под массив
	for (int i = 0; i < vect->Length; i++) 
	{
		vect[i] = Convert::ToInt32(vechelp[i]); //И переводим числа из строчного представления в числовое
	}

	checked = false;
}

bool Vector::isCollinear(Vector^ v2) //Проверка на коллинеарность веткоров
{
	//Если вектора неодинаковой длины, кидаем ошибку
	if (vect->Length != v2->getSize()) throw gcnew ArgumentException("Вектора должны быть одинаковой длины");
	if (isZero() || v2->isZero()) throw gcnew Exception("Вектор не может быть нулевым"); //Если вектор нулевой, кидаем ошибку
	
	int ind = 0; 
	for (int i = 0; i < vect->Length; i++) //Находим индекс первого ненулевого элемента первого вектора
	{
		if (vect[i] != 0)
		{
			ind = i;
			break;
		}
	}
	
	double n = (double) v2->vect[ind] / vect[ind]; //Находим отношение этого элемента с соответствующим элементом второго вектора

	//Вектора a и b - коллинеарны => сущ. n: a*n = b
	for (int i = 0; i < vect->Length; i++) //Проверяем
	{
		//Если при умножении элемента на коэф значение не равно элементу второго вектора, они не коллинеарны
		if (vect[i] * n != v2->vect[i]) return false; 
	}
	return true;
}

bool Vector::isZero() //Нулевой ли вектор?
{
	for (int i = 0; i < vect->Length; i++) //Проходимся по элементам
	{
		if (vect[i] != 0) return false; //Если встречаем ненулевой элемент, выходим и выдаем false
	}
	return true;
}

String^ Vector::format() //Переобразование в строку
{
	String^ res = "";
	for (int i = 0; i < vect->Length; i++)
	{
		res += vect[i].ToString();
		if (i != vect->Length-1) res += " ";
	}
	return res;
}
