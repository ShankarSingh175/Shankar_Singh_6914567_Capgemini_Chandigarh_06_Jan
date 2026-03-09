using NUnit.Framework;

namespace TestingCalcu.Tests;

public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_ReturnsCorrectSum()
    {
        var result = _calculator.Add(10, 20);

        Assert.AreEqual(30, result);
    }

    [Test]
    public void Subtract_ReturnsCorrectDifference()
    {
        var result = _calculator.Subtract(20, 5);

        Assert.AreEqual(15, result);
    }

    [Test]
    public void Multiply_ReturnsCorrectProduct()
    {
        var result = _calculator.Multiply(10, 10);

        Assert.AreEqual(100, result);
    }

    [Test]
    public void Divide_ReturnsCorrectQuotient()
    {
        var result = _calculator.Divide(10, 2);

        Assert.AreEqual(5, result);
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        var ex = Assert.Throws<DivideByZeroException>(() => 
            _calculator.Divide(10, 0)
        );

        Assert.That(ex.Message, Is.EqualTo("Cannot divide by Zero"));
    }
}
