using System;
using System.Collections.Generic;

namespace GradeBook
{

    public interface IBook //interface je vzdy public 
    {
        void AddGrade(double grade); // pri metodach sa predpoklada ze su vzdy public tak sa to tam nepise
       Statistics GetStatistics();
        string Name {get;}
      //  event GradeAddedDelegate GradeAdded;

    }


     

        public abstract class Book : NamedObject, IBook // kazda kniha implementuje interface, od triedy Book dedia ostatne
        { // ked implementujem inteface tak musim mat aj vsetky metody implementovane
        public Book(string name) : base(name) 
        
        {

            //musim tu mat aj konstruktor ked dedim z NamedObject
        }

        public string Name => throw new NotImplementedException();

        public abstract void AddGrade(double grade);// abstraktna metoda je taka ktoru zdedi predok ale este 
            //sa nevie aku by mala mat implemntaciu
            //abstraktna metoda je imlicitne virtualna pretoze niekto urobil implementaciu a override
            //abstraktna metoda je virtualna ktora nema implementaciu
            public void AddGrade0 (double grade)
            {

                        //polymorfizmus, metoda ma rovnaky nazov ale kazdy objekt ju definuje po svojom
            }

            public abstract Statistics GetStatistics();
/* 
        public virtual Statistics GetStatistics()
        {// virtual znamena ze metoda v tejto triede ktora je zdedena z predka, tak v predkovi si moze vybrat implementaciu 
        //tejto metody
            throw new NotImplementedException();
            // nema zmysel mat virtualna metodu ktora nema implementaciu
        }

        */
    }

        public class NamedObject // kazda trieda dedi z objectu :Object
        {
        public NamedObject(string name)
        {
            this.name = name;
        }

        public string name {get; set;}
        }

    public class InMemoryBook  : Book// kebyze dam internal tak trieda sa nebude dat pouzit mimo projektu, public je presny opak
    {// ked definujem dedicnost tak potom nemusim pisat konstruktor a atributy lebo vsetky sa zdedia

                        public delegate void GradeDelegate(object sender, EventArgs args);

/* 
        public string name // property vlastnost, mozem si definovat ako sa bude vlastnost zapisovat a citat
        {

            get
            {
                return name;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }

        }
*/
    
        public string farba { get; set; }


       readonly string zaner = "Akcny"; // iba na citanie


      //  const string  zaner = "asdasd"; const sa nesmie menit v konstruktore


        public const string CATEGORY = "Science";// iba na citanie, je to velkym lebo je to iba na citanie
        // teraz je to staticky clen triedy a nemozem pristupovat k statickemu clenu triedy ako referencia na triedu 
        //ale ako 










        public List<double> grades = new List<double>();



        /*
        Ked vytvarame knihu tak zaroven vytvarame aj NamedObject to znamena ze v dedicnosti je kniha 
        zaroven NamedObject, teda kniha obsahuje vsetko co ma aj NamedObject cize treba povedat 
        C# kompileru ze ako vytvorime NamedObject ked vytvarame Book
         */
        public InMemoryBook(string name) :base(name) 
        {//base pristupuje ku konstruktoru NamedObject cize predka, teda ked vytvaram Book tak vytvaram aj NamedObject cize tam musim dat base
                const int x = 3;
             //   x++; nemozem inkrementovat
            this.zaner = "horor"; // v konstruktore mozem definovat readonly atribute,
            grades = new List<double>();
            this.name = name;// this nad tymto objektom to robim
        }



        public  override void AddGrade(double grade) // kebyze tu je static tak instatcia nema pristup k tejto metode
        //a dalej aj arraylist grades by musel byt static, znamenato ze vsetko co je static je spojene s triedou 
        {
            /*
            
           vzdy Ked dedim z predka ktory je abstraktny, tak musim tam dat override, tym zadefinujem 
           ze cokolvek co moj predok poskytuje tak to prepisem, mozem override iba abstraktne metody a 
            virtualne metody*/

            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade); // tu this netreba lebo je to implicitne pouzite vzdy ked pristupujem ku clen triedy         
                if(GradeAdded != null) // iba vtedy chcem vyvolat delegate ked GradeAdded != 0
                {
                        GradeAdded(this, new EventArgs());  
                }
            }

            else
            {
                System.Console.WriteLine("Nespravny vstup");
            }



        }

        public event GradeDelegate GradeAdded; // event prida nejake schopnosti navyse

        public int GetStatistics(int x)
        {
            return 0;
        }

        public double GetStatistics(double asdasdx) // metody sa pretazuju tak ze metodu s rovnakym menom odlisim 
                                                    //vstupnymi parametrami kde zmenim datavy typ
        {
            return 0.0;
        }


        public override Statistics GetStatistics()
        {

 
            var vysledok = new Statistics();



            vysledok.High = double.MinValue;
            vysledok.Low = double.MaxValue;

            for (int i = 0; i < grades.Count; i++)
            {
                vysledok.Add(grades[i]);
               

            }

            /*
            index = 0;
            do 
            {

                    vysledok.High  = Math.Max(grades[index], vysledok.High);
                vysledok.Low = Math.Min(grades[index], vysledok.Low);
                vysledok.Average += grades[index];
                index ++;
            }while(index < grades.Length);

            ked mam continue tak preskocim vsetko v cykle a idem na iteraciu znova
             */


           // vysledok.Average /= grades.Count;

            switch (vysledok.Average)
            {

                case var d when d >= 90.0: // deklarujem premennu d a potom ju porovnavam cez when 
                    vysledok.znamka = 'A';
                    break;

                case var d when d >= 80.0:
                    vysledok.znamka = 'B';
                    break;

                case var d when d >= 70.0:
                    vysledok.znamka = 'C';
                    break;

                case var d when d >= 60.0:
                    vysledok.znamka = 'D';
                    break;

                default:

                    vysledok.znamka = 'F';
                    break;
            }


            return vysledok;

        }

    }





}