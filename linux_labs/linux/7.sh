#!/bin/bash
# Определить тип треугольника с заданными сторонами
# (равносторонний, равнобедренный, прямоугольный). Стороны
# вводятся с клавиатуры.

echo "enter 3 sides of triangle. a <= b <= c"
read a b c
if ((a*a + b*b == c*c)); then
  echo "rectangular"
elif ((a == b && b == c)); then
  echo "equilateral"
elif ((a == b || a == c || b == c)); then
  echo "isosceles"
fi

exit 0
