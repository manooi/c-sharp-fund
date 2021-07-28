using System;
using Xunit;

namespace GradeBook.Test
// ถ้าไม่ได้อยู่ใน GrandeBook จะต้อง using ด้วย
{
  public class BookTests
  {
    [Fact]
    public void Test1()
    {

      // arrange
      var book = new Book("");
      book.AddGrade(90.0);
      book.AddGrade(85.0);
      book.AddGrade(70.0);

      // act
      var result = book.GetStatistics();

      // assert
      Assert.Equal(90.0, result.High);
      Assert.Equal(81.66, result.Average, 1);
      Assert.Equal(70.0, result.Low);


    }
  }
}
