#!/bin/bash
sum=0
sumf=0
for i in `ls . ` ; do
    if [[ -f "$i" ]]; then
        echo "kek"
        sumf=$[$sumf+1]
    fi
    if [[ -d "$i" ]]; then
        echo "kek"
        sumf=$[$sumf+1]
    fi
    sum=$[$sum+1]
done
echo $sum
echo $sumf
if [[ $sumf -eq $sum ]]; then
        echo "lol"
    fi
