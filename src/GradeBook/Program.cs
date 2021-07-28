using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("Wit");
      book.AddGrade(85.0);
      book.AddGrade(95.0);
      book.AddGrade(75.0);
      book.AddGrade(70.0);
      var result = book.GetStatistics();
      Console.WriteLine(result.Average);
      Console.WriteLine(result.High);
      Console.WriteLine(result.Low);

    }
  }
}
