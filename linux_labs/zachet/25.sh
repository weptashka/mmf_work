#! bin/bash

echo -n "Enter the number: "
read num

temp=0
first=0
second=1

while [ $first -lt $num ]
do
	echo -n $first " "
	temp=$second
	first=$second
	second=$[$temp + $second]
done

echo ""

exit 0
