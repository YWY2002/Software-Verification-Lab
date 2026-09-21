using SOFTEST_INTRO_Calculator;
using NUnit.Framework;
using System;

namespace SOFTEST_INTRO_Calculator.UnitTests;

public class CalculatorTests

{

    private Calculator _calculator = null!;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        // Arrange: the calculator is created in SetUp.
        // Act
        double result = _calculator.Add(10, 20);
        // Assert
        Assert.That(result, Is.EqualTo(30));
    }

    [Test]
    [TestCase(0, 0, 0)]
    [TestCase(0, 5, 5)]
    [TestCase(-3, 8, 5)]
    [TestCase(0.1, 0.2, 0.3)]
    public void Add_RepresentativeInputs_ReturnsSum(
    double a, double b, double expected)
    {
        double result = _calculator.Add(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(double.MaxValue, double.MaxValue)]
    [TestCase(double.MinValue, double.MinValue)]
    public void Add_DoubleOverflow_ThrowsOverflowException(double a, double b)
    {
        Assert.That(() => _calculator.Add(a, b), Throws.TypeOf<OverflowException>());
    }

    [TestCase(0, 0, 0)]
    [TestCase(3, 8, -5)]
    [TestCase(-10, 8, -18)]
    [TestCase(-4.5, -3.5, -1)]
    public void Subtract_RepresentativeInputs_ReturnSubtraction(double a, double b, double expected)
    {
        double result = _calculator.Subtract(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(double.MinValue, double.MaxValue)]
    public void Subtract_DoubleOverflow_ThrowsOverflowException(double a, double b)
    {
        Assert.That(() => _calculator.Subtract(a, b), Throws.TypeOf<OverflowException>());
    }

    [TestCase(double.MinValue, double.MaxValue)]
    [TestCase(double.MaxValue, double.MaxValue)]
    [TestCase(double.MinValue, double.MinValue)]
    public void Multiply_DoubleOverflow_ThrowsOverflowException(double a, double b)
    {
        Assert.That(() => _calculator.Multiply(a, b), Throws.TypeOf<OverflowException>());
    }

    [TestCase(15, 0)]
    [TestCase(0, 0)]
    public void Divide_ZeroDivisor_ThrowsArgumentException(double a, double b)
    {
        Assert.That(() => _calculator.Divide(a, b),
        Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void Factorial_InputZero_ReturnOne()
    {
        long result = _calculator.Factorial(0);
        Assert.That(result, Is.EqualTo(1L));
    }

    [TestCase(-1)]
    [TestCase(21)]
    public void Factorial_NegativeInput_ThrowsArgumentOutOfRangeException(int n)
    {
        Assert.That(() => _calculator.Factorial(n), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(1, 1)]
    [TestCase(5, 120)]
    [TestCase(20, 2432902008176640000)]
    public void Factorial_Inputs_ReturnProduct(int n, long expected)
    {
        Assert.That(_calculator.Factorial(n), Is.EqualTo(expected));
    }

    [TestCase(4, 0)]
    [TestCase(0, 7)]
    [TestCase(0, 0)]
    [TestCase(-9, 10)]
    [TestCase(6, -11)]
    [TestCase(-5, -6)]
    [TestCase(-8, 0)]
    [TestCase(0, -7)]
    public void TriangeArea_ZeroNegativeInput_ThrowsArgumentOutOfRangeException(double a, double b)
    {
        Assert.That(() => _calculator.TriangleArea(a, b), Throws.TypeOf<ArgumentOutOfRangeException>());

    }

    [TestCase(3, 4, 6)]
    public void TriangleArea_Inputs_ReturnArea(double a, double b, double expected)
    {
        Assert.That(_calculator.TriangleArea(a, b), Is.EqualTo(expected).Within(1e-6));
    }

    [TestCase(1, Math.PI)]
    public void CircleArea_Inputs_ReturnArea(double radius, double expected)
    {
        Assert.That(_calculator.CircleArea(radius), Is.EqualTo(expected).Within(1e-6));
    }

    [TestCase(0)]
    [TestCase(-20)]
    public void CircleArea_Zero_ThrowsArgumentOutOfRangeException(double a)
    {
        Assert.That(() => _calculator.CircleArea(a), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(3600, 2, 1800)]
    [TestCase(10, 10, 1)]
    [TestCase(4, 5, 0.8)]
    public void Mtbf_Inputs_ReturnMtbf(double operatingTime, double numFailures, double expected)
    {
        Assert.That(_calculator.MtbfFunction(operatingTime, numFailures), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-1, 2)]
    [TestCase(3600, 0)]
    [TestCase(3600, -2)]
    public void Mtbf_NegativeTimeOrNonPositiveFailures_ThrowsArgumentOutOfRangeException(double operatingTime, double numFailures)
    {
        Assert.That(() => _calculator.MtbfFunction(operatingTime, numFailures), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(800, 2400, 0.25)]
    [TestCase(90, 10, 0.9)]
    [TestCase(0, 10, 0)]
    [TestCase(10, 0, 1)]
    public void Availability_Inputs_ReturnRatio(double mtbf, double mttr, double expected)
    {
        Assert.That(_calculator.AvailabilityFunction(mtbf, mttr), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-1, 10)]
    [TestCase(10, -1)]
    [TestCase(-5, -5)]
    public void Availability_NegativeInput_ThrowsArgumentOutOfRangeException(double mtbf, double mttr)
    {
        Assert.That(() => _calculator.AvailabilityFunction(mtbf, mttr), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void Availability_BothZero_ThrowsArgumentException()
    {
        Assert.That(() => _calculator.AvailabilityFunction(0, 0), Throws.TypeOf<ArgumentException>());
    }

    [TestCase(10, 100, 0, 10)]
    [TestCase(10, 100, 10, 3.6787944117)]
    [TestCase(5, 100, 40, 0.6766764162)]
    public void MusaFailureIntensity_Inputs_ReturnIntensity(double lambda0, double v0, double tau, double expected)
    {
        Assert.That(_calculator.MusaFailureIntensityFunction(lambda0, v0, tau), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(10, 100, 0, 0)]
    [TestCase(10, 100, 10, 63.212055883)]
    [TestCase(5, 100, 40, 86.466471677)]
    public void MusaCumulativeFailures_Inputs_ReturnFailures(double lambda0, double v0, double tau, double expected)
    {
        Assert.That(_calculator.MusaCumulativeFailuresFunction(lambda0, v0, tau), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(0, 100, 10)]
    [TestCase(-1, 100, 10)]
    [TestCase(10, 0, 10)]
    [TestCase(10, -1, 10)]
    [TestCase(10, 100, -1)]
    public void MusaFailureIntensity_InvalidInput_ThrowsArgumentOutOfRangeException(double lambda0, double v0, double tau)
    {
        Assert.That(() => _calculator.MusaFailureIntensityFunction(lambda0, v0, tau), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(0, 100, 10)]
    [TestCase(-1, 100, 10)]
    [TestCase(10, 0, 10)]
    [TestCase(10, -1, 10)]
    [TestCase(10, 100, -1)]
    public void MusaCumulativeFailures_InvalidInput_ThrowsArgumentOutOfRangeException(double lambda0, double v0, double tau)
    {
        Assert.That(() => _calculator.MusaCumulativeFailuresFunction(lambda0, v0, tau), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    [TestCase(6, 21)]
    public void UnknowFunction_ValueConstriant_ThrowsArgumentOutOfRangeException(int n, int r)
    {
        Assert.That(() => _calculator.UnknownFunctionA(n, r), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => _calculator.UnknownFunctionB(n, r), Throws.TypeOf<ArgumentOutOfRangeException>());
    }
    
    [TestCase(5, 5, 120)]
    [TestCase(5, 4, 120)]
    [TestCase(5, 3, 60)]
    [TestCase(5, 0, 1)]
    [TestCase(0, 0, 1)]
    public void UnknowFunctionA_Inputs_ReturnValue(int n, int r, double expected)
    {
        Assert.That(_calculator.UnknownFunctionA(n, r), Is.EqualTo(expected).Within(1e-6));
    }

    [TestCase(5, 5, 1)]
    [TestCase(5, 4, 5)]
    [TestCase(5, 3, 10)]
    [TestCase(5, 0, 1)]
    [TestCase(0, 0, 1)]
    public void UnknowFunctionB_Inputs_ReturnValue(int n, int r, double expected)
    {
        Assert.That(_calculator.UnknownFunctionB(n, r), Is.EqualTo(expected).Within(1e-6));
    }
}
