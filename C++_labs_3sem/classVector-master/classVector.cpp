#include <iostream>

using namespace std;

/*Разработать перечисленные ниже классы. При разработке каждого класса возможны
два варианта решения :
	а) данные - члены класса представляют собой переменные и массивы фиксированной размерности;
	б) память для данных - членов класса выделяется динамически.*/

	/*3. Разработать класс «Вектор» – Vector размерности.Определить несколько конструкторов, в том числе
конструктор копирования.Реализовать методы для вычисления модуля вектора, скалярного произведения,
сложения, вычитания, умножения на константу.Перегрузить операции сложения, вычитания,
умножения, инкремента, декремента, индексирования, присваивания для данного класса.
Создать массив объектов.Написать функцию, которая для заданной пары векторов будет определять,
являются ли они коллинеарными или ортогональными.*/



class Vector {

private:

	int n; //vector dim
	int* pArr; //pointer on array

public:
	//def constr
	Vector();

	//constr with par
	Vector(int size);

	//copy constr
	Vector(const Vector& other);

	//destr
	~Vector();

	//setVector
	void setVector();

	//show Vector
	void showVector();

	//calc vector module
	float calcModule();

	friend float Scalar(Vector*, Vector*);  //Scalar multiplication

	friend Vector Sum(Vector*, Vector*); //Sum
	friend Vector Substr(Vector*, Vector*);	//Substraction

	friend Vector Mult(Vector*); //Multiplication by constant

	friend bool Collinear(Vector*, Vector*);  //Check for сollinearity 
	friend bool Orthogonal(Vector*, Vector*);  //Check for orthogonality 


	//funcktion overload
	Vector& operator++();
	Vector& operator--();

	Vector& operator+(int);
	Vector& operator-(int);

	Vector& operator*(int);

	Vector& operator=(const Vector&);

};


	Vector& Vector::operator++() {
		Vector temp;
		for (int i = 0; i < n; i++)
			*(temp.pArr + i) = *(pArr + i) + 1;
		return temp;
	}

	Vector& Vector::operator--() {
		Vector temp;
		for (int i = 0; i < n; i++)
			*(temp.pArr + i) = *(pArr + i) - 1;
		return temp;
	}


	Vector& Vector::operator+(int plusNum) {
		Vector temp;
		for (int i = 0; i < n; i++)
			*(temp.pArr + i) = *(pArr + i) + plusNum;
		return temp;
	}


	Vector& Vector::operator-(int minusNum) {
		Vector temp;
		for (int i = 0; i < n; i++)
			*(temp.pArr + i) = *(pArr + i) - minusNum;
		return temp;
	}



	Vector& Vector::operator*(int multNum) {
		Vector temp;
		for (int i = 0; i < n; i++)
			*(temp.pArr + i) = (*(pArr + i))*(multNum);
		return temp;
	}


	Vector& Vector::operator=(const Vector& newVector) {
		if (this == &newVector)// checking for self-assigment
			return *this;
		else {
			*this = newVector;
			return *this;
		}
	}
	



	Vector::Vector() {
		cout << "	деф конструктор " << this << endl;
		n = 2;
		pArr = new int[n];
	}


	Vector::Vector(int size) {
		cout << "	конструктор с параметром " << this << endl;
		this->n = size;
		this->pArr = new int[n];
	}


	Vector::Vector(const Vector& other) {
		cout << "	констр копир" << this << endl;

		this->n = other.n;
		this->pArr = new int[other.n];
		for (int i = 0; i < other.n; i++) {
			this->pArr[i] = other.pArr[i];
		}
	}

	Vector::~Vector() {
		cout << "	деструктор " << this << endl;
		delete[] pArr;
	}


	void Vector::setVector() {
		cout << endl;
		cout << "	Enter vector dimention: ";
		cout << ">";
		cin >> n;
		for (int i = 0; i < n; i++) {
			cout << "	Coord № " << i + 1 << " = ";
			cin >> *(pArr + i);
		}
	}

	void Vector::showVector() {
		cout << "	";
		cout << "(";
		for (int i = 0; i < n; i++) {
			cout << *(pArr + i);
			if (i < n - 1) { cout << ", "; }
		}
		cout << ")";
	}


	float Vector::calcModule() {
		float m = 0;
		for (int i = 0; i < n; i++) {
			m += *(pArr + i) * *(pArr + i);
		}
		;
		return sqrt(m);
	}

	float Scalar(Vector* vector1, Vector* vector2)
	{
		static float temp;
		temp = 0;
		for (int i = 0; i < (*vector1).n; i++)
			temp += *(vector1->pArr + i) * *(vector2->pArr + i);
		return temp;
	}


	Vector Sum(Vector* vector1, Vector* vector2)
	{
		Vector temp;
		for (int i = 0; i < vector1->n; i++)
			*(temp.pArr + i) = *(vector1->pArr + i) + *(vector2->pArr + i);
		return temp;
	}

	Vector Substr(Vector* vector1, Vector* vector2)
	{
		Vector temp;
		for (int i = 0; i < vector1->n; i++)
			*(temp.pArr + i) = *(vector1->pArr + i) - *(vector2->pArr + i);
		return Vector(temp);
	}

	Vector Mult(Vector* vector1) 
	{
		Vector temp;
		int con;
		cout << "	Enter the constant: ";
		cin >> con;
		for (int i = 0; i < vector1->n; i++)
			*(temp.pArr + i) = (*(vector1->pArr + i)) * con;
		return Vector(temp);
	}

	bool Orthogonal(Vector* vector1, Vector* vector2)
	{
		if ((Scalar(vector1, vector2)) < 0.01)
			return true;
		else
			return false;
	}

	bool Collinear(Vector* vector1, Vector* vector2)
	{
		if ((Scalar(vector1, vector2) - ((*vector1).calcModule() * (*vector2).calcModule())) < 0.01)
			return true;
		else
			return false;
	}







void menu() {
	cout << endl;
	cout << "\n Choose an action:\n\n";
	cout << "	1 -Calculate the vector module \n";
	cout << "	2 -Calculate a scalar multiplication\n";
	cout << "	3 -Calculate the sum of vectors\n";
	cout << "	4 -Calculate the difference of vectors\n";
	cout << "	5 -Multiply vector on constant\n";
	cout << "	6 -Check 2 vectors for collinearity and orthogonality\n";
	cout << "	7 -Create an array of vectors\n";
	cout << "	0 -Exit\n";
	cout << endl;
};




int main() {

	setlocale(0, "");

	char n1;
	do {
		menu();

		cout << "	>";
		cin >> n1;
		cout << endl;
		switch (n1) {
		case'0':
			exit(0);
			break;


		case'1':
			Vector * v1;
			v1 = new Vector[1];
			for (int i = 0; i < 1; i++) {
				v1[i].setVector();
				v1[i].showVector();
				cout << "\n	vector module = " << v1[i].calcModule() << endl;
			}
			break;

		case'2':
			Vector * list2;
			list2 = new Vector[2];
			for (int i = 0; i < 2; i++) {
				list2[i].setVector();
			}
			cout << "\n		Result of scalar multiplication: " << Scalar(&list2[0], &list2[1]);
			
			break;

		case'3':
			Vector* list3;
			list3 = new Vector[2];
			for (int i = 0; i < 2; i++) {
				list3[i].setVector();
			}
			Sum(&list3[0], &list3[1]).showVector();
			break;


		case'4':
			Vector * list4;
			list4 = new Vector[2];
			for (int i = 0; i < 2; i++) {
				list4[i].setVector();
			}
			Substr(&list4[0], &list4[1]).showVector();
			break;

		case'5':
			Vector * list5;
			list5 = new Vector[1];
			list5[0].setVector();
			Mult(&list5[0]).showVector();
			break;

		case'6':
			Vector * list6;
			list6 = new Vector[2];
			for (int i = 0; i < 2; i++) {
				list6[i].setVector();
			}

			if (Collinear(&list6[0], &list6[1]))
				cout << "\n	These vectors are collinear";
			else cout << "\n	These vectors arn't collinear";

			if (Orthogonal(&list6[0], &list6[1]))
				cout << "\n	These vectors are orthogonal";
			else cout << "\n	These vectors arn't orthogonal";
			break;


		case'7':
			Vector * listArr;
			int n;
			cout << "	Enter the number of vectors:";
			cout << "	>";
			cin >> n;
			listArr = new Vector[n];
			for (int i = 0; i < n; i++) {
				listArr[i].setVector();
			}
			cout << endl;
			cout << "	Your array of vectors:\n ";
			for (int i = 0; i < n; i++) {
				listArr[i].showVector();
				cout << endl;
			}
			break;

		default:
			cout << "	-----\n";
			cout << "	| | |\n";
			cout << "	| | |	The entered symbol does not cause any function\n";
			cout << "	| . |	Enter one of the numbers on the screen.\n";
			cout << "	-----\n";
			break;
		}
	} while (!(n1 == '0'));
	return 0;
}
