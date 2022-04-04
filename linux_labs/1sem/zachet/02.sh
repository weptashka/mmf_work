#! bin/bash

echo "Enter the number of command:"
echo "g - grep"
echo "p - ps"
read command

case "$command" in
	g)
		echo "Enter a pattern you want to find:"
		read pattern

		echo "Enter the place where you want to find:"
		read place
			
		echo "grep "$pattern" "$place""
		grep -F "$pattern" "$place"
	;;
	p)
		echo "Enter the string of flags"
		read flags
		ps -$flags
	;;
esac

exit 0
