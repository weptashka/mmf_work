#include <iostream>
using namespace std;

/*
	4.	Создать класс CPoint – точка и производные от него классы CcoloredPoint и CLine.
		На основе классов CcoloredPoint и CLine создать класс CcoloredLine.Все классы должны 
		иметь методы для установки и получения значений всех координат, а также изменения
		цвета и получения текущего цвета.
*/

// вртуальное наследование нескольких производных классов одного базового означает, 
// что в производных методы будут не наследоваться, а в них (произв классах) будут созданы ссылки на методы базового 

//пусть будет только 2 координаты


//------------------class CPoint-------------------------//
class CPoint {
private:
	int x1;
	int y1;
public:
	CPoint(int a = 0, int b = 0) { x1 = a, y1 = b; }; // constr
	~CPoint() {}; // destr

	void setx1();
	void sety1();
	int getx1() { return x1; };
	int gety1() { return y1; };

	virtual void show(); // show the qalities of the point
};

void CPoint::setx1() {
	cout << "	x1: ";
	cin >> this->x1;
};

void CPoint::sety1() {
	cout << "	y1: ";
	cin >> this->y1;
};


void CPoint::show() {
	cout << "\n	Your point\n";
	cout << "	(" << getx1() << "; " << gety1() << ")\n";
};


//------------------class CcoloredPoint-------------------------//

class CcoloredPoint: virtual public CPoint {
private:
	string color;
public:
	void setColor();
	void getColor();


	CcoloredPoint(int a = 0, int b = 0, string col = "black"):CPoint(a,b){ //constr
		color = col;
	}
	~CcoloredPoint() {};

	virtual void show() override ; // show the qalities of the point
};

void CcoloredPoint::setColor() {
	cin >> this->color;
}

void CcoloredPoint::getColor() {
	cout << "	color : " << this->color;
};

void CcoloredPoint::show() {
	cout << "\n	Your colored point\n";
	cout << "	(" << getx1() << "; " << gety1() << ")\n";
	getColor();
}


//------------------class CLine------------------------//

class CLine: virtual public CPoint {
private:
	int x2;
	int y2;
public:
	void setx2();
	void sety2();
	int getx2() { return x2; };
	int gety2() { return y2; };

	CLine(int a = 0, int b = 0, int c = 0, int d = 0) :CPoint(a, b) {
		x2 = c; y2 = d;
	};

	virtual void show() override ; // show the qalities of the line

};

void CLine::setx2() {
	cout << "	x2: ";
	cin >> this->x2;
};

void CLine::sety2() {
	cout << "	y2: ";
	cin >> this->y2;
};

void CLine::show() {
	cout << "\n	Your line\n";
	cout << "	(" << getx1() << "; " << gety1() << ")\n";
	cout << "	(" << getx2() << "; " << gety2() << ")\n";
};

//------------------class CcoloredLine-------------------------//

class CcoloredLine: public CcoloredPoint, public CLine {

public:

	CcoloredLine(int a = 0, int b = 0, int c = 0, int d = 0, string co = "black") :CcoloredPoint(a, b, co), CLine(a, b, c, d) {};

	void show() override;

};

void CcoloredLine::show() {
	cout << "\n	Your colored line\n";

	cout << "	(" << getx1() << "; " << gety1() << ")\n";
	cout << "	(" << getx2() << "; " << gety2() << ")\n";
	getColor();
	cout << endl;
}


//------------------void menu-------------------------//

void menu() {
	cout << endl;
	cout << "	Choose the action :\n";
	cout << "	  1 Set Point\n";
	cout << "	  2 Set Colored Point\n";
	cout << "	  3 Set Line\n";
	cout << "	  4 Set Colred Line\n";
	cout << "	  0 Exit\n";
	cout << endl;
	cout << "		>";
}


void menuPoint() {
	cout << endl;
	cout << "	  1 Set New Point\n";
	cout << "	  2 Change X\n";
	cout << "	  3 Change Y\n";
	cout << "	  4 Show my point\n";
	cout << "	  0 Exit\n";
	cout << endl;
	cout << "		>";
}

void menuColoredPoint() {
	cout << endl;
	cout << "	Choose the action :\n";
	cout << "	  1 Set New colored Point\n";
	cout << "	  2 Change X\n";
	cout << "	  3 Change Y\n";
	cout << "	  4 Paint Point\n";
	cout << "	  5 Show my point\n";
	cout << "	  0 Exit\n";
	cout << endl;
	cout << "		>";
}

void menuLine() {
	cout << endl;
	cout << "	Choose the action :\n";
	cout << "	  1 Set New Line\n";
	cout << "	  2 Change X1\n";
	cout << "	  3 Change Y1\n";
	cout << "	  4 Change X2\n";
	cout << "	  5 Change Y2\n";
	cout << "	  6 Show my Line\n";
	cout << "	  0 Exit\n";
	cout << endl;
	cout << "		>";
}

void menuColoredLine() {
	cout << endl;
	cout << "	Choose the action :\n";
	cout << "	  1 Set New colored Line\n";
	cout << "	  2 Change X1\n";
	cout << "	  3 Change Y1\n";
	cout << "	  4 Change X2\n";
	cout << "	  5 Change Y2\n";
	cout << "	  6 Paint Line\n";
	cout << "	  7 Show my coloded Line\n";
	cout << "	  0 Exit\n";
	cout << endl;
	cout << "		>";
}







int main() {

	int n;
	do {
		menu();

		cin >> n;

		switch (n){
		case 0:
			exit(0);
		case 1:
			int n1;
			do {
				menuPoint();
				cin >> n1;
				static CPoint* a = new CPoint[1];
				switch (n1) {
				case 0:
					break;
				case 1:
					cout << "	Enter X coordinate: ";
					a[0].setx1();
					cout << "	Enter Y coordinate: ";
					a[0].sety1();
					break;
				case 2:
					cout << "	Enter X coordinate: ";
					a[0].setx1();
					break;
				case 3:
					cout << "	Enter Y coordinate: ";
					a[0].sety1();
					break;
				case 4:
					a[0].show();
					break;
				} 
			} while (n1 != 0);
			break;
		case 2:
			int n2;
			do {
				menuColoredPoint();
				cin >> n2;
				static CcoloredPoint* ca = new CcoloredPoint[1];
				switch (n2) {
				case 0:
					break;
				case 1:
					cout << "	Enter X coordinate: ";
					ca[0].setx1();
					cout << "	Enter Y coordinate: ";
					ca[0].sety1();
					cout << "	Enter color of your point: ";
					ca[0].setColor();
					break;
				case 2:
					cout << "	Enter X coordinate: ";
					ca[0].setx1();
					break;
				case 3:
					cout << "	Enter Y coordinate: ";
					ca[0].sety1();
					break;
				case 4:
					cout << "	Enter color of your point: ";
					ca[0].setColor();
					break;
				case 5:
					ca[0].show();
					break;
				}
			} while (n2 != 0);
			break;
		case 3:
			int n3;
			do {
				menuLine();
				cin >> n3;
				static CLine* l = new CLine[1];
				switch (n3) {
				case 0:
					break;
				case 1:
					cout << "	Enter X1 coordinate: ";
					l[0].setx1();
					cout << "	Enter Y1 coordinate: ";
					l[0].sety1();
					cout << "	Enter X2 coordinate: ";
					l[0].setx2();
					cout << "	Enter Y2 coordinate: ";
					l[0].sety2();
					break;
				case 2:
					cout << "	Enter X1 coordinate: ";
					l[0].setx1();
					break;
				case 3:
					cout << "	Enter Y1 coordinate: ";
					l[0].sety1();
					break;
				case 4:
					cout << "	Enter X2 coordinate: ";
					l[0].setx2();
					break;
				case 5:
					cout << "	Enter Y2 coordinate: ";
					l[0].sety2();
					break;
				case 6:
					l[0].show();
					break;
				}
			} while (n3 != 0);
			break;
		case 4:
			int n4;
			do {
				menuColoredLine();
				cin >> n4;
				static CcoloredLine* cl = new CcoloredLine[1];
				switch (n4) {
				case 0:
					break;
				case 1:
					cout << "	Enter X1 coordinate: ";
					cl[0].setx1();
					cout << "	Enter Y1 coordinate: ";
					cl[0].sety1();
					cout << "	Enter X2 coordinate: ";
					cl[0].setx2();
					cout << "	Enter Y2 coordinate: ";
					cl[0].sety2();
					cout << "	Enter color of your line: ";
					cl[0].setColor();
					break;
				case 2:
					cout << "	Enter X1 coordinate: ";
					cl[0].setx1();
					break;
				case 3:
					cout << "	Enter Y1 coordinate: ";
					cl[0].sety1();
					break;
				case 4:
					cout << "	Enter X2 coordinate: ";
					cl[0].setx2();
					break;
				case 5:
					cout << "	Enter Y2 coordinate: ";
					cl[0].sety2();
					break;
				case 6:
					cout << "	Enter color of your line: ";
					cl[0].setColor();
					break;
				case 7:
					cl[0].show();
					break;
				}
			} while (n4 != 0);
			break;
		default:
			cout << "	-----\n";
			cout << "	| | |\n";
			cout << "	| | |	The entered symbol does not cause any function\n";
			cout << "	| . |	Enter one of the numbers on the screen.\n";
			cout << "	-----\n";
			break;
		}
	} while (n != 0);

	exit(0);

	return 0;
}