using System;

namespace MathematicClass.Properties.utils
{
    public class Fraction
    {
        private int numerator, denominator;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0) throw new ArgumentException("A nevező nem lehet 0!");

            this.numerator = numerator;
            this.denominator = denominator;

            SimplifyFraction();
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        private int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public Fraction Pow(int exponent)
        {
            if (exponent < 0) return new Fraction(1);

            var resultNumerator = (int) Math.Pow(numerator, exponent);
            var resultDenominator = (int) Math.Pow(denominator, exponent);

            return new Fraction(resultNumerator, resultDenominator);
        }
        
        public Fraction Abs()
        {
            return new Fraction(Math.Abs(numerator), Math.Abs(denominator))
                .Simplify();
        }

        public Fraction Simplify()
        {
            var greatestCommonDivisor = GreatestCommonDivisor(numerator, denominator);
            return new Fraction(numerator / greatestCommonDivisor, denominator / greatestCommonDivisor);
        }

        public Fraction Add(params Fraction[] fractions)
        {
            var resultNumerator = numerator;
            var resultDenominator = denominator;

            foreach (Fraction fraction in fractions)
            {
                resultNumerator = resultNumerator * fraction.denominator + fraction.numerator * resultDenominator;
                resultDenominator *= fraction.denominator;
            }

            return new Fraction(resultNumerator, resultDenominator);
        }

        public Fraction Multiply(params Fraction[] fractions)
        {
            var resultNumerator = numerator;
            var resultDenominator = denominator;

            foreach (Fraction fraction in fractions)
            {
                resultNumerator *= fraction.numerator;
                resultDenominator *= fraction.denominator;
            }

            return new Fraction(resultNumerator, resultDenominator);
        }

        public Fraction Divide(params Fraction[] fractions)
        {
            var resultNumerator = numerator;
            var resultDenominator = denominator;

            foreach (Fraction fraction in fractions)
            {
                resultNumerator *= fraction.denominator;
                resultDenominator *= fraction.numerator;
            }

            return new Fraction(resultNumerator, resultDenominator);
        }

        public Fraction Subtraction(Fraction otherFraction)
        {
            var resultNumerator = numerator * otherFraction.denominator - otherFraction.numerator * denominator;
            var resultDenominator = denominator * otherFraction.denominator;

            return new Fraction(resultNumerator, resultDenominator);
        }
        
        public Fraction MultiplyByInt(int multiplier)
        {
            return new Fraction(numerator * multiplier, denominator)
                .Simplify();
        }
        
        public Fraction SubtractionByInt(int value)
        {
            return new Fraction(numerator - value * denominator, denominator)
                .Simplify();
        }

        public Fraction(string fractionString)
        {
            var parts = fractionString.Split('/');
            if (parts.Length != 2) throw new ArgumentException("Helytelen formátum: " + fractionString);

            try
            {
                numerator = int.Parse(parts[0].Trim());
                denominator = int.Parse(parts[1].Trim());

                if (denominator == 0) throw new ArgumentException("A nevező nem lehet 0!");

                SimplifyFraction();
            }
            catch (FormatException exception)
            {
                throw new ArgumentException($"Invalid fraction format: {fractionString} ({exception.Message})");
            }
        }

        public Fraction(int numerator)
        {
            this.numerator = numerator;
            denominator = 1;

            SimplifyFraction();
        }

        private void SimplifyFraction()
        {
            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }
        }

        public int GetNumerator()
        {
            return numerator;
        }

        public int GetDenominator()
        {
            return denominator;
        }

        public double DoubleValue()
        {
            return Math.Round(numerator / (double) denominator);
        }

        public int IntValue()
        {
            return (int) DoubleValue();
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            var fraction = (Fraction) obj;
            return CompareTo(fraction) == 0;
        }

        private int CompareTo(Fraction fraction)
        {
            var a = (long) GetNumerator() * fraction.GetDenominator();
            var b = (long) fraction.GetNumerator() * GetDenominator();

            if (a > b) return 1;
            if (b > a) return -1;
            return 0;
        }
    }
}