#! bin/bash

constants=euioay

echo -n "Enter a character: "
read char

if [[ $constants =~ $char ]]
then 
	echo "glasnaya"
else 
	echo "soglasnaya"
fi

exit 0


