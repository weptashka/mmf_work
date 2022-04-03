#!/bin/bash
# Создать каталог DIR и в нем создать файл Myfile.txt, записать
# в файл свою фамилию и текущее время.

mkdir DIR;
echo "Anashkin" > DIR/Myfile.txt;
date '+%T' >> DIR/Myfile.txt;

exit 0