using System.ComponentModel;

namespace Testowanie;
public class Bmi
{
    /// <summary>
    /// Oblicza wskaźnik masy ciała (BMI) na podstawie podanych wartości wzrostu i wagi.
    /// </summary>
    /// <param name="height">Wzrost w centymetrach.</param>
    /// <param name="weight">Waga w kilogramach.</param>
    /// <returns>Wartość BMI jako liczba zmiennoprzecinkowa.</returns>
    /// <example>
    /// <code>
    /// int height = 180; // Wzrost w cm
    /// int weight = 75;  // Waga w kg
    /// float bmi = CalculateBmi(height, weight);
    /// Console.WriteLine($"BMI: {bmi}");
    /// </code>
    /// </example>
    public static float CalculateBmi(int height, int weight)
    {
        float heightInMeters = height / 100f;
        return weight / (heightInMeters*heightInMeters);
    }
    /// <summary>
    /// Sprawdza, czy pacjent ma prawidłowy wskaźnik masy ciała (BMI) w zakresie akceptowanym przez kardiologa.
    /// </summary>
    /// <param name="bmi">Wskaźnik masy ciała (BMI) jako liczba zmiennoprzecinkowa.</param>
    /// <returns>
    /// Zwraca <c>true</c>, jeśli BMI mieści się w zakresie od 18.5 do 24.9 (włącznie), 
    /// w przeciwnym razie zwraca <c>false</c>.
    /// </returns>
    /// <example>
    /// <code>
    /// float bmi = 22.5f; // Przykładowe BMI
    /// bool canSeeCardiologist = CanCardiologist(bmi);
    /// Console.WriteLine($"Czy pacjent może zobaczyć kardiologa? {canSeeCardiologist}");
    /// </code>
    /// </example>
    public static bool CanCardiologist(float bmi)
    {
        if(bmi > 18.4 && bmi < 25)
            return true;
        return false;
    }
    /// <summary>
    /// Wykonuje interakcję z użytkownikiem w celu obliczenia wskaźnika masy ciała (BMI) 
    /// oraz sprawdzenia, czy pacjent może być zbadany przez kardiologa.
    /// </summary>
    /// <returns>
    /// Zwraca 0, jeśli operacja zakończyła się pomyślnie, lub 1 w przypadku błędów.
    /// </returns>
    /// <remarks>
    /// Metoda prosi użytkownika o podanie wieku, wzrostu i wagi. 
    /// W przypadku błędnych danych (np. nieprawidłowy format, wartości poza zakresem) 
    /// wyświetla odpowiednie komunikaty o błędach.
    /// </remarks>
    /// <example>
    /// <code>
    /// int result = Exercise2();
    /// if (result == 1)
    /// {
    ///     Console.WriteLine("Wystąpił błąd podczas wprowadzania danych.");
    /// }
    /// </code>
    /// </example>
    public static int Exercise2()
    {
        try
        {
            Console.Write("Podaj swój wiek: ");
            byte age = Convert.ToByte(Console.ReadLine()??"");
            if(age < 18)
                throw new WarningException();
            Console.Write("Podaj swój wzrost: ");
            byte height = Convert.ToByte(Console.ReadLine()??"");
            Console.Write("Podaj swoją wage: ");
            ushort weight = Convert.ToUInt16(Console.ReadLine()??"");
            if(height < 1 || age < 1 || weight < 1)
                throw new DivideByZeroException();
            float bmi = CalculateBmi(height,weight);
            if(CanCardiologist(bmi))
                Console.WriteLine("Twoje BMI jest prawidłowe, Kardiolog może ciebie zbadać");
            else
                Console.WriteLine("Twoje BMI nie jest prawidłowe, kardiolog nie może ciebie zbadać");
            return 0;
        }
        catch(OverflowException)
        {
            Console.WriteLine("Podałeś swój wiek lub wzrost poza określoną skale: (0-255).");
            return 1;
        }
        catch(FormatException)
        {
            Console.WriteLine("Musisz podać liczbę.");
            return 1;
        }
        catch(DivideByZeroException)
        {
            Console.WriteLine("Twój wiek, wzrost oraz waga musi być większa od zera");
            return 1;
        }
        catch(WarningException)
        {
            Console.WriteLine("Musisz być pełnoletni by ciebie kardiolog zbadał.");
            return 0;
        }
    }
}