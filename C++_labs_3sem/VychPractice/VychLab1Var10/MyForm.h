#pragma once

//10.	Сложить и умножить два полинома заданных степеней
//(коэффициенты полиномов представляют собой одномерные массивы).

namespace VychLab1Var10 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^ label1;
	protected:
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Button^ button1;
	private: System::Windows::Forms::TextBox^ textBox1;
	private: System::Windows::Forms::TextBox^ textBox2;
	private: System::Windows::Forms::TextBox^ textBox3;
	private: System::Windows::Forms::TextBox^ textBox4;
	private: System::Windows::Forms::Button^ button2;
	private: System::Windows::Forms::Button^ button3;
	private: System::Windows::Forms::Label^ label5;
	private: System::Windows::Forms::TextBox^ textBox5;



	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container^ components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->textBox2 = (gcnew System::Windows::Forms::TextBox());
			this->textBox3 = (gcnew System::Windows::Forms::TextBox());
			this->textBox4 = (gcnew System::Windows::Forms::TextBox());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->textBox5 = (gcnew System::Windows::Forms::TextBox());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9));
			this->label1->Location = System::Drawing::Point(71, 63);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(361, 22);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Количество коэфициентов 1-го полинома";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9));
			this->label2->Location = System::Drawing::Point(71, 127);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(301, 22);
			this->label2->TabIndex = 1;
			this->label2->Text = L"Коэффициенты первого полинома";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9));
			this->label3->Location = System::Drawing::Point(71, 227);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(361, 22);
			this->label3->TabIndex = 2;
			this->label3->Text = L"Количество коэфициентов 2-го полинома";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9));
			this->label4->Location = System::Drawing::Point(71, 292);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(299, 22);
			this->label4->TabIndex = 3;
			this->label4->Text = L"Коэффициенты второго полинома";
			// 
			// button1
			// 
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10));
			this->button1->Location = System::Drawing::Point(545, 410);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(176, 57);
			this->button1->TabIndex = 4;
			this->button1->Text = L"Выход";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm::button1_Click);
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(75, 88);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(70, 26);
			this->textBox1->TabIndex = 5;
			this->textBox1->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &MyForm::textBox1_KeyPress);
			// 
			// textBox2
			// 
			this->textBox2->Location = System::Drawing::Point(75, 152);
			this->textBox2->Name = L"textBox2";
			this->textBox2->Size = System::Drawing::Size(272, 26);
			this->textBox2->TabIndex = 6;
			this->textBox2->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &MyForm::textBox2_KeyPress);
			// 
			// textBox3
			// 
			this->textBox3->Location = System::Drawing::Point(75, 254);
			this->textBox3->Name = L"textBox3";
			this->textBox3->Size = System::Drawing::Size(70, 26);
			this->textBox3->TabIndex = 7;
			this->textBox3->TextChanged += gcnew System::EventHandler(this, &MyForm::textBox3_TextChanged);
			this->textBox3->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &MyForm::textBox1_KeyPress);
			// 
			// textBox4
			// 
			this->textBox4->Location = System::Drawing::Point(75, 317);
			this->textBox4->Name = L"textBox4";
			this->textBox4->Size = System::Drawing::Size(272, 26);
			this->textBox4->TabIndex = 8;
			this->textBox4->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &MyForm::textBox2_KeyPress);
			// 
			// button2
			// 
			this->button2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10));
			this->button2->Location = System::Drawing::Point(545, 78);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(176, 61);
			this->button2->TabIndex = 9;
			this->button2->Text = L"Сложить";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &MyForm::button2_Click);
			// 
			// button3
			// 
			this->button3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10));
			this->button3->Location = System::Drawing::Point(545, 183);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(176, 66);
			this->button3->TabIndex = 10;
			this->button3->Text = L"Перемножить";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &MyForm::button3_Click);
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9));
			this->label5->Location = System::Drawing::Point(71, 398);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(0, 22);
			this->label5->TabIndex = 11;
			// 
			// textBox5
			// 
			this->textBox5->BackColor = System::Drawing::SystemColors::Info;
			this->textBox5->Location = System::Drawing::Point(75, 429);
			this->textBox5->Name = L"textBox5";
			this->textBox5->Size = System::Drawing::Size(272, 26);
			this->textBox5->TabIndex = 12;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(9, 20);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::AppWorkspace;
			this->ClientSize = System::Drawing::Size(780, 520);
			this->Controls->Add(this->textBox5);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->button3);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->textBox4);
			this->Controls->Add(this->textBox3);
			this->Controls->Add(this->textBox2);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
			this->MaximizeBox = false;
			this->Name = L"MyForm";
			this->Text = L"Сложение и умножение полиномов";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

	private:
		static array<char>^ s = gcnew array<char>(200);
		static array<char>^ l = gcnew array<char>(200);
		static array<int>^ A = gcnew array<int>(50);
		static array<int>^ Q = gcnew array<int>(50);
		static array<int>^ I = gcnew array<int>(50);
		static int dim1 = 0;
		static int dim2 = 0;
		static int p1 = 0;
		static int p2 = 0;


		///Выход из программы
	private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) {
		Close();
	}
		//Проверка символов для степеней 
	private: System::Void textBox1_KeyPress(System::Object^ sender, System::Windows::Forms::KeyPressEventArgs^ e) {
		if (((e->KeyChar >= '0') && (e->KeyChar <= '9') || (e->KeyChar <= 8))) return; // (e->KeyChar <= 8) чтоб бэкспэйсом можно было удалять
		//остальные символы запрещены
		e->Handled = true;
	}
		   //Проверка символов для коэффициентов
	private: System::Void textBox2_KeyPress(System::Object^ sender, System::Windows::Forms::KeyPressEventArgs^ e) {
		if ((((e->KeyChar >= '0') && (e->KeyChar <= '9'))|| (e->KeyChar <= 8)) || (e->KeyChar == ' ') ||
			(e->KeyChar == '-')) return;
		//Остальные символы запрещены
		e->Handled = true;
	}




		   ///Сложение полиномов
	private: System::Void button2_Click(System::Object^ sender, System::EventArgs^ e) {

		array<String^>^ as;
		array<Char>^ ar;
		ar = gcnew array<Char>(1);
		ar[0] = ' ';

		if ((textBox2->Text->Length != 0) && (textBox3->Text->Length != 0) && (textBox1->Text->Length != 0) && (textBox4->Text->Length != 0)) {
			
				dim1 = Convert::ToInt32(textBox1->Text);
				label1->Text = "Степень первого полинома = " + textBox1->Text;

				dim2 = Convert::ToInt32(textBox3->Text);
				label3->Text = "Степень второго полинома = " + textBox3->Text;

				p1 = 0;
				p2 = 0;


				if (dim1 < 1 || dim2 < 1) {
					MessageBox::Show("Степень многочлена не может быть меньше 1",
						"Ой",
						MessageBoxButtons::OK,
						MessageBoxIcon::Asterisk);
				}
				else {

					//Получение коэффициентов первого полинома из строки
					as = textBox2->Text->Split(ar);
					for (int i = 0; i < dim1; i++)
					{
						A[i] = Convert::ToInt32(as[i]);
						p1++;
					}

					//Получение коэффициентов второго полинома из строки
					as = textBox4->Text->Split(ar);
					for (int j = 0; j < dim2; j++)
					{
						Q[j] = Convert::ToInt32(as[j]);
						p2++;
					}

			
			

					if ((p1 == dim1) && (p2 == dim2)){

						int mdim; //наименьшая степень
						int Mdim; //наибольшая степень

						if (dim1 < dim2) {
							mdim = dim1; 
							Mdim = dim2;
						}else {
							mdim = dim2;
							Mdim = dim1;
						}

						label5->Text = "Коэффициенты суммы полиномов";
						textBox5->Text = "";

						for (int i = 0; i < Mdim; i++) {
							I[i] = A[i] + Q[i];
							textBox5->Text += System::Convert::ToString(I[i]);
							textBox5->Text += " ";
						}

						label5->Text = "Коэффициенты суммы полиномов";

					}
					else label5->Text = "Вы ввели не все координаты/степени и количество коэффициентов не совпадают";
				}
		}
		else {
			MessageBox::Show("Вы ввели не все данные !\n",
				"Ошибка",
				MessageBoxButtons::OK,
				MessageBoxIcon::Error);
		}
	}


		   ///Умножение полиномов
	private: System::Void button3_Click(System::Object^ sender, System::EventArgs^ e) {

		array<String^>^ as;
		array<Char>^ ar;
		ar = gcnew array<Char>(1);
		ar[0] = ' ';

		

		if ((textBox2->Text->Length != 0) && (textBox3->Text->Length != 0) && (textBox1->Text->Length != 0) && (textBox4->Text->Length != 0)) {
			textBox5->Text = "";

			dim1 = Convert::ToInt32(textBox1->Text);
			label1->Text = "Степень первого полинома = " + textBox1->Text;

			dim2 = Convert::ToInt32(textBox3->Text);
			label3->Text = "Степень второго полинома = " + textBox3->Text;

			p1 = 0;
			p2 = 0;

			if (dim1 < 1 || dim2 < 1) {
					MessageBox::Show("Степень многочлена не может быть меньше 1",
						"Ой",
						MessageBoxButtons::OK,
						MessageBoxIcon::Asterisk);
			}
			else {
					//Получение коэффициентов первого полинома из строки
					as = textBox2->Text->Split(ar);
					for (int i = 0; i < dim1; i++)
					{
						A[i] = Convert::ToInt32(as[i]);
						p1++;
					}

					//Получение коэффициентов второго полинома из строки
					as = textBox4->Text->Split(ar);
					for (int j = 0; j < dim2; j++)
					{
						Q[j] = Convert::ToInt32(as[j]);
						p2++;
					}

					if ((p1 == dim1) && (p2 == dim2))
					{

						//Опустошаем массив I[]
						for (int i = 0; i < 50; i++) {
							I[i] = 0;
						}



						//Заполняем массив I[] коэф-ми произведения

						int k = 0;
						
							for (int j = 0; j < dim2; j++) {
								for (int i = 0; i < dim1; i++) {
									I[i + k] += A[i] * Q[j];
								};
								k++;
							}
					
			
						for (int y = 0; y < dim1 + dim2 - 1 ; y++) {
							textBox5->Text += System::Convert::ToString(I[y]);
							textBox5->Text += " ";

						}
							label5->Text = "Коэффициенты произведения полиномов";
			        }
			        else label5->Text = "Вы ввели не все координаты/степени и количество коэффициентов не совпадают";
			}
		}
		else {
			MessageBox::Show("Вы ввели не все данные !\n",
				"Ошибка",
				MessageBoxButtons::OK,
				MessageBoxIcon::Error);
		}
	}

private: System::Void textBox3_TextChanged(System::Object^ sender, System::EventArgs^ e) {
}
};
}

