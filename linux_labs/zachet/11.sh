#! bin/bash

case "$#" in
	2)
		if [ $1 -ge $2 ]
		then
			echo $1
		else
			echo $2
		fi
	;;
	3)
		if [ $1 -ge $2 ]
		then
			if [ $1 -ge $3 ]
			then
				echo $1
			else
				echo $3
			fi
		else if [ $2 -ge $3 ]
		then
			if [ $2 -ge $3 ]
			then 
				echo $2
			fi
		else
			echo $3
		fi
		fi
	;;

esac

exit 0
