#!/bin/bash

echo Enter 1 side
read a
echo Enter 2 side
read b
echo Enter 3 side
read c

if [ $[$a+$b] -lt $c ] || [ $[$a+$c] -lt $b ] || [ $[$b+$c] -lt $a ]; then
	echo "Ошибка! Это не треугольник"
	exit 1
fi
if [ $a -eq $b ] && [ $b -eq $c ] && [ $a -eq $c ]; then
	echo "Это равносторонний треугольник"
   else if [ $a -eq $b ] || [ $b -eq $c ] || [ $a -eq $c ]; then
			echo "Это равнобедренный треугольник"
		else if [ $[$[$a*$a]+$[$b*$b]] -eq $[$c*$c] ] || [ $[$[$b*$b]+$[$c*$c]] -eq $[$a*$a] ] || [ $[$[$a*$a]+$[$c*$c]] -eq $[$b*$b] ]; then
				echo "Это прямоугольный треугольник"
			else
				echo "Это разносторонний треугольник"
			fi
		fi
		fi
