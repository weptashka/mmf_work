#! bin/bash

echo -n "Enter the number of the day: "
read day

case "$day" in
	"1") echo "Monday";;
	"2") echo "Tuesday";;
	"3") echo "Wednesday";;
	"4") echo "Thursday";;
	"5") echo "Friday";;
	"6") echo "Saturday";;
	"7") echo "Sunday";;
esac

exit 0
