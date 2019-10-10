using System;

namespace GradeBook
{

        public class Statistics
        {

                public double Average
                {
                        get 
                        {
                                        return sum/count;
                        }
                }
                public double High;
                public double Low;
                public char znamka ;

                public double sum;
                public int count;

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            sum = 0.0;
            count = 0;
            
        }


        public void Add(double number)
        {
               sum += number;
               count += 1;
                 High = Math.Max(number, High);
                Low = Math.Min(number, Low);
        }
    }
}

/*


 
            var vysledok = new Statistics();
            vysledok.Average = 0.0;



            vysledok.High = double.MinValue;
            vysledok.Low = double.MaxValue;

            foreach (var number in grades)
            {
                vysledok.High = Math.Max(number, vysledok.High);
                vysledok.Low = Math.Min(number, vysledok.Low);
                vysledok.Average += number;

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

            vysledok.Average /= grades.Count; */
             


            