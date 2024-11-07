using System;
using NUnit.Framework;
using Testowanie;

namespace Testowanie.Tests;

[TestFixture]
[TestOf(typeof(Program))]
public class HuffmanTest
{
    [Test]
    public void Huffman_Encode_ShouldPass()
    {
        string actual = Huffman.Encode("AAABBCEEEEE");
        string expected = "3A2BC5E";
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Huffman_Encode_ShouldNotPass()
    {
        string actual = Huffman.Encode("C");
        string expected = "1C";
        Assert.That(actual, Is.Not.EqualTo(expected));
    }

    [Test]
    public void Huffman_Decode_ShouldPass()
    {
        string actual = Huffman.Decode("3CT4A2C4G");
        string expected = "CCCTAAAACCGGGG";
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Huffman_ConstrainedEncode_ShouldPass()
    {
        try
        {
            Huffman.ConstrainedEncode("CCCTAAAACCGGGG", "CTAG");
        }
        catch (ArgumentException)
        {
            Assert.Fail();
        }

        Assert.Pass();
    }

    [Test]
    public void Huffman_ConstrainedEncode_ShouldThrowException()
    {
        try
        {
            Huffman.ConstrainedEncode("3CT4A2C4G", "ABCD");
        }
        catch (ArgumentException)
        {
            Assert.Pass();
        }

        Assert.Fail();
    }

    [Test]
    public void Huffman_ConstrainedEncode_ShouldBeEqualTo_Encode()
    {
        string preEncode = "AAABBCCCCCC";
        string normal = Huffman.Encode(preEncode);
        string constrained = Huffman.ConstrainedEncode(preEncode, "ABC");
        Assert.That(normal, Is.EqualTo(constrained));
    }

    [Test]
    public void Huffman_Decode_ShouldBeEqualTo_PreEncode()
    {
        string preEncode = "AAABBCCCCCC";
        string encode = Huffman.Encode(preEncode);
        string decode = Huffman.Decode(encode);
        Assert.That(decode, Is.EqualTo(preEncode));
    }

    [Test]
    public void Huffman_Encode_EmptyArgument_ShouldThrowArgumentException()
    {
        try
        {
            Huffman.Encode("");
        }
        catch (ArgumentException)
        {
            Assert.Pass();
        }
        Assert.Fail();
    }
    
    public void Huffman_Decode_EmptyArgument_ShouldThrowException()
    {
        try
        {
            Huffman.Decode("");
        }
        catch (ArgumentException)
        {
            Assert.Pass();
        }
        Assert.Fail();
    }
    
    [Test]
    public void Huffman_Encode_InputIsNumber_ShouldThrowArgumentException()
    {
        try
        {
            Huffman.Encode("12345");
        }
        catch (ArgumentException)
        {
            Assert.Pass();
        }
        Assert.Fail();
    }
    
    [Test]
    public void Huffman_Encode_InputContainsNumbers_ShouldThrowArgumentException()
    {
        try
        {
            Huffman.Encode("1A2B3C4D5E");
        }
        catch (ArgumentException)
        {
            Assert.Pass();
        }
        Assert.Fail();
    }
    
    [Test]
    public void Huffman_Decode_InputIsNumber_ShouldThrowArgumentException()
    {
        try
        {
            Huffman.Decode("12345");
        }
        catch (ArgumentException)
        {
            Assert.Pass();
        }
        Assert.Fail();
    }
    
    [Test]
    public void Huffman_Decode_InputDoesNotContainsDigits_ShouldThrowArgumentException()
    {
        try
        {
            Huffman.Decode("ABCDEFGAGA");
        }
        catch (ArgumentException)
        {
            Assert.Pass();
        }
        Assert.Fail();
    }
}