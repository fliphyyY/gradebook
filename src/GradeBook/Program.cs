using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {


        static void Main(string[] args)
        {

            //    var p = new Program(); ctrl + K+C komentovanie
            //        Program.Main(args);   //ctrl + k +u odkomentovanie 


            // Book book2 = null; // ked je null tak sa neodkazuje na ziadny objekt
            var book = new InMemoryBook("Filipova kniha");

            NewMethod(book);
            //  Book.AddGrade(77.5);// treba object, toto je na staticke veci

            //     var cisla = new [] {12.7, 10.4, 44.5};// vytvorenie pola v metode, musi mat velkost double cisla = new double[3]
            //nemusim tam davat datovy typ

            //  var grades = new List<double>(){12.7, 10.4, 44.5}; // vytvorenie listu


            var vysledok = book.GetStatistics();
            /* 
            if(args.Length > 0)
            {
            Console.WriteLine("Hello " + args[0] + "!!!!");
            }


            else
            {
                Console.WriteLine("Fattal Error");
            }
            */



            System.Console.WriteLine($"priemer je { vysledok.Average:N10}"); //N10 znamena ze chcem 10 desatinych miest
            System.Console.WriteLine("Maximalna hodnota je {0} a minimalna hodnota je {1}", vysledok.High, vysledok.Low);
            System.Console.WriteLine("Znamka je {0}", vysledok.znamka);

        }

        private static void NewMethod(IBook book) // ked implementujem Interface tak ma nezaujima ako su tieto metody 
        //implementovane, jedine co ma zaujima je   to ze aby boli implementovane nad objektom kniha
        //kazda kniha implementuje IBook
        {
            while (true)
            {


                Console.WriteLine("Zadajte znamky: ");
                var vstup = Console.ReadLine();


                if (vstup == "q")
                {

                    break;

                }


                try
                { // toto sa vykonava



                    double znamka = double.Parse(vstup);
                    book.AddGrade(znamka);

                }

                catch (ArgumentException ex) // zachytenie hocijakej vynimky
                {// zachutenie procesu
                    System.Console.WriteLine(ex.Message);
                    //    throw; vyhodenie vynimky
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);

                }

                finally
                {

                    Console.WriteLine("tento kod sa vzdy vyhodi");

                }


            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added");
        }

    }
}
