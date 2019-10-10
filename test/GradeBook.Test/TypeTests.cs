using System;
using Xunit;

namespace GradeBook.Test
{
    public class TypeTests
    {


        public delegate string WriteToLogDelegate(string logMessage);// delegat definuje ako vyzera metoda
        //ake ma parametre, vystupny parameter


        [Fact]
        public void TestDelegate()
        {
        

        WriteToLogDelegate log; // premenna delegata
        log =ReturnMessage; // neprefavam tu ReturnMessage, chcem novy writelog delegate
        //a chcem ho inicializovat na referenciu ReturnMessage ktora je niekde v triede
        var result = log("Heloo!"); // vyvolam metodu, odkazujem sa na metodu ReturnMessage
        Assert.Equal("Heloo!", result);
        }

         string ReturnMessage(string message) // ten isty typ vstupneho a vystup. parametru ako delegate co som definoval
         {// meno metody sa nemusi zhodovat s nazvom delegatu ani meno parameter ale vstup. a vystup. parameter sa musi zhodovat
            return message;
         }

        [Fact]
        public void StringSpravanie()
        {



          string meno = "Filip"; 
          var velke = Zmen(meno); // ked predavam string tak, tak predavam hodnotou ktora je kopiou smernika na string
          /// ale nie je mozne zmenit string lebo string je nemenitelny
          Zmen(meno);
           Assert.Equal("Filip",meno);
           Assert.Equal("SCOTT",velke);
        }

        private String Zmen(string parameter)
        {
         return  parameter.ToUpper(); // toto uz meni string lebo vraciam novy string, string je inac nemenitelny
        }

      [fact]

      public void HodnotovyTyp()
      {
          int x = 10;
          SetInt(ref x); 
          Assert.Equal(42,x); // musim to predavat referenciou inac to nebude fungovat
      }


      private void SetInt(ref int adad)
      {
            adad = 42;
      }





   [Fact]
        public void odovzdavanieParametrureferenciou()
        {

            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref  book1, "New name"); // v C# predavam kopiu referencie do metody
            //GetBookSetNameRef(out  book1, "New name"); 
            //rovnako ako ref tak aj out predava parameter referenciou
            // rozdiel je v tom ze C# predpoklada ze  predava referencia nebola inicializovana a treba ju inicializovat pred
            //opustenim metody
          Assert.Equal("Book1", book1.name); // meno sa nezmeni
         
        }

            private void GetBookSetNameRef(ref BookTests book, string name)
        {
          book = new BookTests(name); // vytvorim novy objekt book s menom "New name"
          book.name = name;
        }


        
        [Fact]
        public void odovzdavanieParametruhodnotou()
        {

            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New name"); // v C# predavam kopiu referencie do metody
            
          Assert.Equal("Book1", book1.name); // meno sa nezmeni
         
        }


        private void GetBookSetName(BookTests book, string name)
        {
          book = new BookTests(name); // vytvorim novy objekt book s menom "New name"
          book.name = name;
        }



       

        [Fact]
        public void Test0()
        {

            var book1 = GetBook("Book 1");
            SetName(book1, "New name"); // v C# predavam kopiu referencie do metody
            
          Assert.Equal("New name", book1.name);
         
        }


        private void SetName(BookTests book, string name)
        {
          book.name = name;
        }




 [Fact]
        public void Test1()
        {

            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            
          Assert.Equal("Book 1", book1.name);
          Assert.Equal("Book 2", book2.name);
            Assert.NotSame(book1, book2);
      

        }
 [Fact]         
 public void Test2()
        {

            var book1 = GetBook("Book 1");
            var book2 = book1; // do datoveho typu dam objektocy typ a potom bude book2 ukazovat na book1
            
          Assert.Same(book1, book2);
          Assert.True(object.ReferenceEquals(book1, book2)); // toto mi povie ci tieto dva objekty ukazuju na rovnaky objekt

    

        }


        Book GetBook(string meno) // object je najnizsi objektovy typ v C#
        {
            return new Book(meno);
        }
        
    }
}
