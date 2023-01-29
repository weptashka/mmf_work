#pragma once

using namespace System;
using namespace System::Windows::Forms;

ref class Vector //����� "������"
{
	array<int>^ vect; //�������� �������
	bool checked; //��� �� �������� ������ ��� ���
public:
	Vector(); //����������� �� ���������
	Vector(String^ vecstr); //����������� �� ������ � ����������

	int getSize() { return vect->Length; } //����� ����� �������
	bool isCollinear(Vector^ v2); // ���������� ��� �������

	String^ format(); //��������������� � ������

	bool isChecked() { return checked; } //��� �� ��������?
	void Check() { checked = true; } //����������, ��� ��� ��������

	bool isZero(); // ������, ���� ������ ��� ������� - ������� � ��� ����� �����������
};

Vector::Vector()
{
	vect = gcnew array<int>(0);
	checked = false;
}

Vector::Vector(String^ vecstr) //����������� �� ������ � ����������
{
	array<Char>^ delim = { ' ' }; //�����������
	array<String^>^ vechelp = vecstr->Trim()->Split(delim); //��������� ������ �� ��������// vchelp - ������ ��������  
	

	//������� Trim ��� ���������� �������� ��������� � �������� ������� � ���������� ���������� ������

	//� ������� ������� Split �� ����� ��������� ������ �� ������ ��������. (��� ������������ �� delim, � � �� ������)
	//� �������� ��������� ������� Split ��������� ������ �������� ��� �����, ������� � ����� ������� �������������.

	vect = gcnew array<int>(vechelp->Length); //�������� ������ ��� ������
	for (int i = 0; i < vect->Length; i++) 
	{
		vect[i] = Convert::ToInt32(vechelp[i]); //� ��������� ����� �� ��������� ������������� � ��������
	}

	checked = false;
}

bool Vector::isCollinear(Vector^ v2) //�������� �� �������������� ��������
{
	//���� ������� ������������ �����, ������ ������
	if (vect->Length != v2->getSize()) throw gcnew ArgumentException("������� ������ ���� ���������� �����");
	if (isZero() || v2->isZero()) throw gcnew Exception("������ �� ����� ���� �������"); //���� ������ �������, ������ ������
	
	int ind = 0; 
	for (int i = 0; i < vect->Length; i++) //������� ������ ������� ���������� �������� ������� �������
	{
		if (vect[i] != 0)
		{
			ind = i;
			break;
		}
	}
	
	double n = (double) v2->vect[ind] / vect[ind]; //������� ��������� ����� �������� � ��������������� ��������� ������� �������

	//������� a � b - ����������� => ���. n: a*n = b
	for (int i = 0; i < vect->Length; i++) //���������
	{
		//���� ��� ��������� �������� �� ���� �������� �� ����� �������� ������� �������, ��� �� �����������
		if (vect[i] * n != v2->vect[i]) return false; 
	}
	return true;
}

bool Vector::isZero() //������� �� ������?
{
	for (int i = 0; i < vect->Length; i++) //���������� �� ���������
	{
		if (vect[i] != 0) return false; //���� ��������� ��������� �������, ������� � ������ false
	}
	return true;
}

String^ Vector::format() //��������������� � ������
{
	String^ res = "";
	for (int i = 0; i < vect->Length; i++)
	{
		res += vect[i].ToString();
		if (i != vect->Length-1) res += " ";
	}
	return res;
}
