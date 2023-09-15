using System;
using System.Collections.Generic;
using TuringMachine.Entities;

namespace TuringMachine
{
    class Program
    {
        private const char EMPTY_CHAR = '#';

        static void Main(string[] args)
        {
            // Task1();
            Task2();
        }

        // Г = {0,1,2}. Considering a non-empty word P to be a positive ternary number, decrease this number by 1
        static void Task1()
        {
            var transitions = new Dictionary<(string, char), (string, char, Move)>
            {
                {("q0", '0'), ("q0", '0', Move.ToNext)},
                {("q0", '1'), ("q0", '1', Move.ToNext)},
                {("q0", '2'), ("q0", '2', Move.ToNext)},
                {("q0", EMPTY_CHAR), ("q1", EMPTY_CHAR, Move.ToPrev)},
                {("q1", '0'), ("q1", '2', Move.ToPrev)},
                {("q1", '1'), ("qy", '0', Move.ToCurrent)},
                {("q1", '2'), ("qy", '1', Move.ToCurrent)},
            };

            var inputWords = new[]
            {
                "211",
                "210",
                "200",
                "010",
                "001"
            };

            foreach (var word in inputWords)
            {
                Console.Write(word + " -> ");
                var turingMachine = new Machine(new[] { '0', '1', '2' }, transitions, word);
                var result = new string(turingMachine.Run(1).Item2);
                Console.WriteLine(result);
            }

            // var turingMachine = new Machine(new[] {'0', '1', '2'}, transitions, GetInputData());
            // var result = new string(turingMachine.Run(1).Item2);
            // Console.WriteLine(result);
        }

        // Г = {a, b}. Let the word P be of odd length. Remove the middle character from it
        static void Task2()
        {
            var transitions = new Dictionary<(string, char), (string, char, Move)>
            {
                {("q0", 'a'), ("q1", EMPTY_CHAR, Move.ToNext)},
                {("q0", 'b'), ("q2", EMPTY_CHAR, Move.ToNext)},


                {("q1", 'a'), ("q1", 'a', Move.ToNext)},
                {("q1", 'b'), ("q1", 'b', Move.ToNext)},
                {("q1", EMPTY_CHAR), ("qa", EMPTY_CHAR, Move.ToPrev)},


                {("qa", 'a'), ("qaa", EMPTY_CHAR, Move.ToPrev)},

                {("qaa", 'a'), ("qaa", 'a', Move.ToPrev)},
                {("qaa", 'b'), ("qaa", 'b', Move.ToPrev)},
                {("qaa", EMPTY_CHAR), ("qa1", 'a', Move.ToNext)},

                {("qa1", 'a'), ("qa2", EMPTY_CHAR, Move.ToNext)},
                {("qa2", EMPTY_CHAR), ("qpadstart", 'a', Move.ToCurrent)},
                {("qa2", 'a'), ("qa4", 'a', Move.ToNext)},
                {("qa2", 'b'), ("qa4", 'b', Move.ToNext)},
                {("qa4", 'a'), ("qa4", 'a', Move.ToNext)},
                {("qa4", 'b'), ("qa4", 'b', Move.ToNext)},
                {("qa4", EMPTY_CHAR), ("qa5", 'a', Move.ToPrev)},
                {("qa5", 'a'), ("qaa", EMPTY_CHAR, Move.ToPrev)},
                {("qa5", 'b'), ("qab", EMPTY_CHAR, Move.ToPrev)},

                {("qa1", 'b'), ("qa3", EMPTY_CHAR, Move.ToNext)},
                {("qa3", EMPTY_CHAR), ("qpadstart", 'a', Move.ToCurrent)},
                {("qa3", 'a'), ("qa6", 'a', Move.ToNext)},
                {("qa3", 'b'), ("qa6", 'b', Move.ToNext)},
                {("qa6", 'a'), ("qa6", 'a', Move.ToNext)},
                {("qa6", 'b'), ("qa6", 'b', Move.ToNext)},
                {("qa6", EMPTY_CHAR), ("qa7", 'a', Move.ToPrev)},
                {("qa7", 'a'), ("qba", EMPTY_CHAR, Move.ToPrev)},
                {("qa7", 'b'), ("qbb", EMPTY_CHAR, Move.ToPrev)},

                {("qa", 'b'), ("qab", EMPTY_CHAR, Move.ToPrev)},

                {("qab", 'a'), ("qab", 'a', Move.ToPrev)},
                {("qab", 'b'), ("qab", 'b', Move.ToPrev)},
                {("qab", EMPTY_CHAR), ("qa8", 'a', Move.ToNext)},

                {("qa8", 'a'), ("qa9", EMPTY_CHAR, Move.ToNext)},
                {("qa9", EMPTY_CHAR), ("qpadstart", 'b', Move.ToCurrent)},
                {("qa9", 'a'), ("qa10", 'a', Move.ToNext)},
                {("qa9", 'b'), ("qa10", 'b', Move.ToNext)},
                {("qa10", 'a'), ("qa10", 'a', Move.ToNext)},
                {("qa10", 'b'), ("qa10", 'b', Move.ToNext)},
                {("qa10", EMPTY_CHAR), ("qa11", 'b', Move.ToPrev)},
                {("qa11", 'a'), ("qaa", EMPTY_CHAR, Move.ToPrev)},
                {("qa11", 'b'), ("qab", EMPTY_CHAR, Move.ToPrev)},

                {("qa8", 'b'), ("qa12", EMPTY_CHAR, Move.ToNext)},
                {("qa12", EMPTY_CHAR), ("qpadstart", 'b', Move.ToCurrent)},
                {("qa12", 'a'), ("qa13", 'a', Move.ToNext)},
                {("qa12", 'b'), ("qa13", 'b', Move.ToNext)},
                {("qa13", 'a'), ("qa13", 'a', Move.ToNext)},
                {("qa13", 'b'), ("qa13", 'b', Move.ToNext)},
                {("qa13", EMPTY_CHAR), ("qa14", 'b', Move.ToPrev)},
                {("qa14", 'a'), ("qba", EMPTY_CHAR, Move.ToPrev)},
                {("qa14", 'b'), ("qbb", EMPTY_CHAR, Move.ToPrev)},


                {("q2", EMPTY_CHAR), ("qb", EMPTY_CHAR, Move.ToPrev)},
                {("q2", 'a'), ("q2", 'a', Move.ToNext)},
                {("q2", 'b'), ("q2", 'b', Move.ToNext)},


                {("qb", 'a'), ("qba", EMPTY_CHAR, Move.ToPrev)},

                {("qba", 'a'), ("qba", 'a', Move.ToPrev)},
                {("qba", 'b'), ("qba", 'b', Move.ToPrev)},
                {("qba", EMPTY_CHAR), ("qb1", 'b', Move.ToNext)},

                {("qb1", 'a'), ("qb2", EMPTY_CHAR, Move.ToNext)},
                {("qb2", EMPTY_CHAR), ("qpadstart", 'a', Move.ToCurrent)},
                {("qb2", 'a'), ("qb3", 'a', Move.ToNext)},
                {("qb2", 'b'), ("qb3", 'b', Move.ToNext)},
                {("qb3", 'a'), ("qb3", 'a', Move.ToNext)},
                {("qb3", 'b'), ("qb3", 'b', Move.ToNext)},
                {("qb3", EMPTY_CHAR), ("qb4", 'a', Move.ToPrev)},
                {("qb4", 'a'), ("qaa", EMPTY_CHAR, Move.ToPrev)},
                {("qb4", 'b'), ("qab", EMPTY_CHAR, Move.ToPrev)},

                {("qb1", 'b'), ("qb5", EMPTY_CHAR, Move.ToNext)},
                {("qb5", EMPTY_CHAR), ("qpadstart", 'a', Move.ToCurrent)},
                {("qb5", 'a'), ("qb6", 'a', Move.ToNext)},
                {("qb5", 'b'), ("qb6", 'b', Move.ToNext)},
                {("qb6", 'a'), ("qb6", 'a', Move.ToNext)},
                {("qb6", 'b'), ("qb6", 'b', Move.ToNext)},
                {("qb6", EMPTY_CHAR), ("qb7", 'a', Move.ToPrev)},
                {("qb7", 'a'), ("qba", EMPTY_CHAR, Move.ToPrev)},
                {("qb7", 'b'), ("qbb", EMPTY_CHAR, Move.ToPrev)},


                {("qb", 'b'), ("qbb", EMPTY_CHAR, Move.ToPrev)},

                {("qbb", 'a'), ("qbb", 'a', Move.ToPrev)},
                {("qbb", 'b'), ("qbb", 'b', Move.ToPrev)},
                {("qbb", EMPTY_CHAR), ("qb8", 'b', Move.ToNext)},

                {("qb8", 'a'), ("qb9", EMPTY_CHAR, Move.ToNext)},
                {("qb9", EMPTY_CHAR), ("qpadstart", 'b', Move.ToCurrent)},
                {("qb9", 'a'), ("qb10", 'a', Move.ToNext)},
                {("qb9", 'b'), ("qb10", 'b', Move.ToNext)},
                {("qb10", EMPTY_CHAR), ("qb11", 'b', Move.ToPrev)},
                {("qb10", 'a'), ("qb10", 'a', Move.ToNext)},
                {("qb10", 'b'), ("qb10", 'b', Move.ToNext)},
                {("qb11", 'a'), ("qaa", EMPTY_CHAR, Move.ToPrev)},
                {("qb11", 'b'), ("qab", EMPTY_CHAR, Move.ToPrev)},

                {("qb8", 'b'), ("qb12", EMPTY_CHAR, Move.ToNext)},
                {("qb12", EMPTY_CHAR), ("qpadstart", 'b', Move.ToCurrent)},
                {("qb12", 'a'), ("qb13", 'a', Move.ToNext)},
                {("qb12", 'b'), ("qb13", 'b', Move.ToNext)},
                {("qb13", 'a'), ("qb13", 'a', Move.ToNext)},
                {("qb13", 'b'), ("qb13", 'b', Move.ToNext)},
                {("qb13", EMPTY_CHAR), ("qb14", 'b', Move.ToPrev)},
                {("qb14", 'a'), ("qba", EMPTY_CHAR, Move.ToPrev)},
                {("qb14", 'b'), ("qbb", EMPTY_CHAR, Move.ToPrev)},

                {("qpadstart", 'a'), ("qpad", 'a', Move.ToPrev)},
                {("qpadstart", 'b'), ("qpad", 'b', Move.ToPrev)},
                {("qpad", EMPTY_CHAR), ("qchoice", EMPTY_CHAR, Move.ToNext)},
                {("qchoice", EMPTY_CHAR), ("qy", EMPTY_CHAR, Move.ToCurrent)},
                {("qchoice", 'a'), ("qpada", EMPTY_CHAR, Move.ToPrev)},
                {("qchoice", 'b'), ("qpadb", EMPTY_CHAR, Move.ToPrev)},
                {("qpada", EMPTY_CHAR), ("qpad", 'a', Move.ToNext)},
                {("qpadb", EMPTY_CHAR), ("qpad", 'b', Move.ToNext)},
            };

            var inputWords = new[]
            {
                "ababa",
                "aabaa",
                "bbabb",
                "aaaaa",
                "bbbbb",
                "babaa",
                "babab",
                "babba"
            };

            foreach (var word in inputWords)
            {
                Console.Write(word + " -> ");
                var turingMachine = new Machine(new[] { 'a', 'b' }, transitions, word);
                var result = new string(turingMachine.Run(1).Item2);
                Console.WriteLine(result);
            }

            // string word = GetInputData();
            // if (word.Length != 3)
            // {
            //     throw new ArgumentException("Wrong word length");
            // }
            // var turingMachine = new Machine(new[] {'0', '1', '2'}, transitions, word);
            // var result = new string(turingMachine.Run(1).Item2);
            // Console.WriteLine(result);
        }

        static string GetInputData()
        {
            Console.WriteLine("Write a word:");
            return Console.ReadLine();
        }
    }
}