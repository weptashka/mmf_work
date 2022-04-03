#! bin/bash

sum() {
if [ $1 -le 9 ]
then
	echo $1
else
	first=$(sum $[ $1 % 10 ] )
	second=$(sum $[ $1 / 10 ] )
	
	echo $[ $first + $second ]
fi
}

echo -n "Enter a number: "
read n

sum $n

exit 0
