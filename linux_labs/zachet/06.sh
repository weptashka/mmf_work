#! bin/bash

echo "Amount of args: $#"
sum=0
for arg in $@
do 
	sum=$((sum + arg))
done

echo "Sum of args: $sum"
