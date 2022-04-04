#! bin/bash

echo -n "Enter first number: "
read num1

echo -n "Enter second number: "
read num2

if test $num1 -gt $num2
then
	echo $num1
else
	echo $num2
fi

exit 0
