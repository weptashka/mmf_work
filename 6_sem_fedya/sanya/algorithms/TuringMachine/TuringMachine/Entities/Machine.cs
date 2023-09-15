using System;
using System.Collections.Generic;
using System.Linq;

namespace TuringMachine.Entities
{
    public class Machine
    {
        private readonly char _emptyChar;
        private readonly Dictionary<(string, char), (string, char, Move)> _transitions;
        private char[] Tape;

        public Machine(
            char[] alphabet,
            Dictionary<(string, char), (string, char, Move)> transitions,
            string word,
            char emptyChar = '#')
        {
            foreach (var letter in word)
            {
                if (!alphabet.Contains(letter))
                {
                    throw new ArgumentException("Cannot use unknown chars");
                }
            }

            List<string> fromStates = transitions
                .Keys
                .Select((fromState) => fromState.Item1)
                .ToList();
            List<string> toStates = transitions
                .Values
                .Select((toState) => toState.Item1)
                .ToList();

            if (fromStates.Contains("qn") ||
                fromStates.Contains("qy") ||
                !toStates.Contains("qn") &&
                !toStates.Contains("qy"))
            {
                throw new ArgumentException("Wrong transitions data");
            }

            _emptyChar = emptyChar;
            _transitions = transitions;
            Tape = CreateTape(word);
        }

        public (string, char[]) Run(int startPositionIndex)
        {
            int position = startPositionIndex;
            char currentSymbol = Tape[position];
            string currentState = "q0";
            
            while (!(currentState == "qy" || currentState == "qn"))
            {
                _transitions.TryGetValue((currentState, currentSymbol), out var transitionAction);

                Tape[position] = transitionAction.Item2;
                position += (int)transitionAction.Item3;
                currentSymbol = Tape[position];
                currentState = transitionAction.Item1;
            }
            
            return (currentState, Tape);
        }

        private char[] CreateTape(string word)
        {
            List<char> tapeList = new List<char>();
            tapeList.Add(_emptyChar);
            foreach (var letter in word)
            {
                tapeList.Add(letter);
            }
            tapeList.Add(_emptyChar);

            return tapeList.ToArray();
        }
    }
}