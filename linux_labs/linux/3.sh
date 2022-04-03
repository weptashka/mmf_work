#!/bin/bash
# Перевести число из одной системы счисления в другую (подсказка: bc, ibase, obase)

read -p "enter the first number " number
read -p "enter ibase " ibase
read -p "enter obase " obase

echo "ibase=$ibase;obase=$obase;$number" | bc

exit 0