#!/bin/bash

echo -n "Enter the year: "
read year

if [ $[$year%4] -eq 0 ] && [ $[$year%100] -ne 0 ] || [ $[$year%400] -eq 0 ]
then
	echo "visokosniy"
else
	echo "Ne visokosniy"
fi

exit 0
