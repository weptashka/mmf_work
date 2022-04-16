#!/bin/bash
#enter your name and program will compare it with users' name

myname=$USER

echo "Enter name: "

read enteredName
if [ $enteredName = $myname ]; then
   echo "Success"
else
   echo "Wrong name"
fi
