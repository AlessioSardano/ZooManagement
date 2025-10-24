using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SardanoZOO
{
    class Animale
    {   
        //Proprietà
        public string Nome { get; set; }
        public string Specie { get; set; }
        public int Età { get; set; }
        public int Peso { get; set; }
        public string StatoDiSalute { get; set; }
        public DateOnly DataArrivo { get; set; }
        public int AnniAlloZoo
        {
            get
            {
                //DateTime serve per quando come output ti serve anche l'orario
                return DateTime.Now.Year - DataArrivo.Year;
            }
        }
        //variabili private
        private double _pesoIniziale;
        private int _numeroControlliVeterinari;

        //metodi privati
        private double CalcolaVariazionePesoPercentuale()
        {
            return 
            ((Peso - _pesoIniziale) / _pesoIniziale) * 100;
        }

        private void DeterminaStatoSaluteAutomatico()
        {
            
            //Variabile per la variazione del paso
            double variazionePeso = CalcolaVariazionePesoPercentuale();
            //variabile che serve per sommare tutti i fattori negativi
           //più fattori negativi --> salute peggiore
            int FattoriNegativi = 0;
            //Mostra la variazione di peso significativa
            if (Math.Abs(variazionePeso) > 10)
                FattoriNegativi++;
            //Mostra l'età avanzata
            if (Età > 15)
                FattoriNegativi++;
            //Mostra i controlli veterinari
            if (_numeroControlliVeterinari >= 5)
                FattoriNegativi++;

            // imposta lo stato di salute in base ai fattori negativi
            if (FattoriNegativi == 0)
                StatoDiSalute = "Ottimo";
            else if (FattoriNegativi == 1)
                StatoDiSalute = "Buono";
            else if (FattoriNegativi == 2)
                StatoDiSalute = "Discreto";
            else
                StatoDiSalute = "Critico";
        }

        //metodi pubblici
        
        //Metodo virtuale (cioè che puo essere sovrascritto da una classe derivata,una sottoclasse che eredita dalla classe base) che serve per calcolare quanto cibo serve ogni giorno
        public virtual double CalcolaCiboDiarioKg()
        {
            return Peso / 20.0;
        }
        //metodo virtuale che serve per calcolare il costo mensile del cibo e delle cure
        public virtual double CalcolaCostoGestioneMensile()
        {
            double costoCiboMensile = CalcolaCiboDiarioKg() * 30 * 2; // es. 2€/kg
            return 100 + costoCiboMensile;
        }

        //metodo virtuale per un verso generico
        public virtual string EmettiVerso()
        {
            return "l'animale emetto un verso";
        }


       











    }
}
