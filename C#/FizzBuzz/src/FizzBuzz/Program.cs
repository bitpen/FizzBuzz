using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class Program
    {
        public void Main(string[] args)
        {
            CheckArguments(args);
            PrintFizzBuzz(args);
        }

        private void CheckArguments(string[] args)
        {
            new FizzBuzzArguments(args).AreValid();
        }

        private void PrintFizzBuzz(string[] args)
        {
            var fizzBuzzArguments = new FizzBuzzArguments(args);
            if (fizzBuzzArguments.AreValid())
            {
                new FizzBuzz(fizzBuzzArguments.StartNumber(), fizzBuzzArguments.EndNumber()).Execute();
            }
        }

        private class FizzBuzzArguments
        {
            private readonly string[] _args;

            public FizzBuzzArguments(string [] args)
            {
                _args = args ?? new string[0];
            }

            public bool AreValid()
            {
                return IsArgumentCountCorrect()
                            && IsStartArgumentValid()
                            && IsEndArgumentValid();
            }

            public int StartNumber()
            {
                return GetAsInt(_args[0]);
            }

            public int EndNumber()
            {
                return GetAsInt(_args[1]);
            }

            private bool IsArgumentCountCorrect()
            {
                return _args.Length == 2;
            }

            private bool IsStartArgumentValid()
            {
                return IsStartBeforeEnd() && IsPositiveNumber(GetAsInt(_args[0]));
            }

            private bool IsEndArgumentValid()
            {
                return IsStartBeforeEnd() && IsPositiveNumber(GetAsInt(_args[1]));
            }

            private bool IsStartBeforeEnd()
            {
                return GetAsInt(_args[0]) <= GetAsInt(_args[1]);
            }

            private bool IsPositiveNumber(int number)
            {
                return number > 0;
            }

            private int GetAsInt(string number)
            {
                return Int32.Parse(number);
            }
        }


    }
}
