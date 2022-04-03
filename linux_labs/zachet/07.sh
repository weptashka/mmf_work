#! bin/bash

if [ $# -ne 3 ]
then 
	echo "3 arguments required!"
	exit
fi

sum=0
for arg in $@
do
	sum=$((sum+arg))
done

echo -e  "Answer: \c"
echo "scale=2;$sum/3" | bc

