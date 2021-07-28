using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      // var numbers = new double[] { 1.0, 2.123, 123.44, 12.3 };
      // var numbers = new [] { 1.0, 2.123, 123.44, 12.3 };

      // List<double> grades = new List<double>();
      var grades = new List<double>();
      grades.Add(5.0);
      grades.Add(1.0);
      grades.Add(2.0);

      double result = 0.0;

      foreach (var item in grades)
      {
        result += item;
      }

      Console.WriteLine($"The average grade is {(result / grades.Count):N1}");

      // if (args.Length > 0)
      // {
      //   Console.WriteLine($"Hello, {args[0]}!");
      // }
      // else
      // {
      //   Console.WriteLine("Hello!");
      // }
    }
  }
}
