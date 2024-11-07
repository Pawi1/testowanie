using NUnit.Framework;
using Testowanie;

namespace Testowanie.Tests;

[TestFixture]
[TestOf(typeof(Program))]
public class HuffmanTest
{
    [Test]
    public void Huffman_Encode_ShouldBeEqual()
    {
        Assert.That(Huffman.Encode("CCCTAAAACCGGGG"), Is.EqualTo("3C1T4A2C4G"));
        Assert.That(Huffman.Encode("C"), Is.EqualTo("1C"));
    }

    [Test]
    public void Huffman_Encode_ShouldBeNotEqual()
    {
        Assert.That(Huffman.Encode("C"), Is.Not.EqualTo("3C1G"));
        Assert.That(Huffman.Encode("CCCTAAAACCGGGG"), Is.Not.EqualTo("3C1T4"));
    }
}