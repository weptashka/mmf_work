#!/bin/bash
echo -n 'Please, choose the operation (*, /, +, -)'
read op
echo -n 'write the first number'
read first
echo -n 'write the second number'
read second
		
		case $op in
		"+" ) echo $[$first+$second] ;;
		"-" ) echo $[$first-$second] ;;
		"/" ) if [ $second -eq 0 ]; then
		echo "na 0 delit nelzya"
		else
		echo $[$first/$second]
		fi ;;
		"*" ) echo $[$first*$second] ;;
		* ) echo 'Please, write down once more'
		esac
		
		
			
