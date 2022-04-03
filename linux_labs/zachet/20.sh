#! bin/bash

echo "***Choose an option***"
echo "1 - Find amount of files and cataloges in current location"
echo "2 - Show 10 sequently strings from the given file"
echo "3 - List of all processes owned by current user"
read option

case "$option" in
	1)
		var=$(ls)
		f_amount=0
		d_amount=0

		for file in $var
		do
			if [[ -d $file ]]
			then
				d_amount=$[ $d_amount + 1 ]
			else if [[ -f $file ]]
			then
				f_amount=$[ $f_amount + 1 ]	
			fi
			fi
		done

		echo "Amount of files: " $f_amount
		echo "Amount of directories: " $d_amount
	;;
	2)
		echo "Enter the path to the file:"
		read path

		head $path	
	;;
	3)
		ps -ux
	;;
esac

exit 0
