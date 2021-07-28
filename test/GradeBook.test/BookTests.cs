using System;
using Xunit;

namespace GradeBook.test
{
  public class BookTests
  {
    [Fact]
    public void Test1()
    {

      // arraange
      var x = 5;
      var y = 2;
      var expected = 7;

      // act
      var actual = x + y;

      // assert
      Assert.Equal(expected, actual);
    }
  }
}
