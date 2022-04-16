#!/bin/bash
#Find avg from 1 to n, n - as arg of command line

sum=0
i=1
while [ $i -le $1 ]
do
   sum=$(($sum+$i))
   i=$(($i+1))
done

avg=$(($sum/$1))

echo  "$avg"
