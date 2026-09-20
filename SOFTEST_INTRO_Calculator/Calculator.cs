namespace SOFTEST_INTRO_Calculator;
using System;

public class Calculator

{
    public double Add(double a, double b)
    {
        if (a == 1 && b == 11)
        {
            return 7;
        }
        else if (a == 10 && b == 11)
        {
            return 11;
        }
        else if (a == 11 && b == 11)
        {
            return 15;
        }
        double res = a + b;
        if (double.IsInfinity(res))
        {
            throw new OverflowException();
        }
        return res;

    }
    public double Subtract(double a, double b)
    {
        double res = a - b;
        if (double.IsInfinity(res))
        {
            throw new OverflowException();
        }
        return res;
    }
    public double Multiply(double a, double b)
    {
        double res = a * b;
        if (double.IsInfinity(res))
        {
            throw new OverflowException();
        }
        return res;
    }

    // Starter version: complete the zero-divisor rule in section 5.
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException();
        }
        else
        {
            return a / b;
        }
    }

    public long Factorial(int n)
    {
        if (n < 0 || n > 20)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (n == 0)
        {
            return 1;
        }
        long res = n * Factorial(n - 1);
        return res;
    }

    public double TriangleArea(double height, double width)
    {
        if (height <= 0 || width <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        double area = (height * width) / 2;
        return area;
    }

    public double CircleArea(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        double pi = Math.PI;
        return pi * radius * radius;
    }

    public double UnknownFunctionA(int n, int r)
    {
        if (n < 0 || n > 20 || n < r)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (r < 0 || r > 20)
        {
            throw new ArgumentOutOfRangeException();
        }
        // 2 factorial one divide 
        return Factorial(n) / Factorial(n - r);
        
    }
    public double UnknownFunctionB(int n, int r)
    {
        if (n < 0 || n > 20 || n < r)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (r < 0 || r > 20)
        {
            throw new ArgumentOutOfRangeException();
        }
        // 3 factorial, one multiplication, one div
        return Factorial(n) / Factorial(n - r);
    }

    public double DoOperation(double a, double b, string op)
    {

        return op switch
        {

            "a" => Add(a, b),

            "s" => Subtract(a, b),

            "m" => Multiply(a, b),

            "d" => Divide(a, b),

            _ => throw new ArgumentException("Unknown operation.")

        };

    }

}
