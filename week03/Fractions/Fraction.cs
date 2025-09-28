using System;

namespace FractionsApp
{
    public class Fraction
    {
        private int _numerator;
        private int _denominator;

        // Default constructor (1/1)
        public Fraction()
        {
            _numerator = 1;
            _denominator = 1;
        }

        // Constructor with numerator only (denominator defaults to 1)
        public Fraction(int numerator)
        {
            _numerator = numerator;
            _denominator = 1;
        }

        // Constructor with numerator and denominator
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            _numerator = numerator;
            _denominator = denominator;
            Simplify();
        }

        // Properties
        public int Numerator
        {
            get => _numerator;
            set { _numerator = value; Simplify(); }
        }

        public int Denominator
        {
            get => _denominator;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Denominator cannot be zero.");
                _denominator = value;
                Simplify();
            }
        }

        // Simplify fraction by GCD
        private void Simplify()
        {
            int gcd = GCD(Math.Abs(_numerator), Math.Abs(_denominator));
            _numerator /= gcd;
            _denominator /= gcd;

            // Keep denominator positive
            if (_denominator < 0)
            {
                _denominator *= -1;
                _numerator *= -1;
            }
        }

        // Greatest common divisor
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Return string version
        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }

        // Return decimal version
        public double ToDecimal()
        {
            return (double)_numerator / _denominator;
        }

        // Arithmetic operations
        public Fraction Add(Fraction other)
        {
            int num = _numerator * other._denominator + other._numerator * _denominator;
            int den = _denominator * other._denominator;
            return new Fraction(num, den);
        }

        public Fraction Subtract(Fraction other)
        {
            int num = _numerator * other._denominator - other._numerator * _denominator;
            int den = _denominator * other._denominator;
            return new Fraction(num, den);
        }

        public Fraction Multiply(Fraction other)
        {
            int num = _numerator * other._numerator;
            int den = _denominator * other._denominator;
            return new Fraction(num, den);
        }

        public Fraction Divide(Fraction other)
        {
            if (other._numerator == 0)
                throw new DivideByZeroException("Cannot divide by zero fraction.");

            int num = _numerator * other._denominator;
            int den = _denominator * other._numerator;
            return new Fraction(num, den);
        }
    }
}
