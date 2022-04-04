#!/bin/bash
# Запрос и ввод имени пользователя, сравнение с именем пользователя,
# хранимом в программе и вывод сообщения: угадал/не угадал.

username="Viktor"
read -p "Enter the username " guess
if [ $guess == $username ]; then
    echo "You're right"
else
    echo "You aren't right"
fi

exit 0