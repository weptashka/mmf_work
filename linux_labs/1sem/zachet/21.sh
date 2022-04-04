#! bin/bash

echo -n "Enter n:"
read n

i=1
sum=0

while [ $i -le $n ]
do
	sum=$[$sum+$i]
	i=$[$i+1]
done
echo -n "Average: "
echo "scale=2;$sum / $n" | bc


exit 0
