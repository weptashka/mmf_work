#! bin/bash

factorial() {
        n=$1
        fact=1
        while [ $n -gt 1 ]
        do
                fact=$[ $fact * $n ]
                n=$[ $n - 1 ]
        done

        echo $fact
}

pow() {
	num=$1
	power=$2
	res=1
	j=0

	while [ $j -lt $power ]
	do
		res=$[ $res * $num ]
		j=$[ $j + 1 ]
	done

	echo $res
}

echo -n "Enter n: "
read n

echo -n "Enter x: "
read x

sum=1

for(( i=1; i <= $n; i++ ))
do
	numer=$(pow $x $i)
	denom=$(factorial $i)
	tmp=$(echo "scale=2;$numer/$denom" | bc)
	
	sum=$(echo "$sum+$tmp" | bc)
done

echo "Sum: " $sum

exit 0

