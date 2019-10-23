
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
            List<Lavoratore> ListL = new List<Lavoratore>();
            Lavoratore l3 = new Lavoratore()
            {
                
            };
            //"(ID, Nome, Cognome, Genere, DataDiNascita, Retribuzione, DataAssunzione, Tipo) "
            Lavoratore[] l1 = new Lavoratore[]
            {
                new Lavoratore()
                {
                    Nome = "Antonio",
                    Cognome = "Conte",
                    Genere = 'M',
                    DataDiNascita = new DateTime(1998, 4, 28),
                    Retribuzione = 13000,
                    DataAssunzione = new DateTime(2019, 9, 26),
                    Tipo = TipoLavoratore.Autonomo
                },

                new Lavoratore()
                {
                    Nome = "Nunzio",
                    Cognome = "Savà",
                    Genere = 'M',
                    DataDiNascita = new DateTime(1999, 10, 17),
                    Retribuzione = 12000,
                    DataAssunzione = new DateTime(2019, 9, 26),
                    Tipo = TipoLavoratore.Dipendente
                },

                new Lavoratore()
                {
                    Nome = "Mislam",
                    Cognome = "Deriai",
                    Genere = 'M',
                    DataDiNascita = new DateTime(1998, 12, 9),
                    Retribuzione = 15000,
                    DataAssunzione = new DateTime(2019, 9, 26),
                    Tipo = TipoLavoratore.Autonomo
                },

                new Lavoratore()
                {
                    Nome = "Cristina",
                    Cognome = "Sacco",
                    Genere = 'F',
                    DataDiNascita = new DateTime(1996, 12, 25),
                    Retribuzione = 12500,
                    DataAssunzione = new DateTime(2019, 9, 26),
                    Tipo = TipoLavoratore.Dipendente
                },

                new Lavoratore()
                {
                    Nome = "Federico",
                    Cognome = "Ferro",
                    Genere = 'M',
                    DataDiNascita = new DateTime(2000, 7, 12),
                    Retribuzione = 16000,
                    DataAssunzione = new DateTime(2019, 9, 26),
                    Tipo = TipoLavoratore.Dipendente
                },
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
            Persone lav = new Persone("Federico", "Bagaggiolo", 'M', 2000, DateTime.Now);

            XmlSerializer serializer = new XmlSerializer(typeof(Persone));
            fullPath = Path.Combine(path, "LavoratoreList1.xml");
            FileStream ll1 = File.Open(fullPath, FileMode.Create);
            serializer.Serialize(ll1, lav);
            Console.WriteLine(lav);
            ll1.Close();

            //DESERIALIZZAZIONE
            fullPath = Path.Combine(path, "LavoratoreList1.xml");
            FileStream ll2 = File.Open(fullPath, FileMode.Open);
            Persone l2 = (Persone)serializer.Deserialize(ll2);
            serializer.Serialize(ll2, lav);
            
            ll2.Close();
            foreach(var l in ListL) 
            {
                DbHelperLavoratori.InsertPerson((Lavoratore)l);
            }
            
            Console.ReadLine();
        }
    }
}
