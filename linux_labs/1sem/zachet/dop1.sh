#!/bin/bash
sumf=0
sumd=0
sum=0
for i in `ls . `
do
if [[ -f "$i" ]]
then
sumf=$(($sumf+1))
fi

if [[ -d "$i" ]]
then
sumd=$(($sumf+1))
fi
sum=$(($sum+1))
done
if [[ $sumf+$sumd -eq $sum ]]
then
echo "All elements of the current directory are files or directories"
else
echo "Not all elements of the current directory are files or directories"
fi
exit 0