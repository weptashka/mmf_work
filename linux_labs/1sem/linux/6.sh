#!/bin/bash
# Найти большее из 3 чисел.

echo "Enter 3 numbers"
read first second third
max=$first
if (($second > $max)); then
    max=$second
    if (($third > $max)); then
            max=$third
    fi
elif (($third > $max)); then
    max=$third
fi
echo "max = $max"
exit 0
