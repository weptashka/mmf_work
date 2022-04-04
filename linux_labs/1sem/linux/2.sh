#!/bin/bash
# Вывести количество и сумму аргументов командной строки.

sum=0
for arg in $*
  do
    sum=` expr $arg + $sum`
  done

echo "amount = $#"
echo "sum = $sum"

exit 0