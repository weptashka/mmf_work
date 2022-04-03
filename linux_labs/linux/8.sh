#!/bin/bash
# Найти среднее от чисел от 1 до n, n вводится как аргумент
# командной строки.

read -p "enter n" n
sum=0
for ((i=1;i<=n;i++))
do
  sum=$(($sum + $i))
done

echo "res = $(($sum/$n))"

exit 0
