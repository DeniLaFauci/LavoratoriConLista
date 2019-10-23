using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLavoratori2
{
    public enum TipoLavoratore 
    {
        Autonomo,
        Dipendente
    }
    public class Lavoratore : Persone
    {
        public double Retribuzione { get; set; }

        public double RAL
        {
            get
            {
                return Retribuzione * GetMensilità();
            }
        }

        public DateTime? DataAssunzione { get; set; }

        public TipoLavoratore Tipo { get; set; }

        public readonly Guid Persona_ID;

        public Lavoratore()
        {

        }

        public Lavoratore(string nome, string cognome, char genere, DateTime dataDiNascita, double retribuzione, DateTime? dataAssunzione, TipoLavoratore tipo)
            : base(nome, cognome, dataDiNascita)
        {
            Retribuzione = retribuzione;
            DataAssunzione = dataAssunzione;
            Tipo = tipo;
        }

        public Lavoratore(string nome, string cognome, char genere, DateTime dataDiNascita, double retribuzione, DateTime? dataAssunzione, TipoLavoratore tipo, Guid persona_id)
            : base(nome, cognome, dataDiNascita)
        {
            Retribuzione = retribuzione;
            DataAssunzione = dataAssunzione;
            Tipo = tipo;
            Persona_ID = persona_id;
        }

        public int GetMensilità() 
        {
            return Tipo == TipoLavoratore.Autonomo ? 12 : 13;
        }
    }
}
