using System;
using System.Globalization;

namespace Homework1
{
    class tasks
    {
        enum Seasons { Зима, Весна, Лето, Осень }
        static void Main(string[] args)
        {
            //1 задание
            Console.WriteLine("Введите 3-ёх значное число");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > 1000 | num < 100)
                throw new ArgumentException("Число должно быть трёхзначным", nameof(num));
            DelDozen(ref num);
            Console.WriteLine(num);

            //2 задание
            Console.WriteLine("Введите x клетки шахматного поля");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите y клетки шахматного поля");
            int y = Convert.ToInt32(Console.ReadLine());
            if (x > 9 && x < 0)
                throw new ArgumentException("x должен быть в диапазоне от 1 до 8", nameof(x));
            if (y > 9 && y < 0)
                throw new ArgumentException("y должен быть в диапазоне от 1 до 8", nameof(y));
            var ans = (x + y) % 2 == 0 ? "Клетка с данными координатами имеет чёрный цвет" : "Клетка с данными координатами имеет белый цвет";
            Console.WriteLine(ans);

            //3 задание
            Console.WriteLine("Введите A квадратного уравнения  ");
            double a = Convert.ToDouble(Console.ReadLine());
            if (a == 0)
                throw new ArgumentException("A не должно быть равно 0 ", nameof(a));
            Console.WriteLine("Введите B квадратного уравнения  ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите C квадратного уравнения  ");
            double c = Convert.ToDouble(Console.ReadLine());
            double rootc = (Math.Pow(b, 2) - 4 * a * c);
            if (rootc < 0)
                Console.WriteLine("У квадратного уравнения корней нет");
            if (rootc > 0)
                Console.WriteLine("У квадратного уравнения есть 2 различных корня");
            if (rootc == 0)
                Console.WriteLine("У квадратного уравнения есть 1 корень");

            ///4 задание
            Console.WriteLine("Введите 1 число");
            double n1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите 2 число");
            double n2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Меньшее из двух чисел равно {Takemin(n1, n2)}");

            ///5 задание
            Console.WriteLine($"Введите число от которого будет считаться произведение");
            int begin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Введите число до которого будет считаться произведение");
            int end = Convert.ToInt32(Console.ReadLine());
            if (begin > end)
                (begin, end) = (end, begin);
            double compos = 1;
            for (int i = begin; i <= end; i++)
                if (i % 2 == 0)
                    compos *= i;
            Console.WriteLine($"Произведение чисел от {begin} до {end} равно {compos}");

            ///6 задание
            Console.WriteLine("Введите K");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите набор ненулевых целых чисел, после введения 0 вы закроете набор");
            int lesscount = 0;
            int dividedcount = 0;
            int sn = Convert.ToInt32(Console.ReadLine());
            while (sn != 0)
            {
                if (sn % k == 0)
                    dividedcount++;
                if (sn < k)
                    lesscount++;
                sn = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"Кол-во чисел меньших k равно {lesscount}, а чисел нацело делящихся на k {dividedcount} штук");

            ///7 задание
            Console.WriteLine("Введите номер месяца");
            int season = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Время года, к которому принадлежит этот месяц {SeasonDeterm(season)}");

            ///8 задание
            Console.WriteLine("Введите кол-во раз, которое должна вывестись строка");
            int linenum = Convert.ToInt32(Console.ReadLine());
            SeasonRandomizer(linenum);





        }
        /// <summary>
        /// Функция обнуляет разряд десятков трёхзначного числа
        /// </summary>
        /// <param name="num"></param>
        static void DelDozen(ref int num)
        {
            var safe = num;
            safe %= 100;
            safe /= 10;
            num -= safe * 10;
        }

        /// <summary>
        /// Функция возвращает меньшее из 2 вещественных чисел
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        static double Takemin(double n1, double n2) => (n1 < n2) ? n1 : n2;

        /// <summary>
        /// Метод определяющий время года по введённому месяцу
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        static Seasons SeasonDeterm(int season)
        {
            switch (season)
            {
                case (>= 1 and < 3 or 12):
                    return Seasons.Зима;
                case (>= 3 and < 6):
                    return Seasons.Весна;
                case (>= 6 and < 9):
                    return Seasons.Лето;
                case (>= 9 and < 12):
                    return Seasons.Осень;
                default:
                    throw new ArgumentException("В году 12 месяцев, введите кол во от 1 до 12") ;
            }

        }

        /// <summary>
        /// Метод выводит на консоль соотвественное введённому кол-ву строк строки с номером месяца и сезоном для этого месяца
        /// </summary>
        /// <param name="linenum"></param>
        static void SeasonRandomizer(int linenum)
        {
            Random r = new Random();
            int monthn = r.Next(1, 13);
            for (int i = 0; i<linenum; i++) 
            {
                Console.WriteLine($"Месяц № {monthn}, его сезон: {SeasonDeterm(monthn)}");
                monthn= r.Next(1, 13);
            }
        }






    }
}