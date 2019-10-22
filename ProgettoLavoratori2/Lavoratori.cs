using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLavoratori2
{
    [Serializable]
    public class Lavoratori
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public char Genere { get; set; }
        public int StipendioMensile { get; set; }
        public DateTime DataDiNascita { get; set; }

        public Lavoratori() 
        {
        }

        public Lavoratori(string nome, string cognome, char genere, int stipendioMensile, DateTime dataDiNascita) 
        {
            Nome = nome;
            Cognome = cognome;
            Genere = genere;
            StipendioMensile = stipendioMensile;
            DataDiNascita = dataDiNascita;
        }

        public override string ToString()
        {
            return string.Format("Nome: {0}, Cognome: {1}, Genere: {2}, StipendioMensile: {3}, Data di nascita {4:d}",
                Nome,
                Cognome,
                Genere,
                StipendioMensile,
                DataDiNascita);
        }
    }
}
