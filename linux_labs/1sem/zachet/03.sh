#! bin/bash

echo -n "Enter first number: "
read num1

echo -n "Enter second number: "
read num2

echo "Sum: $[$num1 + $num2]"
echo "Difference: $[$num1 - $num2]"
echo "Quotient: $[$num1 / $num2]"
echo "Product: $[$num1 * $num2]"
echo "Remainder: $[$num1 % $num2]"
