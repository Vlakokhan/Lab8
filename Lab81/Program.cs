using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab81
{
    public class Abonents
    {
        public List<Abonents> ab = new List<Abonents>();
        private double docnumber;
        private string Lastname;
        private string Name;
        private string Adress;
        private double Telephone;
        public void File1()
        {
            int length = File.ReadAllLines("C:\\Users\\vladi\\RiderProjects\\Lab81\\NewFile1.txt").Length;
            for (int i = 0; i < length; i++)
            {
                string[] str = File.ReadAllLines("C:\\Users\\vladi\\RiderProjects\\Lab81\\NewFile1.txt");
                double docnumber = Convert.ToDouble(str[i].Substring(0, 20));
                string Lastname = str[i].Substring(20, 9);
                string Name =str[i].Substring(30, 10);
                string Adress = str[i].Substring(40, 19);
                double Telephone = Convert.ToDouble(str[i].Substring(60, 20));
                ab.Insert(i,new Abonents(){docnumber = this.docnumber,Lastname = this.Lastname,Name = this.Name,Adress = this.Adress,Telephone = this.Telephone});
            }
        }

        public void Add()
        {
            Abonents a = new Abonents();
            Console.WriteLine("Номер документу:");
            a.docnumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Прiзвище:");
            a.Lastname = Console.ReadLine();
            Console.WriteLine("Iм'я:");
            a.Name = Console.ReadLine();
            Console.WriteLine("Адреса:");
            a.Adress = Console.ReadLine();
            Console.WriteLine("Номер телефону:");
            a.Telephone = Convert.ToDouble(Console.ReadLine());
            ab.Add(new Abonents(){docnumber = a.docnumber,Lastname = a.Lastname,Name = a.Name,Adress = a.Adress,Telephone = a.Telephone});
            using (StreamWriter f = new StreamWriter("C:\\Users\\vladi\\RiderProjects\\Lab81\\NewFile1.txt",
                true))
                f.WriteLine($"{a.docnumber,-20}{a.Lastname,-10}{a.Name,-10}{a.Adress,-20}{a.Telephone,-20}");

        }

        public void Edit()
        {
            Abonents a = new Abonents();
            string[] str = File.ReadAllLines("C:\\Users\\vladi\\RiderProjects\\Lab81\\NewFile1.txt");
            Console.WriteLine("Номер рядку:");
            int line = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Номер документу:");
            a.docnumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Прiзвище:");
            a.Lastname = Console.ReadLine();
            Console.WriteLine("Iм'я:");
            a.Name = Console.ReadLine();
            Console.WriteLine("Адреса:");
            a.Adress = Console.ReadLine();
            Console.WriteLine("Номер телефону:");
            a.Telephone = Convert.ToDouble(Console.ReadLine());
            ab.Insert(line-1,new Abonents(){docnumber = a.docnumber,Lastname = a.Lastname,Name = a.Name,Adress = a.Adress,Telephone = a.Telephone});
            ab.RemoveAt(line);
            using (StreamWriter f = new StreamWriter("C:\\Users\\vladi\\RiderProjects\\Lab81\\NewFile1.txt",false))
                for (int i = 0; i < str.Length; i++)
                {
                    if(i != (line - 1))f.WriteLine(str[i]);
                    else f.WriteLine($"{a.docnumber,-20}{a.Lastname,-10}{a.Name,-10}{a.Adress,-20}{a.Telephone,-20}");
                        
                }
        }

        public void Remove()
        {
            Console.WriteLine("Номер рядку:");
            int line = Int32.Parse(Console.ReadLine());
            string[] str = File.ReadAllLines("C:\\Users\\vladi\\RiderProjects\\Lab81\\NewFile1.txt");
            ab.RemoveAt(line-1);
            using (StreamWriter f = new StreamWriter("C:\\Users\\vladi\\RiderProjects\\Lab81\\NewFile1.txt"))
                for (int i = 0; i < str.Length; i++)
                {
                    if (i != line - 1)
                    {
                        f.WriteLine(str[i]);
                    }
                }
        }

        public void Output()
        {
            foreach (var variable in ab)
            {
                Console.WriteLine($"{variable.docnumber,-20}{variable.Lastname,-10}{variable.Name,-10}{variable.Adress,-20}{variable.Telephone,-20}");
            }
        }

        public void Sort()
        {
            List<Abonents> sort = ab.OrderBy(number => number.docnumber).ToList();
            sort.Reverse();
            foreach (var variable in sort)
            {
                Console.WriteLine($"{variable.docnumber,-20}{variable.Lastname,-10}{variable.Name,-10}{variable.Adress,-20}{variable.Telephone,-20}");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Abonents ab = new Abonents();
            ab.File1();
            Console.WriteLine("\nВибiр режиму роботи: ");
            Console.WriteLine("Додавання записiв - Q");
            Console.WriteLine("Редагування записiв - W");
            Console.WriteLine("Знищення записiв - E");
            Console.WriteLine("Виведення iнформацiї з файла на екран - R");
            Console.WriteLine("Сортування за рейтингом - T");
            ConsoleKeyInfo k;
            k = Console.ReadKey(true);
            if (k.Key == ConsoleKey.Q)
            {
                ab.Add();
            }
            if (k.Key == ConsoleKey.W)
            {
                ab.Edit();
            }

            if (k.Key == ConsoleKey.E)
            {
                ab.Remove();
            }

            if (k.Key == ConsoleKey.R)
            {
                ab.Output();
            }

            if (k.Key == ConsoleKey.T)
            {
                ab.Sort();
            }
        }
    }
}