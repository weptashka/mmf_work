#! bin/bash

echo -n "Enter two number: "
read num1 num2

mult=$[$num1*$num2]

while [ $num1 -ne $num2 ]
do
	if [ $num1 -gt $num2 ]
	then
		num1=$[$num1-$num2]
	else
		num2=$[$num2-$num1]
	fi
done

echo "NOK:" $[ $mult/$num1 ]

exit 0
