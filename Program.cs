using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp2
{
    [Serializable]
    internal abstract class class_descr_counterp
    {
        public int ID { get; set; }
        public int bBIN { get; set; }
        public int iIIN { get; set; }
        public string Date_of_creation { get; set; }
        public string Author_of_creation { get; set; }
        public string Date_of_change { get; set; }

        public string Author_of_change { get; set; }
        public object FirstName { get; internal set; }
        public Lawyers Lawyer { get; internal set; }

        public class_descr_counterp(int id, int BIN, int IIN, string date_of_creation, string author_of_creation, string date_of_change, string author_of_change)
        {
            ID = id;
            bBIN = BIN;
            iIIN = IIN;
            Date_of_creation = date_of_creation;
            Author_of_creation = author_of_creation;
            Date_of_change = date_of_change;
            Author_of_change = author_of_change;

        }
        public override string ToString()
        {

            return ID + " " + bBIN + " " + iIIN + " " + Date_of_creation + " " + Author_of_creation + " " + Date_of_change + " " + Author_of_change;
        }
    }

    [Serializable]
    internal class Customers : class_descr_counterp
    {
        public new string FirstName { get; set; }
        public string LastName { get; set; }
        public new Lawyers Lawyer { get; set; }
        public Customers(string firstName, string lastName, Lawyers lawyer, int id, int BIN, int IIN, string date_of_creation, string author_of_creation, string date_of_change, string author_of_change) : base(id, BIN, IIN, date_of_creation, author_of_creation, date_of_change, author_of_change)
        {
            FirstName = firstName;
            LastName = lastName;
            Lawyer = lawyer;
        }
        public override string ToString()
        {
            return FirstName + " " + LastName + " " + ID + " " + bBIN + " " + iIIN + " " + Date_of_creation + " " + Author_of_creation + " " + Date_of_change + " " + Author_of_change;
        }
    }

    internal class Lawyers : class_descr_counterp
    {
        public new string FirstName { get; set; }
        public string LastName { get; set; }
        public int count_of_cus = 0;

        public Lawyers(string firstName, string lastName, int id, int BIN, int IIN, string date_of_creation, string author_of_creation, string date_of_change, string author_of_change) : base(id, BIN, IIN, date_of_creation, author_of_creation, date_of_change, author_of_change)
        {
            FirstName = firstName;
            LastName = lastName;

        }
        public override string ToString()
        {
            return FirstName + " " + LastName + " " + count_of_cus + " " + ID + " " + bBIN + " " + iIIN + " " + Date_of_creation + " " + Author_of_creation + " " + Date_of_change + " " + Author_of_change;
        }
    }

    internal class Program
    {
        static string DBFilePath { get; set; }
        static string DBFilePath_2 { get; set; }
        private static void Main(string[] args)
        {
            string fileDBName = "User";
            string fileDBName_2 = "Lawyesr";
            string fileFOlderPath = Path.GetTempPath();
            DBFilePath = fileFOlderPath + fileDBName;
            DBFilePath_2 = fileFOlderPath + fileDBName_2;

            var customers = new List<Customers>();
            var lawyers = new List<Lawyers>();
            lawyers.Add(new Lawyers("First", "Lawyers_Last", 1, 123, 321, "AL", "DL", "AL", "DL"));
            lawyers.Add(new Lawyers("Second", "Lawyers_Last", 2, 567, 765, "AL", "DL", "AL", "DL"));
            lawyers.Add(new Lawyers("Third", "Lawyers_Last", 3, 123, 321, "AL", "DL", "AL", "DL"));
            lawyers.Add(new Lawyers("Fourth", "Lawyers_Last", 4, 567, 765, "AL", "DL", "AL", "DL"));
            lawyers.Add(new Lawyers("Fifth", "Lawyers_Last", 5, 123, 321, "AL", "DL", "AL", "DL"));

            customers.Add(new Customers("Роберт", "Дауни мл.", lawyers[0], 1, 1234, 4321, "A", "D", "A", "D"));
            customers.Add(new Customers("Крис", "Эванс", lawyers[3], 2, 2345, 5432, "A", "D", "A", "D"));
            customers.Add(new Customers("Скарлетт", "Йоханссон", lawyers[1], 3, 3456, 6543, "A", "D", "A", "D"));
            customers.Add(new Customers("Том", "Хиддлстон", lawyers[3], 4, 4567, 7654, "A", "D", "A", "D"));
            customers.Add(new Customers("Камбербэтч", "Камбербэтч, Бенедикт", lawyers[1], 5, 5678, 8765, "A", "D", "A", "D"));
            customers.Add(new Customers("Марк", "Руффало", lawyers[2], 6, 6789, 9876, "A", "D", "A", "D"));
            customers.Add(new Customers("Крис2", "Эванс2", lawyers[3], 2, 2345, 5432, "A", "D", "A", "D"));
            customers.Add(new Customers("Скарлетт2", "Йоханссон", lawyers[0], 3, 3456, 6543, "A", "D", "A", "D"));
            customers.Add(new Customers("Том2", "Хиддлстон", lawyers[3], 4, 4567, 7654, "A", "D", "A", "D"));
            customers.Add(new Customers("Камбербэтч2", "Камбербэтч, Бенедикт", lawyers[2], 5, 5678, 8765, "A", "D", "A", "D"));
            customers.Add(new Customers("Марк2", "Руффало", lawyers[4], 6, 6789, 9876, "A", "D", "A", "D"));
            try
            {
                Console.WriteLine("Организовать запись");
                Console.WriteLine();
                Save(customers);
                Save(lawyers);
            }
            catch (Exception ex)
            //Организовать обработку некорректного формата входного файла.
            {
                Console.WriteLine("ERROR");
                return;
            }
            Console.WriteLine("чтение коллекции данных классов в / из файл(а):");
            var cus = ReadFromCustomers();
            var law = ReadFromLawyers();
            Console.WriteLine("Customers:");
            foreach (var c in cus)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();
            Console.WriteLine("Lawyers:");
            foreach (var l in law)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine();
            Console.WriteLine("Сделать вывод списка физ лиц. Упорядочить список физ. лиц по Фамилии, Имени, Отчеству:");
            var result = customers.OrderBy(x => x.LastName).ThenBy(y => y.FirstName);
            Save(result.ToList());
            foreach (var u in result)
            {
                Console.WriteLine(u);
            }
            Console.WriteLine();
            Console.WriteLine("Сделать вывод 5 записей из списка юр. лиц. Упорядочить список юр. лиц  по количеству контактных лиц (по убыванию):");
            // использовала цикл для рассчета клиентов для каждого юр. лица метод CountOfCustomers пробигает по клиентом и инкопсулирует если  юр. лица подходить 
            foreach (var a in lawyers)
            {
                CountOfCustomers(customers, a);
            }
            var sortL = lawyers.OrderByDescending(x => x.count_of_cus);
            Save(sortL.ToList());
            Console.WriteLine("Sort lawyers");
            foreach (var a in sortL)
            {
                Console.WriteLine(a);
            }
        }

        private static void SaveToDB(IOrderedEnumerable<Customers> result)
        {
            throw new NotImplementedException();
        }

        static void Save(List<Customers> user)
        {

            string seri = JsonConvert.SerializeObject(user);
            File.WriteAllText(DBFilePath, seri);
        }
        static void Save(List<Lawyers> user)
        {

            string seri = JsonConvert.SerializeObject(user);
            File.WriteAllText(DBFilePath_2, seri);
        }

        static List<Customers> ReadFromCustomers()
        {
            string json = File.ReadAllText(DBFilePath);
            List<Customers> customers = JsonConvert.DeserializeObject<List<Customers>>(json);
            return customers;
        }
        static List<Lawyers> ReadFromLawyers()
        {
            string json = File.ReadAllText(DBFilePath_2);
            List<Lawyers> customers = JsonConvert.DeserializeObject<List<Lawyers>>(json);
            return customers;
        }



        private static void CountOfCustomers(List<Customers> customers, Lawyers l)
        {
            foreach (var c in customers)
            {
                if (c.Lawyer == l)
                {
                    l.count_of_cus++;
                }
            }

        }
    }
}
