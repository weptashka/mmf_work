#pragma once
#include "Vector.h"

namespace vect 
{

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
	private: System::Windows::Forms::MenuStrip^ menuStrip1;
	protected:
	private: System::Windows::Forms::ToolStripMenuItem^ fileToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^ openToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^ saveToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^ exitToolStripMenuItem;
	private: System::Windows::Forms::TextBox^ txtbox_before;

	private: System::Windows::Forms::OpenFileDialog^ openFileDialog1;
	private: System::Windows::Forms::Label^ label1;

	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::SaveFileDialog^ saveFileDialog1;
	private: System::Windows::Forms::Button^ btn_clearbefore;
	private: System::Windows::Forms::Button^ btn_clearafter;







	private: System::Windows::Forms::TextBox^ txtbox_after;
	private: System::Windows::Forms::Button^ bttn_find;
	private: System::Windows::Forms::CheckBox^ checkbox_v;





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
			this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
			this->fileToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->openToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->saveToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->exitToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->txtbox_before = (gcnew System::Windows::Forms::TextBox());
			this->openFileDialog1 = (gcnew System::Windows::Forms::OpenFileDialog());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->saveFileDialog1 = (gcnew System::Windows::Forms::SaveFileDialog());
			this->btn_clearbefore = (gcnew System::Windows::Forms::Button());
			this->btn_clearafter = (gcnew System::Windows::Forms::Button());
			this->txtbox_after = (gcnew System::Windows::Forms::TextBox());
			this->bttn_find = (gcnew System::Windows::Forms::Button());
			this->checkbox_v = (gcnew System::Windows::Forms::CheckBox());
			this->menuStrip1->SuspendLayout();
			this->SuspendLayout();
			// 
			// menuStrip1
			// 
			this->menuStrip1->GripMargin = System::Windows::Forms::Padding(2, 2, 0, 2);
			this->menuStrip1->ImageScalingSize = System::Drawing::Size(24, 24);
			this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) { this->fileToolStripMenuItem });
			this->menuStrip1->Location = System::Drawing::Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Size = System::Drawing::Size(963, 36);
			this->menuStrip1->TabIndex = 0;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this->fileToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(3) {
				this->openToolStripMenuItem,
					this->saveToolStripMenuItem, this->exitToolStripMenuItem
			});
			this->fileToolStripMenuItem->Name = L"fileToolStripMenuItem";
			this->fileToolStripMenuItem->Size = System::Drawing::Size(54, 32);
			this->fileToolStripMenuItem->Text = L"File";
			// 
			// openToolStripMenuItem
			// 
			this->openToolStripMenuItem->Name = L"openToolStripMenuItem";
			this->openToolStripMenuItem->Size = System::Drawing::Size(201, 34);
			this->openToolStripMenuItem->Text = L"Open file";
			this->openToolStripMenuItem->Click += gcnew System::EventHandler(this, &MyForm::openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this->saveToolStripMenuItem->Name = L"saveToolStripMenuItem";
			this->saveToolStripMenuItem->Size = System::Drawing::Size(201, 34);
			this->saveToolStripMenuItem->Text = L"Save to file";
			this->saveToolStripMenuItem->Click += gcnew System::EventHandler(this, &MyForm::saveToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this->exitToolStripMenuItem->Name = L"exitToolStripMenuItem";
			this->exitToolStripMenuItem->Size = System::Drawing::Size(201, 34);
			this->exitToolStripMenuItem->Text = L"Exit";
			this->exitToolStripMenuItem->Click += gcnew System::EventHandler(this, &MyForm::exitToolStripMenuItem_Click);
			// 
			// txtbox_before
			// 
			this->txtbox_before->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->txtbox_before->Font = (gcnew System::Drawing::Font(L"Consolas", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->txtbox_before->Location = System::Drawing::Point(36, 114);
			this->txtbox_before->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->txtbox_before->Multiline = true;
			this->txtbox_before->Name = L"txtbox_before";
			this->txtbox_before->Size = System::Drawing::Size(343, 306);
			this->txtbox_before->TabIndex = 1;
			this->txtbox_before->Text = L"1 1 1\r\n111 111 111\r\n1 2 3\r\n2 4 6\r\n3 2 1\r\n4 8 12\r\n6 4 2";
			// 
			// openFileDialog1
			// 
			this->openFileDialog1->FileName = L"openFileDialog1";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Arial", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->label1->Location = System::Drawing::Point(34, 68);
			this->label1->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(110, 27);
			this->label1->TabIndex = 2;
			this->label1->Text = L"Вектора:";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Arial", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->label2->Location = System::Drawing::Point(566, 68);
			this->label2->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(277, 27);
			this->label2->TabIndex = 2;
			this->label2->Text = L"Коллинеарные вектора:";
			// 
			// btn_clearbefore
			// 
			this->btn_clearbefore->Font = (gcnew System::Drawing::Font(L"Arial", 9.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->btn_clearbefore->Location = System::Drawing::Point(38, 445);
			this->btn_clearbefore->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->btn_clearbefore->Name = L"btn_clearbefore";
			this->btn_clearbefore->Size = System::Drawing::Size(122, 43);
			this->btn_clearbefore->TabIndex = 3;
			this->btn_clearbefore->Text = L"Очистить";
			this->btn_clearbefore->UseVisualStyleBackColor = true;
			this->btn_clearbefore->Click += gcnew System::EventHandler(this, &MyForm::btn_clearbefore_Click);
			// 
			// btn_clearafter
			// 
			this->btn_clearafter->Font = (gcnew System::Drawing::Font(L"Arial", 9.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->btn_clearafter->Location = System::Drawing::Point(789, 445);
			this->btn_clearafter->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->btn_clearafter->Name = L"btn_clearafter";
			this->btn_clearafter->Size = System::Drawing::Size(122, 43);
			this->btn_clearafter->TabIndex = 3;
			this->btn_clearafter->Text = L"Очистить";
			this->btn_clearafter->UseVisualStyleBackColor = true;
			this->btn_clearafter->Click += gcnew System::EventHandler(this, &MyForm::btn_clearafter_Click);
			// 
			// txtbox_after
			// 
			this->txtbox_after->Font = (gcnew System::Drawing::Font(L"Consolas", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->txtbox_after->Location = System::Drawing::Point(566, 114);
			this->txtbox_after->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->txtbox_after->Multiline = true;
			this->txtbox_after->Name = L"txtbox_after";
			this->txtbox_after->Size = System::Drawing::Size(343, 306);
			this->txtbox_after->TabIndex = 1;
			// 
			// bttn_find
			// 
			this->bttn_find->Font = (gcnew System::Drawing::Font(L"Arial", 9.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->bttn_find->Location = System::Drawing::Point(406, 246);
			this->bttn_find->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->bttn_find->Name = L"bttn_find";
			this->bttn_find->Size = System::Drawing::Size(132, 43);
			this->bttn_find->TabIndex = 3;
			this->bttn_find->Text = L"Найти";
			this->bttn_find->UseVisualStyleBackColor = true;
			this->bttn_find->Click += gcnew System::EventHandler(this, &MyForm::bttn_find_Click);
			// 
			// checkbox_v
			// 
			this->checkbox_v->AutoSize = true;
			this->checkbox_v->Font = (gcnew System::Drawing::Font(L"Arial", 9.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->checkbox_v->Location = System::Drawing::Point(392, 298);
			this->checkbox_v->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->checkbox_v->Name = L"checkbox_v";
			this->checkbox_v->Size = System::Drawing::Size(165, 50);
			this->checkbox_v->TabIndex = 4;
			this->checkbox_v->Text = L"Допускать \r\nразные длины";
			this->checkbox_v->UseVisualStyleBackColor = true;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(9, 20);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::InactiveCaption;
			this->ClientSize = System::Drawing::Size(963, 511);
			this->Controls->Add(this->checkbox_v);
			this->Controls->Add(this->bttn_find);
			this->Controls->Add(this->btn_clearafter);
			this->Controls->Add(this->btn_clearbefore);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->txtbox_before);
			this->Controls->Add(this->menuStrip1);
			this->Controls->Add(this->txtbox_after);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
			this->MainMenuStrip = this->menuStrip1;
			this->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->MaximizeBox = false;
			this->Name = L"MyForm";
			this->Text = L"Нахождение коллинеарных векторов";
			this->menuStrip1->ResumeLayout(false);
			this->menuStrip1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

	private: System::Void exitToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e) //Закрытие окна
	{
		this->Close(); //Вызываем закрытие формы
	}

	private: System::Void btn_clearbefore_Click(System::Object^ sender, System::EventArgs^ e) //Очистка текст бокса с исходними векторами
	{
		txtbox_before->Text = ""; //Устанавливаем пустой текст
	}

	private: System::Void btn_clearafter_Click(System::Object^ sender, System::EventArgs^ e) {
		txtbox_after->Text = "";
	}

	private: static array<Vector^>^ vectors = gcnew array<Vector^>(0); //Массив векторов

	private: System::Void bttn_find_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		try
		{
			if (txtbox_before->Text == "") throw gcnew Exception("Введите вектора"); //Если текстбокс пустой, кидаем ошибку

			array<String^>^ vecstr; //Вспомогательный массив
			array<Char>^ delim1 = { '\n' }; //Разделитель

			//Разделяем строку с векторами и заносим в массив строк
			vecstr = this->txtbox_before->Text->Trim()->Split(delim1, StringSplitOptions::RemoveEmptyEntries);
			
			// Параметр StringSplitOptions.RemoveEmptyEntries тут говорит, что надо удалить все переносы

			Array::Resize(vectors, vecstr->Length); //Устанавливаем размер массива векторов как размер полученного массива строк

			for (int i = 0; i < vectors->Length; i++) //Проходимся по элементам массива векторов
			{
				vectors[i] = gcnew Vector(vecstr[i]); //И создаем новый объект вектора по строке с его элементами				                                    
			} 





			String^ restext = ""; //строка, в которую будем класть коллинеарные
			
			for (int i = 0; i < vectors->Length-1; i++) //Проходимся по массиву векторов
			{
				bool first, group;
				
					if (vectors[i]->isChecked() == false) //Если текущий вектор еще не проверен
					{
						first = true; group = false;
						
						for (int j = i + 1; j < vectors->Length; j++) //Проходимся по векторам после него
						{
							try
							{
								if (vectors[i]->isCollinear(vectors[j])) //И проверяем на коллинеарность
								{
									vectors[j]->Check(); //Если вектора коллинеарны, то как бы проверен
									//И выводим текущий вектор, если он выводится в первый раз
									if (first) restext += vectors[i]->format() + "\r\n"; 
									first = false;
									restext += vectors[j]->format() + "\r\n"; //Выводим коллинеарный текущему вектор
									group = true; //Указываем, что создаем группу из коллинеарных векторов
								}
							}
							catch (ArgumentException^ ex) //Ловим ошибку если длины векторов не одинаковы
							{
								if (checkbox_v->Checked) continue; //Если допускаем разные длины, то продолжаем цикл
								else throw ex; //Иначе снова кидаем ошибку и выходим из цикла
							}
						}
						if (group) restext += "\r\n"; //Если группа векторов есть, выводим новую строчку
					}
			}
			
			txtbox_after->Text = restext->Trim(); //Устанавливаем полученные вектора

		}

		catch (FormatException^ ex) //Обработка ошибки когда было введено не число
		{
			MessageBox::Show("Элементами векторов должны быть числа", "Ошибка");
		}
		catch (Exception^ ex) //Обработка других ошибок
		{
			MessageBox::Show(ex->Message, "Ошибка");
		}
	}

		   private: System::Void openToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e) //Открытие файла
		   {
			   System::Windows::Forms::DialogResult dr; //Результат диалога
			   String^ filename; //Путь к файлу

			   dr = openFileDialog1->ShowDialog(); //Выводим окно открытия файлов

			   if (dr == System::Windows::Forms::DialogResult::OK) //Если он успешно открылся
			   {
				   filename = openFileDialog1->FileName; //Сохраняем путь к файлу для чтения
				   try
				   {
					   System::IO::StreamReader^ sr = gcnew System::IO::StreamReader(filename); //Создаем новый поток для чтения

					   txtbox_before->Text = sr->ReadToEnd(); //Читаем текст из потока и сохраняем в текстовое поле с исходним текстом

					   sr->Close(); //Закрываем поток
				   }
				   catch (System::IO::FileLoadException^ ex) //Обрабатываем возникающие ошибки
				   {
					   //Выводим окно с ошибкой
					   MessageBox::Show("Ошибка ввода текста из файла", "Ошибка", MessageBoxButtons::OK, MessageBoxIcon::Error);
				   }
			   }
		   }

	private: System::Void saveToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e) //Сохранение файла
	{
		System::Windows::Forms::DialogResult dr; //Результат диалога
		String^ filename; //Путь к файлу

		dr = saveFileDialog1->ShowDialog(); //Показываем окно с сохранением файла

		if (dr == System::Windows::Forms::DialogResult::OK)
		{
			filename = saveFileDialog1->FileName; //Сохраняем путь к файлу
			try
			{
				System::IO::FileInfo^ fi = gcnew System::IO::FileInfo(filename); //Создаем новый объект информации о файле

				System::IO::StreamWriter^ sw = fi->CreateText(); //Создаем из него поток для записи

				sw->Write(txtbox_after->Text); //Записываем отредактированный текст

				sw->Close(); //Закрываем поток
			}
			catch (System::IO::IOException^ ex) //Обрабатываем ошибки
			{
				MessageBox::Show("Ошибка сохранения в файл", "Ошибка", MessageBoxButtons::OK, MessageBoxIcon::Error);
			}
		}
	}

};
}
