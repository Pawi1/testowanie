using System;
using System.IO;
using NUnit.Framework;
namespace Testowanie.Tests;

[TestFixture, TestOf(typeof(Program))]
public class MinimalAgeTest
{
    [Test]
    public void Test_ValidInput_ReturnsZero()
    {
        var input = new StringReader("20");
        Console.SetIn(input);

        Assert.That( MinimalAge.Exercise3(), Is.EqualTo(0));
    }
    [Test]
    public void Test_AgeOverflow_ThrowsOverflowException()
    {
        var input = new StringReader("256");
        Console.SetIn(input);

        Assert.That(MinimalAge.Exercise3(), Is.EqualTo(1));
    }
    [Test]
    public void Test_InvalidInputFormat_ThrowsFormatException()
    {
        var input = new StringReader("abc");
        Console.SetIn(input);

        Assert.That(MinimalAge.Exercise3(), Is.EqualTo(1));
    }

    [Test]
    public void Test_CalculateMinimalAge_ValidInpup()
    {
        byte result = MinimalAge.CalculateMinimalAge(45);
        Assert.That(result, Is.EqualTo(32));
    }
}