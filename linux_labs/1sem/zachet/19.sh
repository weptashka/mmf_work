echo -n "Enter a symbol: "
read char

case "$char" in
	[[:alpha:]])
			echo "It's a letter"
		;;
	[[:digit:]])
			echo "It's a digit"
		;;
	[^\$\|\?\*\+\(\)\{\}\[\]])
			echo "It'a a special symbol"
		;;
	[[:punct:]])
			echo "It's a punctuation symbol"
		;;
	[[:cntrl:]])
			echo "It's a control character"
		;;
	[[:blank:]])
			echo "It's a space or tab symbol"
		;;
esac
#alnum   alpha   ascii   blank   cntrl   digit   graph   lower
#print   punct   space   upper   word    xdigit
exit 0
