#!/bin/bash
#Find the avg og 3 arg, but if there is not 3 args,
#then show the message and quit

if [ $# -ne 3 ]; then
   echo 'you entered more or less then 3 args'
   exit 1
fi

sum=0
for arg in $@
do
   sum=$(($sum+$arg))
done

avg=$(($sum/3))

echo "sum of args: $sum"
echo "avg of 3 args: $avg"
