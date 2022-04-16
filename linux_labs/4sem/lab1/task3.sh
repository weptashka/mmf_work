#!/bin/bash
#translate from one number system to another
#write in command line
# 1)number you want to translate
# 2) system, from which you translate
# 3)system, to which tou translate

echo "ibase=$2;obase=$3;$1" | bc

