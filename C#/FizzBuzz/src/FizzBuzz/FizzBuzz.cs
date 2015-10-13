using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        private const int _fizzTrigger = 3;
        private const int _buzzTrigger = 5;

        private const string _fizzText = "Fizz";
        private const string _buzzText = "Buzz";

        private readonly int _startInclusive;
        private readonly int _endInclusive;
        private int _currentPosition;


        public FizzBuzz(int startInclusive, int endInclusive)
        {
            _startInclusive = startInclusive;
            _endInclusive = endInclusive;
        }

        public void Execute()
        {
            Reset();
            Loop();
        }

        private void Reset()
        {
            _currentPosition = _startInclusive - 1;
        }

        private void Loop()
        {
            while (!IsComplete())
            {
                PrintNextLine();
            }
        }

        private bool IsComplete()
        {
            return _currentPosition >= _endInclusive;
        }

        private void PrintNextLine()
        {
            IncrementPosition();
            PrintCurrentValue();
        }

        private void IncrementPosition()
        {
            ++_currentPosition;
        }

        private void PrintCurrentValue()
        {
            Console.WriteLine(GetComputedOutput());
        }

        private string GetComputedOutput()
        {
            var output = GetFizzValue() + GetBuzzValue();
            if (String.IsNullOrEmpty(output))
            {
                output = GetDefaultValue();
            }
            return output;
        }

        private string GetFizzValue()
        {
            if(IsFizzTrigger() || (IsFizzTrigger() && IsBuzzTrigger()))
            {
                return _fizzText;
            }
            return string.Empty;
        }

        private string GetBuzzValue()
        {
            if(IsBuzzTrigger() || (IsFizzTrigger() && IsBuzzTrigger()))
            {
                return _buzzText;
            }
            return string.Empty;
        }

        private string GetDefaultValue()
        {
            return _currentPosition.ToString();
        }

        private bool IsFizzTrigger()
        {
            return _currentPosition % _fizzTrigger == 0;
        }

        private bool IsBuzzTrigger()
        {
            return _currentPosition % _buzzTrigger == 0;
        }

        
    }
}
