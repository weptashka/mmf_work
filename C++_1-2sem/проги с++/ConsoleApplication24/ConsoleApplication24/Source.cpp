#include <iostream>
#include <cmath>

using namespace std;

int main{
	setlocale(0,"");
	int i;
	double mas[10];
	double t;
	for(i=0;i<10;i++){
		cin>>mas[i]
		}
	cin<<"����� �� ������� [0,1] ���������� �� 10\n";
	for(i = 0; i < 10; i++ ){
		if((a[i] >=0 ) || (a[i] <= 1) ){
			t=a[i]*10;
		cout << a[i]<<"~~*10~~="<<t<<endl;
		} ;
	};

	cin<<"�������������, ������� �� 2\n";
    for(i = 0; i < 10; i++ ){
		if( a[i] < 0 ) {
			t=a[i]/2;
		cout << a[i]<<"~~/2~~"<<t<<endl;
		};
	};

	cin<<"��� ���������, ������� �� 10\n";
	for(i = 0; i < 10; i++ ){
		if( a[i] >1 ) {
			t=a[i]/10;
		cout << a[i]<<"~~/10~~"<<t<<endl;
		};
	};


return 0;
}
