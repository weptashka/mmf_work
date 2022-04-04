#!/bin/bash
echo -n 'Please, write x coord'
read x
echo -n 'Please, write y coord'
read y
if [ $x -gt 0 ] && [ $y -gt 0 ]; then
	echo "The first"
   else if [ $x -gt 0 ] && [ $y -lt 0 ]; then
			echo "The fourth"
		else if [ $x -lt 0 ] && [ $y -gt 0 ]; then
				echo "The second"
			else if [ $x -lt 0 ] && [ $y -lt 0 ]; then
			echo "The third"
			else
				echo "Point belongs to coordinate lines"
			fi
			fi
		fi
		fi
