using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;


class Programm
{
    class Fraction
    {
        public float Nomerator;
        public float Denominator;

        public Fraction(float nomerator = 0, float denominator = 0)
        {
            Console.WriteLine("Ведите числитель: ");
            string number = Console.ReadLine();

            nomerator = Convert.ToSingle(number);

            Console.WriteLine("Ведите знаменатель: ");
            number = Console.ReadLine();

            denominator = Convert.ToSingle(number);

            Nomerator = nomerator;
            Denominator = denominator;

            if (Denominator == 0) return;
        }

        public void RefactorToRightFraction(float number)
        {
            Nomerator *= number;
            Denominator *= number;
        }

        public void ToString(bool bol = true)
        {
            Console.WriteLine(bol == false ? $"Fraction: {Nomerator} / {Denominator}" : $"Fraction: - {Nomerator} / {Denominator}");
        }

        public static void ToString(float nomerator, bool bol)
        {
            Console.WriteLine(bol == false ? $"Fraction: {nomerator}" : $"Fraction: - {nomerator}");
        }

        public void Reduction() // Change if to switch
        {
            /*switch ((Nomerator, Denominator))
            {
                case (0, 0):
                    break;
                case (float num_1, float num_2) when num_1 % 2 == 0 && num_2 % 2 == 0:
                    num_1 /= 2;
                    num_2 /= 2;
                    break;
                case (float num_1, float num_2) when num_1 % 3 == 0 && num_2 % 3 == 0:
                    num_1 /= 3;
                    num_2 /= 3;
                    break;
                case (float num_1, float num_2) when num_1 % 4 == 0 && num_2 % 4 == 0:
                    num_1 /= 4;
                    num_2 /= 4;
                    break;
                case (float num_1, float num_2) when num_1 % 5 == 0 && num_2 % 5 == 0:
                    num_1 /= 5;
                    num_2 /= 5;
                    break;
                case (float num_1, float num_2) when num_1 % 6 == 0 && num_2 % 6 == 0:
                    num_1 /= 6;
                    num_2 /= 6;
                    break;
                case (float num_1, float num_2) when num_1 % 7 == 0 && num_2 % 7 == 0:
                    num_1 /= 7;
                    num_2 /= 7;
                    break;
                case (float num_1, float num_2) when num_1 % 8 == 0 && num_2 % 8 == 0:
                    num_1 /= 8;
                    num_2 /= 8;
                    break;
                case (float num_1, float num_2) when num_1 % 9 == 0 && num_2 % 9 == 0:
                    num_1 /= 9;
                    num_2 /= 9;
                    break;
            }*/
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
            if (number_1.Denominator == number_2.Denominator)
            {
                number_1.Nomerator += number_2.Nomerator;
            }
            else
            {
                float num = number_1.Denominator;
                float num_2 = number_2.Denominator;

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
                //if (number_1.Nomerator % number_2.Denominator == 0)
                //{
                //    number_1.Nomerator /= number_2.Denominator; 
                //}
                //if (number_2.Nomerator % number_1.Denominator == 0)
                //{
                //    number_2.Nomerator /= number_1.Denominator; 
                //} 

                float num = number_1.Denominator;
                float num_2 = number_2.Denominator;

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
            if (number_1.Nomerator / number_1.Denominator > number_2.Nomerator / number_2.Denominator) return true;
            else return false;
        }

        public static bool operator <(Fraction number_1, Fraction number_2)
        {
            if (number_1.Nomerator / number_1.Denominator < number_2.Nomerator / number_2.Denominator) return true;
            else return false;
        }
        public static bool operator >=(Fraction number_1, Fraction number_2)
        {
            if (number_1.Nomerator / number_1.Denominator >= number_2.Nomerator / number_2.Denominator) return true;
            else return false;
        }

        public static bool operator <=(Fraction number_1, Fraction number_2)
        {
            if (number_1.Nomerator / number_1.Denominator <= number_2.Nomerator / number_2.Denominator) return true;
            else return false;
        }

    }

    public class Controller
    {
        int Number;

        public int InputNumber()
        {
            int Number;
            Console.WriteLine("Введите команду: ");
            string number = Console.ReadLine();

            Number = Convert.ToInt32(number);

            return Number;
        }
        public Controller() // Change if to switch 
        {
            Console.WriteLine("Возможные действия: \n 1 - Сложить числа " +
                "\n 2 - Вычесть из одного другое " +
                "\n 3 - Умножить числа" +
                " \n 4 - Разделить одно на другое " +
                "\n 5 - Сравнить числа " +
                "\n 0 - Закончить работу");

            Number = InputNumber();

            while (Number != 0)
            {
                if (Number == 1)
                {
                    MathClass mathem = new MathClass(1);
                }

                if (Number == 2)
                {
                    MathClass mathem = new MathClass(2);
                }


                if (Number == 3)
                {
                    MathClass mathem = new MathClass(3);
                }

                if (Number == 4)
                {
                    MathClass mathem = new MathClass(4);
                }

                if (Number == 5)
                {
                    BoolCheck bol = new BoolCheck();
                }

                Number = InputNumber();
            }
        }
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
            if (type == 1)
            {
                number_1 = number_1 + number_2;
            }
            else if (type == 2)
            {
                number_1 = number_1 - number_2;
            }
            else if (type == 3)
            {
                number_1 = number_1 * number_2;
            }
            else if (type == 4)
            {
                number_1 = number_1 / number_2;
            }

            number_1.Reduction();
            number_1.ToString(false);
        }

        public class App
        {
            static void Main() // Create unit tests 
            {
                Controller controller = new Controller();
            }
        }
    }
}