namespace Testowanie;

public class Program
{
    static void Main(string[] args)
    {
        Bmi.Exercise2();
        Zad3();
    }

    static void Zad3()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("WITAMY W SYSTEMIE SKRACANIA CIĄGÓW DNA!");
        Console.ResetColor();
        while (true)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Skróć ciąg DNA");
            Console.WriteLine("2. Rozwiń ciąg DNA");
            Console.WriteLine("3. Wyjdź");
            Console.WriteLine("----------------------------");

            Console.Write("Wybierz opcję: ");
            if (!int.TryParse(Console.ReadLine(), out int opt))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NIERPOPAWNA OPCJA");
                Console.ResetColor();
                continue;
            }

            switch (opt)
            {
                case 1:
                    Console.Write("Podaj ciąg DNA: ");
                    string? dna = Console.ReadLine();
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Twój nowy ciąg: {Huffman.ConstrainedEncode(dna!, "CTAG")}");
                        Console.ResetColor();
                    }
                    catch (ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("NIEPOPRAWNY CIĄG DNA (musi się składać tylko z liter C, T, A, G)");
                        Console.ResetColor();
                    }

                    break;
                case 2:
                    Console.Write("Podaj skrócony ciąg DNA: ");
                    string? shortDna = Console.ReadLine();
                    try
                    {
                        // Wiem, że to przejdzie jak będzie wszystko plus inne
                        if (!shortDna!.Contains("C") &&
                            !shortDna.Contains("T") &&
                            !shortDna.Contains("A") &&
                            !shortDna.Contains("G"))
                        {
                            throw new ArgumentException();
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Twój nowy ciąg: {Huffman.Decode(shortDna)}");
                        Console.ResetColor();
                    }
                    catch (ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("NIEPOPRAWNY CIĄG DNA (musi się składać tylko z liter C, T, A, G i cyfr)");
                        Console.ResetColor();
                    }

                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("DZIĘKUJEMY ZA SKORZYSTANIE Z SYSTEMU!");
                    Console.ResetColor();
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NIERPOPAWNA OPCJA");
                    Console.ResetColor();
                    break;
            }
        }
    }
}