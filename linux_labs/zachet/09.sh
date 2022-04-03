#! bin/bash

date

if [ $? -eq 0 ] 
# $? proveryaet viponenie komandi i vozvrat 0 esli vse ok
then
	echo "Success"
else 
	echo -e "Something went wrong :(\nTry again"
fi

exit 0
