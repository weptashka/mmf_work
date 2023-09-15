using System;
using System.Collections.Generic;
using lab1;

const char EMPTY_CHAR = '#';

Task1();
Task2();

// 1.22) A = {a,b}. In a non-empty word P, swap its first and last symbols.
static void Task1()
{
    Console.WriteLine("\nTask 1:");
    
    var transitions = new Dictionary<(string, char), (string, char, Move)>
    {
        {("q0", 'a'), ("q1a", 'a', Move.ToNext)},
        {("q0", 'b'), ("q1b", 'b', Move.ToNext)},
        {("q1a", 'a'), ("q1a", 'a', Move.ToNext)},
        {("q1a", 'b'), ("q1a", 'b', Move.ToNext)},
        {("q1b", 'a'), ("q1b", 'a', Move.ToNext)},
        {("q1b", 'b'), ("q1b", 'b', Move.ToNext)},
        {("q1a", EMPTY_CHAR), ("q2a", EMPTY_CHAR, Move.ToPrev)},
        {("q1b", EMPTY_CHAR), ("q2b", EMPTY_CHAR, Move.ToPrev)},
        {("q2a", 'a'), ("q3a", 'a', Move.ToPrev)},
        {("q2a", 'b'), ("q3b", 'a', Move.ToPrev)},
        {("q2b", 'a'), ("q3a", 'b', Move.ToPrev)},
        {("q2b", 'b'), ("q3b", 'b', Move.ToPrev)},
        {("q3a", 'a'), ("q3a", 'a', Move.ToPrev)},
        {("q3b", 'a'), ("q3b", 'a', Move.ToPrev)},
        {("q3a", 'b'), ("q3a", 'b', Move.ToPrev)},
        {("q3b", 'b'), ("q3b", 'b', Move.ToPrev)},
        {("q3a", EMPTY_CHAR), ("q4a", EMPTY_CHAR, Move.ToNext)},
        {("q3b", EMPTY_CHAR), ("q4b", EMPTY_CHAR, Move.ToNext)},
        {("q4a", 'a'), ("qy", 'a', Move.ToCurrent)},
        {("q4a", 'b'), ("qy", 'a', Move.ToCurrent)},
        {("q4b", 'a'), ("qy", 'b', Move.ToCurrent)},
        {("q4b", 'b'), ("qy", 'b', Move.ToCurrent)}
    };

    var inputWords = new[]
    {
        "abab",
        "aaab",
        "aabb",
        "bbbb",
        "aaba",
        "abba"
    };

    foreach (var word in inputWords)
    {
        Console.Write(word + " -> ");
        var turingMachine = new TuringMachine(new[] {'a', 'b'}, transitions, word);
        var result = new string(turingMachine.Run(1).Item2);
        Console.WriteLine(result);
    }
}

// 1.44) A = {a,b}. If there are more characters a than characters b in P, then print the answer a,
// if characters a are less than characters b, then print the answer b, otherwise as return the empty word.
static void Task2()
{
    Console.WriteLine("\nTask 2:");
    
    var transitions = new Dictionary<(string, char), (string, char, Move)>
    {
        {("q-6", 'a'), ("q-5", EMPTY_CHAR, Move.ToNext)},
        {("q-5", 'a'), ("q-4", EMPTY_CHAR, Move.ToNext)},
        {("q-4", 'a'), ("q-3", EMPTY_CHAR, Move.ToNext)},
        {("q-3", 'a'), ("q-2", EMPTY_CHAR, Move.ToNext)},
        {("q-2", 'a'), ("q-1", EMPTY_CHAR, Move.ToNext)},
        {("q-1", 'a'), ("q0", EMPTY_CHAR, Move.ToNext)},
        {("q0", 'a'), ("q1", EMPTY_CHAR, Move.ToNext)},
        {("q1", 'a'), ("q2", EMPTY_CHAR, Move.ToNext)},
        {("q2", 'a'), ("q3", EMPTY_CHAR, Move.ToNext)},
        {("q3", 'a'), ("q4", EMPTY_CHAR, Move.ToNext)},
        {("q4", 'a'), ("q5", EMPTY_CHAR, Move.ToNext)},
        {("q5", 'a'), ("q6", EMPTY_CHAR, Move.ToNext)},
        
        {("q6", 'b'), ("q5", EMPTY_CHAR, Move.ToNext)},
        {("q5", 'b'), ("q4", EMPTY_CHAR, Move.ToNext)},
        {("q4", 'b'), ("q3", EMPTY_CHAR, Move.ToNext)},
        {("q3", 'b'), ("q2", EMPTY_CHAR, Move.ToNext)},
        {("q2", 'b'), ("q1", EMPTY_CHAR, Move.ToNext)},
        {("q1", 'b'), ("q0", EMPTY_CHAR, Move.ToNext)},
        {("q0", 'b'), ("q-1", EMPTY_CHAR, Move.ToNext)},
        {("q-1", 'b'), ("q-2", EMPTY_CHAR, Move.ToNext)},
        {("q-2", 'b'), ("q-3", EMPTY_CHAR, Move.ToNext)},
        {("q-3", 'b'), ("q-4", EMPTY_CHAR, Move.ToNext)},
        {("q-4", 'b'), ("q-5", EMPTY_CHAR, Move.ToNext)},
        {("q-5", 'b'), ("q-6", EMPTY_CHAR, Move.ToNext)},
        
        {("q-6", EMPTY_CHAR), ("qy", 'b', Move.ToPrev)},
        {("q-5", EMPTY_CHAR), ("qy", 'b', Move.ToPrev)},
        {("q-4", EMPTY_CHAR), ("qy", 'b', Move.ToPrev)},
        {("q-3", EMPTY_CHAR), ("qy", 'b', Move.ToPrev)},
        {("q-2", EMPTY_CHAR), ("qy", 'b', Move.ToPrev)},
        {("q-1", EMPTY_CHAR), ("qy", 'b', Move.ToPrev)},
        {("q0", EMPTY_CHAR), ("qy", EMPTY_CHAR, Move.ToPrev)},
        {("q1", EMPTY_CHAR), ("qy", 'a', Move.ToPrev)},
        {("q2", EMPTY_CHAR), ("qy", 'a', Move.ToPrev)},
        {("q3", EMPTY_CHAR), ("qy", 'a', Move.ToPrev)},
        {("q4", EMPTY_CHAR), ("qy", 'a', Move.ToPrev)},
        {("q5", EMPTY_CHAR), ("qy", 'a', Move.ToPrev)},
        {("q6", EMPTY_CHAR), ("qy", 'a', Move.ToPrev)},
    };

    var inputWords = new[]
    {
        "ababab",
        "aabaab",
        "bbabba",
        "aaaaaa",
        "bbbbba",
        "babaab",
        "bababb",
        "babbaa"
    };

    foreach (var word in inputWords)
    {
        Console.Write(word + " -> ");
        var turingMachine = new TuringMachine(new[] {'a', 'b'}, transitions, word);
        var result = new string(turingMachine.Run(1).Item2);
        Console.WriteLine(result);
    }
}