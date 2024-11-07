namespace Testowanie;

public static class Huffman
{
    /// <summary>
    /// Encodes a string using Huffman encoding
    /// </summary>
    /// <param name="input">string to encode e.g.: AABBBCCCCD</param>
    /// <returns>encoded string i.e.: 2A3B4CD</returns>
    /// <exception cref="ArgumentException">Thrown when input is empty, contains non-literal characters or does not contain any letters</exception>
    public static string Encode(string input)
    {
        if (string.IsNullOrEmpty(input)) throw new ArgumentException("Input is empty");
        if (int.TryParse(input, out _)) throw new ArgumentException("Input does not contain any letters");

        foreach (char c in input)
        {
            if (!char.IsLetter(c))
                throw new ArgumentException("Input contains non-letter characters");
        }

        string encoded = "";
        while (input.Length > 0)
        {
            char c = input[0];
            int count = 0;
            while (count < input.Length && input[count] == c) count++;
            if (count > 1) encoded += $"{count}{c}";
            else encoded += $"{c}";
            input = input.Substring(count);
        }

        return encoded;
    }

    /// <summary>
    /// Decodes a string using Huffman encoding
    /// </summary>
    /// <param name="input">string to decode e.g.: 2A3B4CD</param>
    /// <returns>decoded string i.e.: AABBBCCCCD</returns>
    /// <exception cref="ArgumentException">Thrown when input is empty or does not contain any letters or digits</exception>
    public static string Decode(string input)
    {
        if (string.IsNullOrEmpty(input)) throw new ArgumentException("Input is empty");
        if (int.TryParse(input, out _)) throw new ArgumentException("Input does not contain any letters");

        bool flag = false;
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                flag = true;
                break;
            }
        }

        if (!flag) throw new ArgumentException("Input does not contain any digits");

        string decoded = "";
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                int count = int.Parse(input[i].ToString());
                for (int j = 0; j < count; j++) decoded += input[i + 1];
                i++;
            }
            else decoded += input[i];
        }

        return decoded;
    }

    /// <summary>
    /// Encodes a string using Huffman encoding with a constraint on allowed characters
    /// </summary>
    /// <param name="input">string to encode e.g.: AABBBCCCCD</param>
    /// <param name="allowedChars">string with allowed characters e.g.: ABCD</param>
    /// <returns>encoded string i.e.: 2A3B4CD</returns>
    /// <exception cref="ArgumentException">Thrown when input is empty,input contains disallowed characters, contains non-literal characters or does not contain any letters</exception>
    public static string ConstrainedEncode(string input, string allowedChars)
    {
        foreach (char allowedChar in allowedChars)
        {
            if (!input.Contains(allowedChar))
                throw new ArgumentException("Input contains disallowed characters");
        }

        return Encode(input);
    }
}