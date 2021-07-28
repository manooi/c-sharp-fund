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
      book.ShowStats();

    }
  }
}
