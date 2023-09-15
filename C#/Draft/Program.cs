//int counter = 0;
//int i = 0;
//while (i <= 48)
//{
//    i++;
//    counter++;
//}
//Console.WriteLine(counter);

//int i = 0;
//i += --i - i++;

//Console.WriteLine(i);



//int counter = 0;
//for(int i = 0; i <=32;  i++)
//{
//    counter++;
//}
//Console.WriteLine(counter);



//int i = -4;
//int result = i;

//if (i <= -6 || i > 5)
//{
//    result = 1;
//}
//else if (i > 2 && i <= 8) 
//{
//    result = 2;
//}
//Console.WriteLine(result);



//int Foo(int n) {
//    int acc = 1, i = 1;
//    do
//    {
//        acc *= 3;
//        i++;
//    } while (i - n < 0);
//    return acc;
//}

//Console.WriteLine(Foo(3));


//int[] arr = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

//Console.WriteLine(arr.GetLength(0) == 10);
//Console.WriteLine( arr.Length == 10);




//int Foo(bool b1, bool b2, int i)
//{
//    int result = 0;
//    if (b1) {
//        if (i >= -1 && i < 3) {
//                result = 1;
//            }
//        else if (i < -5 | i > 6)
//        {
//            result = 1;
//        }
//        else
//        {
//            result = 3;
//        }
//    }

//    if (!b2)
//    {
//        if (i < -9 || i >= 3)
//        {
//            result = 4;
//        }
//        else if (i > -4 & i <= 7)
//        {
//            result = 5;
//        }
//        else
//        {
//            result = 6;
//        }
//    }

//    return result;
//}

//Console.WriteLine(Foo(true, false, 3));
//Console.WriteLine(Foo(false, false,-3));
//Console.WriteLine(Foo(true, false, -9));
//Console.WriteLine(Foo(true, true, 6));
//Console.WriteLine(Foo(false, true,-1));


//string str = "Hello, Johnny!";

//string str1 = str.Substring(0, str.Length);
//string str2 = new string(str.ToCharArray(0, 6));
//string str3 = str.Remove(str.Length - 1, 1).Split(',')[1].TrimStart(' ');
//string str4 = str.Remove(0, str.Length - str.IndexOf(' ') - 1).TrimEnd(',');
//string str5 = str.Replace("Hello, ", string.Empty).Replace("!", "");



//Console.WriteLine(str1);
//Console.WriteLine(str2);
//Console.WriteLine(str3);
//Console.WriteLine(str4);
//Console.WriteLine(str5);




//int i = 30;
//int j = 8;

//i = i + i % j;
//Console.WriteLine(i);




bool x = false;
bool y = false;
bool z = false;

Console.WriteLine(x | (!x ^ !z)); 