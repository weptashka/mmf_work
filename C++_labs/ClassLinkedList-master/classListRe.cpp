#include <iostream>
using namespace std;

/*
��� ������� ����� ���������� ������� �����, ������� ������������ ���
������������� ��������� ������������ ��������� ������.����� ���������������
����� ��� ������ � ������������ ������������ ���������� ������, ������� ���
������������ ������ ����� ���� �� - ������� ����� ����� ������ :
a) � ����������;
�) �� �����.

�������� ��� �������� ������� :
�) ������������ ��������� ������ ��������� �������� � ������;
�) ������������ ��������� ������ �������� � �����.


5. ��������� ����� ��� ������ � ����������� �������. ������� ������ � �������������� �����.
������������ ������, ���������� ����������� ������������������ �����, � ������������� ��� ���,
����� ������������������ ���� ��������������. ��� ����� ���������� ��������� ��������� ������,
�.�. ����� ������������� ���������� � ������, ��� ������� �������� ��� ������� ���� �� ������
� �������� �������.
*/

class List {
public:

	List();
	~List();


	int getSize() { return Size; }; // list size
	void getList();

	void push_front(float data); // add first element
	void push_back(float data); // add in the end of list

	void pop_front(); //remove first element
	void pop_back(); //remove the last element

	void clear(); //clear all list

	void removeEl(int index); //remove element from any place
	void insert(float data, int index); // add element to any place

	void sort();

	void turn_round();


	//(���������� ��������, ����� ��� ������ � ������ ��-�� ������, ��� � �������)
	float& operator[](const int index); //index - ����������� �������, ������� �� ������ �������



private:

	class Node {
	public:
		float data;// data in element
		Node* pNext;
		// constr Node (Element constr)
		Node(float data = float(), Node* pNext = nullptr) {   // defaut parametr of pointer in nullptr (if we add elemett to the end of list)
			this->data = data;							     // defaut parametr of data is a constr of float (if in data we have some trash)
			this->pNext = pNext;
		}
	};

	int Size; // num of elements in list
	Node* head; // pntr on head of list (to know the length of list always (not count, just know))
				//head - ��� ��-�(����������, �����) ���� Node

};




List::List() {
	Size = 0;
	head = nullptr;
};

List::~List() {
	clear();
};


void List::getList() {
	cout << endl;
	cout << "\n		Your list:\n";
	cout << "	----------------------------------\n";
	for (int i = 0; i < this->getSize(); i++) {
		cout << "	 List[" << i << "] = " << (*this)[i] << endl;
	}
	cout << "\n	 Number of el in list: " << this->getSize() << endl;
	cout << "	----------------------------------\n";
	cout << endl;
}



void List::push_back(float data) {
	if (head == nullptr) { // push in the end of list (if it's first element)
		head = new Node(data);
	}
	else {
		//(���� ������� ����� ��-�(��������� �� ����) � ��������� ����� ����� ������ ��-�� ������ ���������� ������ � ����������� ������)
		Node* current = this->head; // (�������� ��-��, � ������� �� ��������(������ �������) ����������� �������� ����)(����������� ��������� ����������, �� ����������� �������� ���������)
		while (current->pNext != nullptr) {
			current = current->pNext;      // (���������� ��� ��-��, ���� �� ����� �� ����, � �������� pNext==null)
		};                                 // � ����� � ��-�� pNext == null, �� ��� ��-�� ������ �����������, � ������� ��������� data) 
		current->pNext = new Node(data);
	}
	Size++;
};


float& List::operator[](const int index) { // index - ����� ��-��

	int counter = 0;
	Node* current = this->head; //���������, � ������� �� ���������, ����������� �������� head
	while (current != nullptr) { // ���������� ��� ��-��, (�� ������ �� ����������)
		if (counter == index) {   // ����� ����� ������������� ��-�� == index, ���������� �������� (data �� ��-��) 
			return current->data;
		}
		current = current->pNext;
		counter++;
	}
};

void List::pop_front() {
	Node* temp = head;
	head = head->pNext;

	delete temp;
	Size--;
}

void List::pop_back() {
	removeEl(Size - 1);
}

void List::clear() {

	while (Size) {
		pop_front();
	}

}

void List::push_front(float data) {
	head = new Node(data, head); //������� �������� ������ � ���������� �� 1� ������, � ����� ��� ���� ��������� ������ ���������� �����
	Size++;
}

void List::insert(float data, int index) {

	if (index == 0) { push_front(data); }
	else {

		Node* previous = this->head; // ���������� previous ���������� head, � ����� ���� ������������� previous

		for (int i = 0; i < index - 1; i++) {
			previous = previous->pNext;
		}

		Node* temp = new Node(data, previous->pNext);

		previous->pNext = temp;
		Size++;
	}
}



void List::removeEl(int index) {
	if (index == 0) { pop_front(); }
	else {
		Node* previous = this->head;
		for (int i = 0; i < index - 1; i++) {
			previous = previous->pNext;
		}
		Node* toDelete = previous->pNext;
		previous->pNext = toDelete->pNext;
		delete toDelete;

		Size--;
	}
}


void List::turn_round() {
	Node* this_head = this->head;
	Node* current = this->head;
	int t = this->getSize();
	for (int i = 1; i <= t - 1; i++) {

		current = current->pNext;

		this->push_front(current->data);
	}

	int s = this->getSize() / 2;

	while (s) {
		pop_back();
		s--;
	}


	this->getList();
}

void List::sort() {
	if (head == nullptr || head->pNext == nullptr) { return; }


	int k = 1;


	while (k) {

		Node* current = this->head;
		Node* prev = nullptr;
		Node* next = this->head->pNext;

		Node* tmp;

		int count = 0;
		Node* c1 = current;

		for (int i = 0; i < this->getSize()-1; i++) {
			if (c1->data < c1->pNext->data) { count++; }
			c1 = c1->pNext;
		}

		if (count == this->getSize()-1) { //���� ������ ��� ������������, �� ��� ��� �� � �� ���� ������ �����������)
			
			k = 0;
		}
		else {
			

			int d = this->getSize() - 1;
			while (d--) {
				k = 0;

				if ((current->data > current->pNext->data) && (current->pNext != nullptr)) {
					k++;
					if (prev == nullptr) {
						tmp = next; //������ ������� ������ 2 ��-��
						current->pNext = next->pNext;
						tmp->pNext = current;
						next = current->pNext;
						head = tmp;
						prev = tmp;
					}
					else {
						tmp = next;
						current->pNext = next->pNext;
						tmp->pNext = current;
						prev->pNext = tmp;
						next = current->pNext;
						prev = tmp;
					}
				}
				else if (current->pNext != nullptr) {
					prev = current;
					current = current->pNext;
					next = current->pNext;
					k++;

				}
				else {
					k--;
				}
			}
		}
	}
	this->getList();
}






void menu() {
	cout << endl;
	cout << "	Choose the action :\n";
	cout << "	  1 Make a list\n";
	cout << "	  2 Add element to begin\n";
	cout << "	  3 Add element to the end of list\n";
	cout << "	  4 Remove the first element\n";
	cout << "	  5 Remove the last element\n";
	cout << "	  6 Make this list 'without dicreasing'\n";
	cout << "	  7 Turn the list 'without dicreasing' to make it 'without increasing'\n";
	cout << "	  0 Exit\n";
	cout << endl;
	cout << "		>";
}


List* lst; // global list variable


int main() {

	int n;
	do {
		menu();

		cin >> n;

		switch (n) {
		case 0:
			exit(0);
			break;
		case 1:
			cout << "\n	  Enter number of elements in list: ";
			int num;
			cin >> num;
			List* lst1;
			lst1 = new List();
			for (int i = 0; i < num; i++) {
				cout << "	  [" << i << "] = ";
				float y;
				cin >> y;
				lst1->insert(y, i);
			}
			lst = lst1;
			lst->getList();
			break;

		case 2:
			float data1;
			cout << "\n		Enter the data you want to push to begin: ";
			cin >> data1;
			lst->push_front(data1);
			lst->getList();
			break;

		case 3:
			float data2;
			cout << "\n		Enter the data you want to push to the end: ";
			cin >> data2;
			lst->push_back(data2);
			lst->getList();
			break;

		case 4:
			cout << "\n		Removing the first element...\n";
			lst->pop_front();
			lst->getList();
			break;

		case 5:
			cout << "\n		Removing the last element...\n";
			lst->pop_back();
			lst->getList();
			break;

		case 6:
			cout << "\n		Hello! I'm sorting function\n";
			lst->sort();
			break;


		case 7:
			cout << "\n		Hello! I'm reversing function\n";
			lst->turn_round();
			break;

		default:
			cout << "	-----\n";
			cout << "	| | |\n";
			cout << "	| | |	The entered symbol does not cause any function\n";
			cout << "	| . |	Enter one of the numbers on the screen.\n";
			cout << "	-----\n";
			break;
		}

	} while (!(n == 0));

	exit(0);

	return 0;
}