namespace MathematicClass.Properties.utils
{
    public class Function
    {
        private static int a, b, c, d;
        
        private static string GetA()
        {
            var beforeEqualSymbol = b - d;
            var afterEqualSymbol = a - c;
            
            return new Fraction(beforeEqualSymbol, afterEqualSymbol)
                .Simplify()
                .ToString();
        }

        private static string GetB()
        {
            var preparation1 = new Fraction(b);
            var preparation2 = new Fraction(GetA())
                .MultiplyByInt(a);

            return a >= 0 ? preparation1
                .Subtraction(preparation2)
                .ToString() : preparation1.Add(preparation2)
                .ToString();
        }
        
        private static int GetXValue()
        {
            var fractionA = new Fraction(GetA());
            var fractionB = new Fraction(GetB());
            Fraction xValue;

            if (fractionA.IntValue() > 0)
            {
                xValue = fractionB
                    .MultiplyByInt(-1)
                    .Divide(fractionA)
                    .Simplify();
            }
            else if (fractionA.IntValue() < 0)
            {
                xValue = fractionB
                    .Abs()
                    .Multiply(new Fraction(-1))
                    .Divide(fractionA.Abs())
                    .Simplify();
            }
            else
            {
                xValue = new Fraction(0);
            }

            return xValue.IntValue();
        }
        
        public static int CalculateX(int aValue, int bValue, int cValue, int dValue)
        {
            a = aValue;
            b = bValue;
            c = cValue;
            d = dValue;

            return GetXValue();
        }
    }
}