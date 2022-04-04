#!/bin/bash
# Вывести значения квадратов чисел от 1 до N, N вводится с клавиатуры.

read -p "enter n" n
sum=0
for ((i=1;i<=n;i++))
do
  echo "$i^2 = $((i*i))"
done

exit 0
