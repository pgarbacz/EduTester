using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EduTester
{
    
    public class Matematyka : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        int LiczbaPoprawnych = 0;
        int A = 0;
        int B = 0;
        public static int LiczbaZadan = 0;
        public static int ZakresA;
        public static int ZakresB;
        public Random rnd;
       
        public static bool bDodawanie = true;

        public int Score
        {
            get { return LiczbaPoprawnych; }
            set
            {
                LiczbaPoprawnych = value;
                OnPropertyChanged("Score");
            }
        }

        public int NewVal
        {
            get { return A; }
            set
            {
                A = value;
                OnPropertyChanged("NewVal");
            }
        }
        public int NewVal2
        {
            get { return B; }
            set
            {
                B = value;
                OnPropertyChanged("NewVal2");
            }
        }
        

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        
        public Matematyka(int _LiczbaZadan, int _ZakresA, int _ZakresB)
        {
            rnd = new Random();
            LiczbaZadan = _LiczbaZadan;
            ZakresA = _ZakresA;
            ZakresB = _ZakresB;
        }

        public bool EndOfTestCheck()
        {
            bool koniec = false;
            if (LiczbaPoprawnych < LiczbaZadan) koniec = false;
            else koniec = true;
            return koniec;
        }

        public void Losuj()
        {

            NewVal = rnd.Next(0, ZakresA); ;
            NewVal2 = rnd.Next(0, ZakresB); ;

        }

        public bool ZadanieCheck(int _wynik )
        {
            bool rezultat=false;
            if(bDodawanie)
            {
                if (NewVal + NewVal2 == _wynik)
                {
                    Score++;
                    rezultat = true;
                }
                else rezultat = false;
            }
            else
            {
                if (NewVal - NewVal2 == _wynik) rezultat = true;
                else rezultat = false;
            }

            return rezultat;
        }
        
    }
}
