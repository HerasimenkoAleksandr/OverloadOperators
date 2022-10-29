using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadOperators
{
    class Program
    {
        struct Сoefficient
        {
            public int A { get; set; }
            public int B { get; set; }
            public Сoefficient(int a, int b)
            {
                A = a;
                B = b;
            }
            public override string ToString()
            {
                return $"{A}*X+{B}*Y = 0";
            }
            public static Сoefficient Parse(string coefficients)
            {

                Сoefficient temp = new Сoefficient();
                char[] chars = { '.', ' ', ',' };
                var n = coefficients.Split(chars, StringSplitOptions.None);
                temp.A = Int32.Parse(n[0]);
                temp.B = Int32.Parse(n[1]);
                return temp;
            }

        }


        struct LinearEquation
        {
            private Сoefficient AB1;
            private Сoefficient AB2;
            public int C1 { get; set; }
            public int C2 { get; set; }
            public int Sum1 { get; set; }
            public int Sum2 { get; set; }
            public LinearEquation(int b1, int a2, int b2, int a1)
            {
                AB1 = new Сoefficient(a1, b1);
                AB2 = new Сoefficient(a2, b2);
                Sum1 = 0;
                Sum2 = 0;
                C1 = 0;
                C2 = 0;


            }

            public override string ToString()
            {
                return $"{AB1.A}*X+{AB1.B}*Y = {Sum1}\n{AB2.A}*X+{AB2.B}*Y = {Sum2}";
            }
            public string FindXandY()
            {

                if (Sum1 == 0 && Sum2 == 0 && C1 == 0 && C2 == 0)
                    throw new IndexOutOfRangeException();
                else
                    return "В моей задаче иначе не расматривается!";


            }



        }


        class ComplexNumber
        {
            public int A { get; set; }
            public int Bi { get; set; }
            public ComplexNumber(int a, int bi)
            {
                A = a;
                Bi = bi;
            }

            public static ComplexNumber operator +(ComplexNumber obj, ComplexNumber obj2)
            {
                int a = obj.A + obj2.A;
                int b = obj.Bi + obj2.Bi;
                ComplexNumber temp = new ComplexNumber(a, b);
                return temp;
            }
            public static ComplexNumber operator -(ComplexNumber obj, ComplexNumber obj2)
            {
                int a = obj.A - obj2.A;
                int b = obj.Bi - obj2.Bi;
                ComplexNumber temp = new ComplexNumber(a, b);
                return temp;
            }

            public static ComplexNumber operator -(ComplexNumber obj, int i)
            {
                int a = obj.A - i;
                int b = obj.Bi;
                ComplexNumber temp = new ComplexNumber(a, b);
                return temp;
            }
            public static ComplexNumber operator *(ComplexNumber obj, ComplexNumber obj2)
            {
                int a = (obj.A * obj2.A - obj.Bi * obj2.A);
                int b = obj.Bi * obj2.A - obj.A * obj2.Bi;
                ComplexNumber temp = new ComplexNumber(a, b);
                return temp;
            }
            public static ComplexNumber operator *(int i, ComplexNumber obj)
            {
                int a = (obj.A * i);
                int b = obj.Bi * i;
                ComplexNumber temp = new ComplexNumber(a, b);
                return temp;
            }
            public static ComplexNumber operator /(ComplexNumber obj, ComplexNumber obj2)
            {
                int a = (obj.A * obj2.A - obj.Bi * obj2.A) / ((int)Math.Pow(obj2.A, 2) + (int)Math.Pow(obj2.Bi, 2));
                int b = (obj.Bi * obj2.A - obj.A * obj2.Bi) / ((int)Math.Pow(obj2.A, 2) + (int)Math.Pow(obj2.Bi, 2));
                ComplexNumber temp = new ComplexNumber(a, b);
                return temp;
            }

            public override string ToString()
            {
                return $"{A}+{Bi}i";
            }
        }

        class Fraction
        {
            public int Numerator { get; set; }
            public int Denominator { get; set; }
            public Fraction(int numerator, int denominator)
            {
                Numerator = numerator;
                Denominator = denominator;

            }

            public override string ToString()
            {if (Numerator == Denominator)
                    return "1";
            else
                {
                    if(Denominator==1)
                       return $"{Numerator}";
                }
                return $"{Numerator}/{Denominator}";
            }

            public static implicit operator Fraction(double s)
            {
                string g = s.ToString();
                char[] chars = { ',', '.' };
                 var n = g.Split(chars, StringSplitOptions.None);
                int a= Int32.Parse(n[0]);
                int numberChars = n[1].Length;
                int d = Int32.Parse(n[1]);
                int denominator = (int)(Math.Pow(10, numberChars) * a);
                int numerat =((int) (Math.Pow(10, numberChars) * a) + d);
                int i = numerat;

                while (numerat % i != 0 || denominator % i != 0)
                {
                    i--;

                }
                numerat /= i;
                denominator /= i;

                return new Fraction(numerat, denominator);
            }
            public static Fraction operator +(Fraction obj, Fraction obj2)
            {
                int a;
                int b;
                if(obj.Denominator== obj2.Denominator)
                {
                    a=obj.Numerator + obj2.Numerator;
                    b = obj.Denominator;
                    return new Fraction(a,b);
                }
                else
                {
                   b = obj.Denominator * obj2.Denominator;
                   a=obj.Numerator *obj2.Denominator;
                    int a2 =obj2.Numerator * obj.Denominator;
                    a += a2;
                  

                    int i = a;
                   
                    while (a % i != 0 || b % i != 0)
                    {
                        i--;
                       
                    }
                   a /= i;
                   b /= i;
                    return new Fraction(a, b);

                }

            }
            public static Fraction operator +(Fraction obj, double number)
            {
                Fraction obj2 = number;
                int a;
                int b;
                if (obj.Denominator == obj2.Denominator)
                {
                    a = obj.Numerator + obj2.Numerator;
                    b = obj.Denominator;
                    return new Fraction(a, b);
                }
                else
                {
                    b = obj.Denominator * obj2.Denominator;
                    a = obj.Numerator * obj2.Denominator;
                    int a2 = obj2.Numerator * obj.Denominator;
                    a += a2;


                    int i = a;

                    while (a % i != 0 || b % i != 0)
                    {
                        i--;

                    }
                    a /= i;
                    b /= i;
                    return new Fraction(a, b);

                }

            }

            public static Fraction operator *(Fraction obj, double number)
            {
                Fraction obj2 = number;

               

                int a = obj.Numerator * obj2.Numerator;
                int b = obj.Denominator * obj2.Denominator;


                int i = a;

                while (a % i != 0 || b % i != 0)
                {
                    i--;

                }
                a /= i;
                b /= i;
                return new Fraction(a, b);



            }

            public static Fraction operator *(Fraction obj, int number)
            {
                Fraction obj2 = new Fraction(number, 1);

                int a = obj.Numerator * obj2.Numerator;
                int b = obj.Denominator * obj2.Denominator;


                int i = a;

                while (a % i != 0 || b % i != 0)
                {
                    i--;

                }
                a /= i;
                b /= i;
                return new Fraction(a, b);


            }
            public static Fraction operator *(int number, Fraction obj)
            {
                Fraction obj2 = new Fraction(number, 1);
              
                int a= obj.Numerator * obj2.Numerator;
                int b=obj.Denominator * obj2.Denominator;


                int i = a;

                while (a % i != 0 || b % i != 0)
                {
                    i--;

                }
               a /= i;
                b /= i;
                return new Fraction (a,b) ;



            }

            public static bool operator >(Fraction obj, Fraction obj2)
            {
                double i = obj.Numerator / obj.Denominator;
                double j= obj2.Numerator / obj2.Denominator;

                

                if (i>j)
                    return true;
                else
                    return false;

            }
            public static bool operator <(Fraction obj, Fraction obj2)
            {
                double i = obj.Numerator / obj.Denominator;
                double j = obj2.Numerator / obj2.Denominator;



                if (i > j)
                    return false;
                else
                    return true;

            }

            public static bool operator ==(Fraction obj, Fraction obj2)
            {
                int i = obj.Numerator;

                while (obj.Numerator % i != 0 || obj.Denominator % i != 0)
                {
                    i--;

                }
                obj.Numerator /= i;
                obj.Denominator /= i;

                 i = obj2.Numerator;

                while (obj2.Numerator % i != 0 || obj2.Denominator % i != 0)
                {
                    i--;

                }
                obj2.Numerator /= i;
                obj2.Denominator /= i;

                if (obj.Numerator == obj2.Numerator || obj.Denominator == obj2.Denominator)
                    return true;
                else
                    return false;

            }
            public static bool operator !=(Fraction obj, Fraction obj2)
            {
                int i = obj.Numerator;

                while (obj.Numerator % i != 0 || obj.Denominator % i != 0)
                {
                    i--;

                }
                obj.Numerator /= i;
                obj.Denominator /= i;

                i = obj2.Numerator;

                while (obj2.Numerator % i != 0 || obj2.Denominator % i != 0)
                {
                    i--;

                }
                obj2.Numerator /= i;
                obj2.Denominator /= i;

                if (obj.Numerator == obj2.Numerator || obj.Denominator == obj2.Denominator)
                    return false; 
                else
                    return true;

            }

            public static bool operator true(Fraction obj)
            {
                
                return obj.Numerator<obj.Denominator?true:false;



            }
            public static bool operator false(Fraction obj)
            {

                return obj.Numerator > obj.Denominator ? true : false;



            }

          
    public static Fraction operator -(Fraction obj, Fraction obj2)
            {
             int a;
             int b;
                  if (obj.Denominator == obj2.Denominator)
                      {
                      a = obj.Numerator - obj2.Numerator;
                      b = obj.Denominator;
             return new Fraction(a, b);
        }
                else
                {
                    b = obj.Denominator * obj2.Denominator;
                    a=obj.Numerator * obj2.Denominator;
                    int a2=obj2.Numerator *obj.Denominator;
                    a -= a2;
                    
                    int i;
                    if (a < 0)
                    {
                      i = -a;
                    }
                    else
                        i = a;
                    while (a % i != 0 || b % i != 0)
                    {
                        i--;

                    }
                    a /= i;
                    b /= i;
                    return new Fraction(a, b);

                }

            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1 ");
            Сoefficient A = new Сoefficient();
            A = Сoefficient.Parse("3 8");
            Console.WriteLine(A);
            Console.WriteLine("\nЗадание 2 ");
            try
            {
                LinearEquation P = new LinearEquation(5, 8, 7, 2);
                Console.WriteLine(P);
                P.FindXandY();
            }
            catch (Exception L)
            {

                Console.WriteLine("Exception: В настоящем линейном уравнении \nгде с1 и с2 равны 0:\nx и у всегда будут 0!!!");
            }

            Console.WriteLine("\nЗадание 3 ");
            ComplexNumber z = new ComplexNumber(4, 6);
            Console.WriteLine("z=" + z);
            ComplexNumber z1;
            z1 = z - (z * z * z - 1) / (3 * z * z);
            Console.WriteLine("z1=z-(z*z*z-1)/(3*z*z)=" + z1);
            Console.WriteLine("\nЗадание 4 ");


            Fraction f = new Fraction(3, 4);
            Console.WriteLine("создали f:\nf=" + f);
            Console.WriteLine();
            int a = 10;
            Fraction f1 = f * a;
            Console.WriteLine("создали f1:\nf1=f*10;\n Результат f1=" + f1);
            Console.WriteLine();
            Fraction f2 = a*f;
            Console.WriteLine("создали дробь f2:\nf2=10*f;\n Результат f2=" + f2);
            Console.WriteLine();
            Console.WriteLine("проверяем: f2==f1\n Результат:" + (f1==f2));
            Console.WriteLine();
            double d= 1.5;
            Fraction f3 = f+ d;
            Console.WriteLine("создали дробь f3:\nf2=f+1.5;\n Результат f3=" + f3);
            Console.WriteLine();
            Console.WriteLine("проверяем: f3>f2\n Результат:" + (f3 > f2));

            Console.WriteLine("проверяем f3 - правильная дробь или нет ?");
            if(f3)
                Console.WriteLine("Результат: дробь правильная");
           else
                Console.WriteLine("Результат: дробь не правильная");
            Console.WriteLine();
            /*  Console.WriteLine(f);
              Console.WriteLine(f1);
              //f -= f1;
              f1 = f * 10;
              f1 =  10 * f;
              Console.WriteLine("f1-f=" + f1);*/




        }
    }
    }
   

