using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SardanoZOO
{
    class Leone
    {
        public int LunghezzaCriniera { get; set; }
        public bool ISmaschio { get; set; }

        private double _temperaturaCorporeaC;
        private DateTime _ultimaPredazione;

        public Leone(int lunghezzaCriniera, bool isMaschio)
        {
            LunghezzaCriniera = lunghezzaCriniera;
            ISmaschio = isMaschio;
            _temperaturaCorporeaC = 38.5; // Temperatura media normale
            _ultimaPredazione = DateTime.Now;
        }

        private double CalcolaGiorniDallUltimaPredazione()
        {
            TimeSpan differenza = DateTime.Now - _ultimaPredazione;
            return differenza.TotalDays;
        }

        private bool VerificaTemperaturaAnomala()
        {
            return _temperaturaCorporeaC < 37.0 || _temperaturaCorporeaC > 40.0;
        }


        // Metodo pubblico che calcola il cibo giornaliero (override)
        public double CalcolaCiboDiarioKg()
        {
            // I leoni, carnivori, consumano tra 8 e 10 kg di carne al giorno
            return 9.0; // valore medio
        }

        // Metodo pubblico che calcola il costo di gestione mensile (override)
        public double CalcolaCostoGestioneMensile()
        {
            // Carne costosa, circa 400€ al mese
            return 400.0;
        }

        // Metodo pubblico che emette il verso (override)
        public string EmettiVerso()
        {
            return "ROARRR!";
        }

        // Metodo specifico: ore di sonno al giorno
        public double OreDiSonnoAlGiorno()
        {
            // I leoni dormono tra 16 e 20 ore al giorno
            return 18.0; // valore medio
        }

        // Metodo pubblico per registrare una nuova predazione
        public void RegistraPredazione()
        {
            _ultimaPredazione = DateTime.Now; // aggiorna la data dell'ultimo pasto

            // Puoi eventualmente usare il metodo privato per log interni o calcoli
            double giorniDallUltimoPasto = CalcolaGiorniDallUltimaPredazione();
            bool temperaturaOk = !VerificaTemperaturaAnomala();

            Console.WriteLine($"Predazione registrata. Giorni dall'ultimo pasto: {giorniDallUltimoPasto:F1}");
            Console.WriteLine(temperaturaOk ? "Temperatura corporea nella norma." : "Temperatura anomala!");
        }






    }
}
