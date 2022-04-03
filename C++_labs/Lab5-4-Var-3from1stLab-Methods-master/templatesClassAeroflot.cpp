#include <iostream>
#include <Windows.h>
#include <cmath>



using namespace std;

/*
* ����������� ������ ��� ��������� ���� ��������.
�������� � ����� ������ set (�), get (�), show (�). ���������� ������ ������.
*
*  3. Aeroflot: ����� ����������, ����� �����,
 * ��� ��������, ����� ������, ��� ������.������� ������ ��������.
 * ������� :
	�) ������ ������ ��� ��������� ������ ����������;
	�) ������ ������ ��� ��������� ��� ������;
	�) ������ ������ ��� ��������� ��� ������, ����� ������ ��� ������� ������ ���������.
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
	cout << "\n �������� ��������:\n\n";
	cout << "	1 -������� ������� ������\n";
	cout << "	2 -������� ��� ����������\n";
	cout << "	3 -������� ������ ������ ��� ��������� ������ ����������\n";
	cout << "	4 -������� ������ ������ ��� ��������� ��� ������\n";
	cout << "	5 -������� ������ ������ ��� ��������� ��� ������, ����� ������ ������� ������ ���������\n";
	cout << "	0 -����� �� ���������\n";
};



//=======     class Aeroflot   =================
// ������� ����� ����� ����� - ������ ���������� integer / �������� � �������� - string
// ����� ������ - float / string

template<typename T1, typename T2> // T1, T2 - ���� ��� ����������� ���� ������
class Aeroflot {                   // T1 - flyNumber
	                               // T2 - time
private:
	string punkt; //����� ����������
	T1 flyNumber; //����� �����
	string type; //��� �������
	T2 time; //����� ������
	string weekDay; // ���� ������

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


	//������������
	Aeroflot();
	Aeroflot(string punkt, T1 flyNumber, string type, T2 time, string weekDay);
};


//show
template<typename T1, typename T2>
void Aeroflot<T1, T2>::show() {
	cout << "	" << this->getPunkt() << "	" << this->getFlyNumber() << "	" << this->getType() << "	" << this->getTime() << "	" << this->getWeekDay() << "	" << endl;
}


//������������
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

				static Aeroflot<integer, float>* list; // static - ���� ��� case ������
				static Aeroflot<string, string>* list2; // static - ���� ��� case ������

				cout << "\n �������� � ����� ������� �� ������ ������� ����� ����� � ����� ������:\n\n";
				cout << "	1 - ����� ����� - ������ �����, ����� ������ - ���� � ������ ����� ����� (12.30)\n";
				cout << "	2 - ����� ����� - �������� ����� � �����, ����� ������ - ����� ���������\n";

				static int n2;
				cout << "\n	>";
				cin >> n2;
				static int num;

				switch (n2) {
				case 0:
					break;
				case 1:
					cout << "	������� ����� ������:	";
					cin >> num;
					list = new Aeroflot<integer, float>[num];

					for (int i = 0; i < num; i++) {
						cout << "\n		���� � " << i + 1 << endl;
						cout << "	������� ����� ����������: ";
						string punkt;
						cin >> punkt;
						cout << "	������� ����� �����: ";
						integer flyNumber;
						cin >> flyNumber;
						cout << "	������� ��� �������: ";
						string type;
						cin >> type;
						cout << "	������� ����� ������: ";
						float time;
						cin >> time;
						cout << "	������� ���� ������: ";
						string weekDay;
						cin >> weekDay;
						cout << endl;

						list[i] = Aeroflot<integer, float>(punkt, flyNumber, type, time, weekDay);
					}
					break;
				case 2:
					cout << "	������� ����� ������:	";
					cin >> num;
					list2 = new Aeroflot<string, string>[num];

					for (int i = 0; i < num; i++) {
						cout << "\n		���� � " << i + 1 << endl;
						cout << "	������� ����� ����������: ";
						string punkt;
						cin >> punkt;
						cout << "	������� ����� �����: ";
						string flyNumber;
						cin >> flyNumber;
						cout << "	������� ��� �������: ";
						string type;
						cin >> type;
						cout << "	������� ����� ������: ";
						string time;
						cin >> time;
						cout << "	������� ���� ������: ";
						string weekDay;
						cin >> weekDay;
						cout << endl;

						list2[i] = Aeroflot<string, string>(punkt, flyNumber, type, time, weekDay);
					}
					break;
				}
				
			case 2:
				cout << "_____________________________________________________\n";
				cout << "	��� ����������:\n";
				cout << "	�����	����	������	  �����	   ����\n\n";
				for (int i = 0; i < num; i++) {
					n2 == 1 ? list[i].show() : list2[i].show();
				}
				cout << "_____________________________________________________\n";
				break;
			case 3:
				cout << "\n		������� ����� ����������: ";
				cin >> name;
				cout << "_____________________________________________________\n\n";
				cout << "	����� � ������� ����������:	" << name << "\n\n";
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
				cout << "\n	������� ���� ������: ";
				cin >> day;
				cout << "_____________________________________________________\n\n";
				cout << "	����� � ������� ����������:	" << day << "\n\n";

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
					cout << "\n	������� ���� ������ � �����:\n";
					cout << "	����:	";
					cin >> day;
					cout << "	�����:	";
					cin >> t;

					cout << "_____________________________________________________\n\n";
					cout << "	����� � ���� ������: " << day << " � ����� ����� " << t << "\n\n";
					for (int i = 0; i < num; i++) {

						if ((day == list[i].getWeekDay()) && (t < list[i].getTime())) {
							list[i].show();
						}
					}
				}
				else {
					cout << "\n	������� ���� ������ � �����:\n";
					cout << "	����:	";
					cin >> day;
					cout << "	�����:	";
					cin >> ts;

					cout << "_____________________________________________________\n\n";
					cout << "	����� � ���� ������: " << day << " � ����� ����� " << ts << "\n\n";
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
				cout << "	| | |	�������� ������ �� �������� �� ���� �������\n";
				cout << "	| . |	������� ���� �� ���� �� ������\n";
				cout << "	-----\n";
			}
	} while (n1 != 0);


	return 0;
}




