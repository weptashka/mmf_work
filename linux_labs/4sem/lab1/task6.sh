#!/bin/bash
#Fing the biggest number amount 3
#Enter numbers as a args


if [ $# -ne 3 ]; then
   echo "you shoud enter 3 numbers"
   exit 1
fi

max=$1

for arg in $@
do
   if [ $max -lt $arg ]; then
      max=$arg
   fi
done

echo "max number: $max"

