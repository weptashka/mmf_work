#!/bin/bash
# Найти сумму цифр в заданном числе, число вводится с клавиатуры.

read -p "enter the number " a
sum=0
while ((a > 0))
do
  sum=$(($sum + ($a % 10)))
  a=$(($a / 10))
done

echo "sum = $sum"
exit 0
