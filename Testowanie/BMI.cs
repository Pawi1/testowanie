using System.ComponentModel;

namespace Testowanie;
internal class Bmi
{
    static float CalculateBmi(int height, int weight)
    {
        return weight / (height*height);
    }
    static bool CanCardiologist(float bmi, int age)
    {
        if(bmi > 18.4 && bmi < 25)
            return true;
        else return false;
    }
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
            if(CanCardiologist(bmi,age))
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