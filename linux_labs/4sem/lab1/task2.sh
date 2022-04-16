#!/bin/bash
#Find the number and the sum of args in command line

echo "Number of args: $#"

sum=0
for arg in $@
do
   sum=$(($sum+$arg))
done

echo "Sum of args: $sum"







