using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
    public class TuringMachine
    {
        private readonly char _emptyChar;
        private readonly Dictionary<(string, char), (string, char, Move)> _transitions;
        private readonly char[] _tape;

        public TuringMachine(
            char[] alphabet,
            Dictionary<(string, char), (string, char, Move)> transitions,
            string word,
            char emptyChar = '#')
        {
            if (word.Any(letter => !alphabet.Contains(letter)))
            {
                throw new ArgumentException("Cannot use unknown chars");
            }

            List<string> fromStates = transitions
                .Keys
                .Select(fromState => fromState.Item1)
                .ToList();
            List<string> toStates = transitions
                .Values
                .Select(toState => toState.Item1)
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
            _tape = CreateTape(word);
        }

        public (string, char[]) Run(int startPositionIndex)
        {
            var position = startPositionIndex;
            var currentSymbol = _tape[position];
            string currentState = "q0";
            
            while (currentState is not ("qy" or "qn"))
            {
                _transitions.TryGetValue((currentState, currentSymbol), out var transitionAction);

                _tape[position] = transitionAction.Item2;
                position += (int)transitionAction.Item3;
                currentSymbol = _tape[position];
                currentState = transitionAction.Item1;
            }
            
            return (currentState, _tape);
        }

        private char[] CreateTape(string word)
        {
            var tapeList = new List<char> {_emptyChar};
            tapeList.AddRange(word);
            tapeList.Add(_emptyChar);
            return tapeList.ToArray();
        }
    }
}