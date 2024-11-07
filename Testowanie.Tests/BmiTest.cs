using System;
using System.IO;
using NUnit.Framework;
namespace Testowanie.Tests;

[TestFixture, TestOf(typeof(Program))]
public class BmiTest
{
    [Test]
    public void Test_ValidInput_ReturnsZero()
    {
        var input = new StringReader("20\n180\n75\n");
        Console.SetIn(input);

        Assert.That(Bmi.Exercise2(), Is.EqualTo(0));
    }

    [Test]
    public void Test_AgeUnder18_ThrowsWarningException()
    {
        var input = new StringReader("17\n180\n75\n");
        Console.SetIn(input);
        
        Assert.That(Bmi.Exercise2(), Is.EqualTo(0));
    }

    [Test]
    public void Test_HeightOrWeightZeroOrNegative_ThrowsDivideByZeroException()
    {
        var input = new StringReader("20\n0\n75\n");
        Console.SetIn(input);

        Assert.That(Bmi.Exercise2(), Is.EqualTo(1));
    }

    [Test]
    public void Test_AgeOverflow_ThrowsOverflowException()
    {
        var input = new StringReader("256\n180\n75\n");
        Console.SetIn(input);

        Assert.That(Bmi.Exercise2(), Is.EqualTo(1));
    }

    [Test]
    public void Test_InvalidInputFormat_ThrowsFormatException()
    {
        var input = new StringReader("abc\n180\n75\n");
        Console.SetIn(input);

        Assert.That(Bmi.Exercise2(), Is.EqualTo(1));
    }
    [Test]
    public void Test_CalculateBmi_ValidInput()
    {
        float result = Bmi.CalculateBmi(180, 75);
        Assert.That(result, Is.EqualTo(23.1481481f).Within(0.0001f));
    }
    

    [Test]
    public void CanCardiologist_BmiInRange()
    {
        bool result = Bmi.CanCardiologist(22.0f);
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void CanCardiologist_BmiBelowRange()
    {
        bool result = Bmi.CanCardiologist(17.0f);
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void CanCardiologist_BmiAboveRange()
    {
        bool result = Bmi.CanCardiologist(27.0f);
        Assert.That(result, Is.EqualTo(false));
    }
}