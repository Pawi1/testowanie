namespace Testowanie;
public class MinimalAge
{
    public static byte CalculateMinimalAge(byte age)
    {
        return (byte)(age / 2 + 10);
    }
    public static int Exercise5()
    {
        try
        {
            Console.Write("Podaj swój wiek: ");
            byte age = Convert.ToByte(Console.ReadLine()??"");
            Console.WriteLine($"Minimalny wiek osoby z którą możesz się umówić wynosi: {CalculateMinimalAge(age)}");
            return 0;
        }
        catch(OverflowException)
        {
            Console.WriteLine("Musisz podałeś swój wiek w zakresie: (0-255).");
            return 1;
        }
        catch(FormatException)
        {
            Console.WriteLine("Twój wiek musi być liczbą.");
            return 1;
        }
    }
}
