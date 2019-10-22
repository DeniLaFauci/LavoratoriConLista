
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProgettoLavoratori2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Lavoratori> ListL = new List<Lavoratori>();
            Lavoratori[] l1 = new Lavoratori[]
            { 
                new Lavoratori("Antonio", "Conte", 'M', 14000, new DateTime(1996,7,9)),
                new Lavoratori("Nunzio", "Savà", 'M', 12000, new DateTime(1999,10,17)),
                new Lavoratori("Mislam", "Deriai", 'M', 15000, new DateTime(1998,12,9)),
                new Lavoratori("Cristina", "Sacco", 'F', 12500, new DateTime(1996,12,25)),
                new Lavoratori("Federico", "Ferro", 'M', 14000, new DateTime(2000,7,12))
            };

            ListL.AddRange(l1);

            StringBuilder sb = new StringBuilder();
            foreach (var p in ListL) 
            {
                sb.AppendLine(p.ToString());
            }
            string path = "C:\\Users\\CORSO 48\\source\\repos\\Esercizio";
            string fileName = "ElencoLavoratori.txt";

            //int count = 0;
            //int choice;

            if (Directory.Exists(path)) 
            {
                Directory.CreateDirectory(path);
            }

            string fullPath = Path.Combine(path, fileName);

            if (!File.Exists(fullPath))
            {
                File.Create(fullPath);
            }

            File.WriteAllText(fullPath, sb.ToString());
            string result = File.ReadAllText(fullPath);
            Console.WriteLine(result);

            //SERIALIZZAZIONE
            Lavoratori lav = new Lavoratori("Federico", "Bagaggiolo", 'M', 2000, DateTime.Now);

            XmlSerializer serializer = new XmlSerializer(typeof(Lavoratori));
            fullPath = Path.Combine(path, "LavoratoreList1.xml");
            FileStream ll1 = File.Open(fullPath, FileMode.Create);
            serializer.Serialize(ll1, lav);
            Console.WriteLine(lav);
            ll1.Close();

            //DESERIALIZZAZIONE
            fullPath = Path.Combine(path, "LavoratoreList1.xml");
            FileStream ll2 = File.Open(fullPath, FileMode.Open);
            Lavoratori l2 = (Lavoratori)serializer.Deserialize(ll2);
            serializer.Serialize(ll2, lav);
            
            ll2.Close();


















            //    for (int i = 0; i < count; i++) 
            //    {
            //        Console.WriteLine("\nDIGIT '1' TO INSERT A INDIPENDENT WORKER" +
            //        " OTHERWISE DIGIT ANOTHER NUMBER TO INSERT AN EMPLOYEE");
            //        choice = Insert.Numero();

            //        Console.WriteLine("\nENTER THE NAME: ");
            //        var name = Console.ReadLine();
            //        Console.WriteLine("\nENTER THE SURNAME: ");
            //        var surname = Console.ReadLine();
            //        Console.WriteLine("\nENTER THE GENDER: ");
            //        var gender = Console.ReadLine();
            //        Console.WriteLine("\nENTER THE MONTHLY SALARY: ");
            //        var monthlySalary = int.Parse(Console.ReadLine());
            //        Console.WriteLine("\nENTER THE DATE OF BIRTH IN FORMAT (dd/MM/yyyy): ");
            //        var dateOfBirth = DateTime.Parse(Console.ReadLine());
            //    }
            Console.ReadLine();
        }
    }
}
