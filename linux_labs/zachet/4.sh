#!/bin/bash
echo -n 'Please, choose the operation (*, /, +, -)'
read op
echo -n 'write the first number'
read first
echo -n 'write the second number'
read second
if [ $op == '/' ] && [ $second -eq 0 ]; then
	echo "na 0 delit nelzya"
   
		else
		case $op in
		"+" ) echo $first+$second | bc -l ;;
		"-" ) echo $first-$second | bc -l ;;
		"/" ) echo $first/$second | bc -l ;;
		"*" ) echo $first*$second | bc -l ;;
		* ) echo 'Please, write down once more'
		esac
		
		fi
			
			
