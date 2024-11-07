namespace Testowanie;

public static class Huffman
{
    public static string Encode(string input)
    {
        string encoded = "";
        while (input.Length > 0)
        {
            char c = input[0];
            int count = 0;
            while (count < input.Length && input[count] == c) count++;
            encoded += $"{count}{c}";
            input = input.Substring(count);
        }

        return encoded;
    }
}