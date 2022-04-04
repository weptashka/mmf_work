#! bin/bash

echo -n "Enter a number: "
read num

check=1

for(( i=2; i<=$[$num/2]; i++ ))
do
	if [ $[$num%$i] -eq 0 ]
	then
		check=0
		break;
	fi
done

if [ $check -eq 1 ]
then
	echo "simple"
else
	echo "not simple"
fi

exit 0
