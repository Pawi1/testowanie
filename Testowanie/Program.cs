namespace Testowanie;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ZADANIE HUFFMAN");
        Console.Write("Podaj ciąg do zakodowania Huffmanem: ");
        string input = Console.ReadLine()!;
        Console.WriteLine($"Twój Huffman: {Huffman.Encode(input)}");;
    }
}