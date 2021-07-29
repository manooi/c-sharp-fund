using System;
using Xunit;

namespace GradeBook.Test
// ถ้าไม่ได้อยู่ใน GrandeBook จะต้อง using ด้วย
{



 public class BookTests
 {



  [Fact]
  public void BookCalculatesAnAverageGrades()
  {

   // arrange
   var book = new Book("Sirawit");

   book.AddGrade(90.0);
   book.AddGrade(85.0);
   book.AddGrade(70.0);

   // act
   var result = book.GetStatistics();

   // assert
   Assert.Equal(90.0, result.High);
   Assert.Equal(81.66, result.Average, 1);
   Assert.Equal(70.0, result.Low);
   Assert.Equal('B', result.Letter);
  }

  [Fact]
  public void TestAddGrade()
  {
   var book = new Book("Grade Book");
   book.AddGrade(100);
   Assert.Equal(100, book.grades[0]);
  }
 }
}
