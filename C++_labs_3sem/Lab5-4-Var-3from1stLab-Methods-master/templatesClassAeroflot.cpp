#include <iostream>
#include <Windows.h>
#include <cmath>



using namespace std;

/*
* Разработать классы для описанных ниже объектов.
Включить в класс методы set (…), get (…), show (…). Определить другие методы.
*
*  3. Aeroflot: Пункт назначения, Номер рейса,
 * Тип самолета, Время вылета, Дни недели.Создать массив объектов.
 * Вывести :
	а) список рейсов для заданного пункта назначения;
	б) список рейсов для заданного дня недели;
	в) список рейсов для заданного дня недели, время вылета для которых больше заданного.
*/




//=======     class integer   =================
class integer
{
	int x;
public:
	integer() : x(0) {}
	explicit integer(int val) : x(val) {}
	integer(const integer& obj) : x(obj.x) {}
	integer& operator = (const integer& obj)
	{
		if (this == &obj) return *this;
		x = obj.x;
		return *this;
	}

	integer& operator = (const int num)
	{
		if (this->x == num) return *this;
		x = num;
		return *this;
	}

	integer operator + (const integer& obj)
	{

		integer newObj(this->x + obj.x);
		return newObj;
	}

	integer operator + (const int num)
	{

		integer newObj(this->x + num);
		return newObj;
	}

	integer operator - ()
	{
		return integer(-x);
	}

	integer operator - (const integer& obj)
	{
		integer newObj(this->x - obj.x);
		return newObj;
	}
	integer operator / (const integer& obj)
	{
		integer newObj(this->x / obj.x);
		return newObj;
	}
	integer operator * (const integer& obj)
	{
		integer newObj(this->x * obj.x);
		return newObj;
	}

	bool operator >= (const int num)
	{
		if (this->x >= num) {
			return true;
		}
		else { return false; }
	}

	void set(int val) { x = val; }
	int get() { return x; }
	friend istream& operator >> (istream& is, integer& obj) { return is >> obj.x; }
	friend ostream& operator << (ostream& os, const integer& obj) { return os << obj.x; }
};



//=======     funk menu   =================
void menu() {
	cout << "\n Выберите действие:\n\n";
	cout << "	1 -Создать таблицу рейсов\n";
	cout << "	2 -Вывести всю информацию\n";
	cout << "	3 -Вывести список рейсов для заданного пункта назначения\n";
	cout << "	4 -Вывести список рейсов для заданного дня недели\n";
	cout << "	5 -Вывести список рейсов для заданного дня недели, время вылета которых больше заданного\n";
	cout << "	0 -Выход из программы\n";
};



//=======     class Aeroflot   =================
// разными будут номер рейса - только цифрочками integer / цифрочки и буквочки - string
// время вылета - float / string

template<typename T1, typename T2> // T1, T2 - пока что неизвестные типы данных
class Aeroflot {                   // T1 - flyNumber
	                               // T2 - time
private:
	string punkt; //пункт назначения
	T1 flyNumber; //номер рейса
	string type; //тип самолёта
	T2 time; //время вылета
	string weekDay; // день недели

public:

	//det
	void setPunkt(string punkt) { this->punkt = punkt; };
	void setFlyNumber(T1 flyNumber) { this->flyNumber = flyNumber; };
	void setType(string type) { this->type = type; };
	void setTime(T2 time) { this->time = time; };
	void setWeekDay(string weekDay) { this->weekDay = weekDay; };

	//get
	string getPunkt() { return punkt; };
	T1 getFlyNumber() { return flyNumber; };
	string getType() { return type; };
	T2 getTime() { return time; };
	string getWeekDay() { return weekDay; };

	//show
	void show();


	//конструкторы
	Aeroflot();
	Aeroflot(string punkt, T1 flyNumber, string type, T2 time, string weekDay);
};


//show
template<typename T1, typename T2>
void Aeroflot<T1, T2>::show() {
	cout << "	" << this->getPunkt() << "	" << this->getFlyNumber() << "	" << this->getType() << "	" << this->getTime() << "	" << this->getWeekDay() << "	" << endl;
}


//конструкторы
template<typename T1, typename T2>
Aeroflot<T1, T2>::Aeroflot() {};

template<typename T1, typename T2>
Aeroflot<T1, T2>::Aeroflot(string punkt, T1 flyNumber, string type, T2 time, string weekDay) {
	this->punkt = punkt;
	this->flyNumber = flyNumber;
	this->type = type;
	this->time = time;
	this->weekDay = weekDay;
};






int main() {

	setlocale(0, "");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);


	int n1 = 1; 

	string day;
	string name;
	float t;
	string ts;

	do {
			menu();
			cout << "\n	>";
			cin >> n1;
			cout << endl;

			
			switch (n1) {

			case 0:
				exit(0);
				break;
			case 1:

				static Aeroflot<integer, float>* list; // static - чтоб все case видели
				static Aeroflot<string, string>* list2; // static - чтоб все case видели

				cout << "\n Выберите в каком формате вы хотите вводить номер рейса и время вылета:\n\n";
				cout << "	1 - Номер рейса - только цифры, Время вылета - часы и минуты через точку (12.30)\n";
				cout << "	2 - Номер рейса - содержит буквы и цифры, Время вылета - через двоеточие\n";

				static int n2;
				cout << "\n	>";
				cin >> n2;
				static int num;

				switch (n2) {
				case 0:
					break;
				case 1:
					cout << "	Введите число рейсов:	";
					cin >> num;
					list = new Aeroflot<integer, float>[num];

					for (int i = 0; i < num; i++) {
						cout << "\n		Рейс № " << i + 1 << endl;
						cout << "	Введите пункт назначения: ";
						string punkt;
						cin >> punkt;
						cout << "	Введите номер рейса: ";
						integer flyNumber;
						cin >> flyNumber;
						cout << "	Введите тип самолёта: ";
						string type;
						cin >> type;
						cout << "	Введите время вылета: ";
						float time;
						cin >> time;
						cout << "	Введите день недели: ";
						string weekDay;
						cin >> weekDay;
						cout << endl;

						list[i] = Aeroflot<integer, float>(punkt, flyNumber, type, time, weekDay);
					}
					break;
				case 2:
					cout << "	Введите число рейсов:	";
					cin >> num;
					list2 = new Aeroflot<string, string>[num];

					for (int i = 0; i < num; i++) {
						cout << "\n		Рейс № " << i + 1 << endl;
						cout << "	Введите пункт назначения: ";
						string punkt;
						cin >> punkt;
						cout << "	Введите номер рейса: ";
						string flyNumber;
						cin >> flyNumber;
						cout << "	Введите тип самолёта: ";
						string type;
						cin >> type;
						cout << "	Введите время вылета: ";
						string time;
						cin >> time;
						cout << "	Введите день недели: ";
						string weekDay;
						cin >> weekDay;
						cout << endl;

						list2[i] = Aeroflot<string, string>(punkt, flyNumber, type, time, weekDay);
					}
					break;
				}
				
			case 2:
				cout << "_____________________________________________________\n";
				cout << "	Вся информация:\n";
				cout << "	Пункт	Рейс	Самолёт	  Время	   День\n\n";
				for (int i = 0; i < num; i++) {
					n2 == 1 ? list[i].show() : list2[i].show();
				}
				cout << "_____________________________________________________\n";
				break;
			case 3:
				cout << "\n		Введите пункт назначения: ";
				cin >> name;
				cout << "_____________________________________________________\n\n";
				cout << "	Рейсы с пунктом назначения:	" << name << "\n\n";
				for (int i = 0; i < num; i++) {

					if (n2 == 1) {
						if (name == list[i].getPunkt()) {
							list[i].show();
						}
					}
					else if(n2 == 2) {
						if (name == list2[i].getPunkt()) {
							list2[i].show();
						}
					}
				}
				cout << "_____________________________________________________\n";
				break;
			case 4:
				cout << "\n	Введите день недели: ";
				cin >> day;
				cout << "_____________________________________________________\n\n";
				cout << "	Рейсы с пунктом назначения:	" << day << "\n\n";

				for (int i = 0; i < num; i++) {
					if (n2 == 1) {
						if (day == list[i].getWeekDay()) {
							list[i].show();
						}
					}
					else {
						if (day == list2[i].getWeekDay()) {
							list2[i].show();
						}
					}
				}
				cout << "_____________________________________________________\n";
				break;
			case 5:
				if (n2 == 1) {
					cout << "\n	Введите день недели и время:\n";
					cout << "	День:	";
					cin >> day;
					cout << "	Время:	";
					cin >> t;

					cout << "_____________________________________________________\n\n";
					cout << "	Рейсы в день недели: " << day << " и время после " << t << "\n\n";
					for (int i = 0; i < num; i++) {

						if ((day == list[i].getWeekDay()) && (t < list[i].getTime())) {
							list[i].show();
						}
					}
				}
				else {
					cout << "\n	Введите день недели и время:\n";
					cout << "	День:	";
					cin >> day;
					cout << "	Время:	";
					cin >> ts;

					cout << "_____________________________________________________\n\n";
					cout << "	Рейсы в день недели: " << day << " и время после " << ts << "\n\n";
					for (int i = 0; i < num; i++) {
						if ((day == list2[i].getWeekDay()) && (ts < list2[i].getTime())) {
							list2[i].show();
						}
					}
				}
				
				cout << "_____________________________________________________\n";

				break;
			default:
				cout << "	-----\n";
				cout << "	| | |\n";
				cout << "	| | |	Введённый символ не вызывает ни одну функцию\n";
				cout << "	| . |	Введите одну из цифр на экране\n";
				cout << "	-----\n";
			}
	} while (n1 != 0);


	return 0;
}




