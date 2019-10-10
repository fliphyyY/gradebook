using System;
using Xunit;

namespace GradeBook.Test
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {

           //arrange
           var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(45.1);
            book.AddGrade(77.4);

           //act
               

            var result = book.GetStatistics();

            //assert
            Assert.Equal(70.5, result.Average, 1);
              Assert.Equal(89.1, result.High,1);
                Assert.Equal(45.1, result.Low,1);

        }
    }
}
