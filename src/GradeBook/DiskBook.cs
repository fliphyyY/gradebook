using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
     // mozem bud dedit z IBook alebo z Book, Book mi poskytuje nejake metody ktore su uz implementovane
    {



        public DiskBook(string name) : base(name) 
       
        {

        }

        public override void AddGrade(double grade)
        {

            /// zapis do textaku

           using( var writer = File.AppendText($"{name}.txt")) //obalim IDisposible objekt do using 
           { //chcem aby sa metoda vzdy vyvolala aj keby niekde vznikne vynimka
            
/* *
                           writer.WriteLine(grade);
                           if (GradeAdded != null)
                           {
                               GradeAdded(this, new EventArgs());
                           }
                           */

           }//ked sa dokonci objekt tak sa vyvola Dispose

          //  writer.Dispose(); /// to iste ako close
        }
 
        public override Statistics GetStatistics()
        {
            throw new System.NotImplementedException();
        }
        /*ked vytvaram DiskBook tak zaroven vytvaram aj Book preto tam je base
*/

    }
}