using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;


class Programm
{
    class Fraction
    {
        public int Nomerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int nomerator = 0, int denominator = 0)
        {

            Random rnd_nom = new Random();
            nomerator = rnd_nom.Next(-10, 10);

            Random rnd_den = new Random();
            denominator = rnd_den.Next(-10, 10);

            Nomerator = nomerator;
            Denominator = denominator;
            DivisionByZero(); 
            Console.WriteLine($"Fraction: {Nomerator}/{Denominator}");
        }

        private int RandomWithoutZero()
        {
            Random rnd_num = new Random();
            int number = rnd_num.Next(-10, 10);
            if (number == 0) number++;
            return number; 
        }

        private void DivisionByZero()
        {
            if (Denominator == 0)
            {
                Console.WriteLine("На ноль делить нельзя!");
                Random rnd_den = new Random();
                Console.WriteLine($"Генерация другого не нулевого знаменателя...");
                Denominator = RandomWithoutZero();  
            }
        }

        public void RefactorToRightFraction(int number)
        {
            Nomerator *= number;
            Denominator *= number;
        }

        public void ToString(bool bol = true)
        {
            bol = false; 
            if (Nomerator == 0) Console.WriteLine("Number Answer: 0");
            else if (Nomerator < 0)
            {
                Nomerator *= (-1);
                bol = true; 
            }
            else if (Denominator < 0)
            {
                Denominator *= (-1);
                bol = true; 
            }
            Console.WriteLine(bol == false ? $"Fraction Answer: {Nomerator} / {Denominator}\n" : $"Fraction Answer: - {Nomerator} / {Denominator} \n");
        }

        public static void ToString(float nomerator, bool bol)
        {
            Console.WriteLine(bol == false ? $"Number Answer: {nomerator}\n" : $"Number Answer: - {nomerator}\n");
        }

        public void Reduction()
        {

            if (Nomerator % Denominator == 0)
            {
                Nomerator /= Denominator;
                Denominator = 1;
            }
            if (Denominator % Nomerator == 0)
            {
                Denominator /= Nomerator;
                Nomerator = 1;
            }
            if (Nomerator % 2 == 0 && Denominator % 2 == 0)
            {
                Nomerator /= 2;
                Denominator /= 2;
            }
            if (Nomerator % 3 == 0 && Denominator % 3 == 0)
            {
                Nomerator /= 3;
                Denominator /= 3;
            }
            if (Nomerator % 4 == 0 && Denominator % 4 == 0)
            {
                Nomerator /= 4;
                Denominator /= 4;
            }
            if (Nomerator % 5 == 0 && Denominator % 5 == 0)
            {
                Nomerator /= 5;
                Denominator /= 5;
            }
            if (Nomerator % 6 == 0 && Denominator % 6 == 0)
            {
                Nomerator /= 6;
                Denominator /= 6;
            }
            if (Nomerator % 7 == 0 && Denominator % 7 == 0)
            {
                Nomerator /= 7;
                Denominator /= 7;
            }
            if (Nomerator % 8 == 0 && Denominator % 8 == 0)
            {
                Nomerator /= 8;
                Denominator /= 8;
            }
            if (Nomerator % 9 == 0 && Denominator % 9 == 0)
            {
                Nomerator /= 9;
                Denominator /= 9;
            }
        }

        public static void Whole(ref float nomerator, ref float denominator, bool bol)
        {
            if (nomerator % denominator == 0)
            {
                nomerator /= denominator;
                denominator = 1;
                ToString(nomerator, bol);
            }
        }

        public static bool DecimalNumbers(ref float numerator, ref float denominator)
        {
            bool bol = false;

            if (numerator < 0)
            {
                numerator *= (-1);
                bol = true;
            }
            if (denominator < 0)
            {
                denominator *= (-1);
                bol = true;
            }

            return bol;
        }

        public static Fraction operator +(Fraction number_1, Fraction number_2)
        {
            if (number_1.Denominator == number_2.Denominator) number_1.Nomerator += number_2.Nomerator;
            else
            {
                int num = number_1.Denominator;
                int num_2 = number_2.Denominator;

                number_1.RefactorToRightFraction(num_2);
                number_2.RefactorToRightFraction(num);

                number_1.Nomerator += number_2.Nomerator;
            }
            return number_1;
        }

        public static Fraction operator -(Fraction number_1, Fraction number_2) // Change if to switch 
        {
            if (number_1.Denominator == number_2.Denominator) number_1.Nomerator = number_1.Nomerator - number_2.Nomerator;
            else
            {
                int num = number_1.Denominator;
                int num_2 = number_2.Denominator;

                number_1.RefactorToRightFraction(num_2);
                number_2.RefactorToRightFraction(num);

                number_1.Nomerator = number_1.Nomerator - number_2.Nomerator;
            }
            return number_1;
        }

        public static Fraction operator *(Fraction number_1, Fraction number_2)
        {
            number_1.Nomerator = number_1.Nomerator * number_2.Nomerator;
            number_1.Denominator = number_1.Denominator * number_2.Denominator;

            return number_1;
        }

        public static Fraction operator /(Fraction number_1, Fraction number_2)
        {
            number_1.Nomerator = number_1.Nomerator * number_2.Denominator;
            number_1.Denominator = number_1.Denominator * number_2.Nomerator;
            return number_1;
        }

        public static bool operator ==(Fraction number_1, Fraction number_2)
        {
            if (number_1.Nomerator == number_2.Nomerator && number_1.Denominator == number_2.Denominator) return true;
            else return false;
        }

        public static bool operator !=(Fraction number_1, Fraction number_2)
        {
            if (number_1.Nomerator != number_2.Nomerator || number_1.Denominator != number_2.Denominator) return true;
            else return false;
        }

        public static bool operator >(Fraction number_1, Fraction number_2)
        {
            if (Convert.ToSingle(number_1.Nomerator) / Convert.ToSingle(number_1.Denominator) > Convert.ToSingle(number_2.Nomerator) / Convert.ToSingle(number_2.Denominator)) return true;
            else return false; 
        }

        public static bool operator <(Fraction number_1, Fraction number_2)
        {
            if (Convert.ToSingle(number_1.Nomerator) / Convert.ToSingle(number_1.Denominator) < Convert.ToSingle(number_2.Nomerator) / Convert.ToSingle(number_2.Denominator)) return true;
            else return false;
        }
        public static bool operator >=(Fraction number_1, Fraction number_2)
        {
            if (Convert.ToSingle(number_1.Nomerator) / Convert.ToSingle(number_1.Denominator) >= Convert.ToSingle(number_2.Nomerator) / Convert.ToSingle(number_2.Denominator)) return true;
            else return false;
        }

        public static bool operator <=(Fraction number_1, Fraction number_2)
        {
            if (Convert.ToSingle(number_1.Nomerator) / Convert.ToSingle(number_1.Denominator) <= Convert.ToSingle(number_2.Nomerator) / Convert.ToSingle(number_2.Denominator)) return true;
            else return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj is Fraction other)
            {
                return this.Nomerator == other.Nomerator &&
                       this.Denominator == other.Denominator;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nomerator, Denominator);
        }

    }

    public class UnitTests
    {
        public UnitTests()
        {
            Console.WriteLine("Возможные действия: \n 1 - Сложить числа " +
                "\n 2 - Вычесть из одного другое " +
                "\n 3 - Умножить числа" +
                " \n 4 - Разделить одно на другое " +
                "\n 5 - Сравнить числа \n");

            Console.WriteLine("1 - Сложить числа \n");
            new MathClass(1);

            Console.WriteLine("2 - Вычесть одно из другого числа \n");
            new MathClass(2);

            Console.WriteLine("3 - Умножить числа \n");
            new MathClass(3);

            Console.WriteLine("4 - Делить одно на другое число \n");
            new MathClass(4);

            Console.WriteLine("5 - Сравнить числа \n");
            new BoolCheck();

        }

        public class BoolCheck
        {
            Fraction number_1 = new Fraction();
            Fraction number_2 = new Fraction();
            public BoolCheck()
            {

                bool bol = false;

                if (bol = number_1 == number_2) Console.WriteLine("Числа равны");
                else if (bol = number_1 > number_2) Console.WriteLine("Первое число больше второго");
                else if (bol = number_1 < number_2) Console.WriteLine("Первое число меньше второго");
                else if (bol = number_1 >= number_2) Console.WriteLine("Первое число больше или равно второму");
                else if (bol = number_1 <= number_2) Console.WriteLine("Первое число меньше или равно второму");
            }

        }



        public class MathClass
        {
            Fraction number_1 = new Fraction();
            Fraction number_2 = new Fraction();

            public MathClass(int type)
            {
                if (type == 1) number_1 = number_1 + number_2;
                else if (type == 2) number_1 = number_1 - number_2;
                else if (type == 3) number_1 = number_1 * number_2;
                else if (type == 4) number_1 = number_1 / number_2;


                number_1.Reduction();
                number_1.ToString(false);
            }
        }
        public class Application
        {
            static void Main()
            {
                UnitTests unitTest = new UnitTests();
            }
        }
    }
}
