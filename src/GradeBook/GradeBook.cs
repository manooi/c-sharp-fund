using System.Collections.Generic;
using System;

namespace GradeBook
{
  class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      this.name = name;
    }

    public void AddGrade(double grade)
    {
      grades.Add(grade);
    }

    public void ShowStats()
    {
      var min = grades[0];
      var max = grades[0];
      var avg = 0.0;

      foreach (var grade in grades)
      {
        if (grade < min)
        {
          min = grade;
        }

        if (grade > max)
        {
          max = grade;
        }
        avg += grade;
      }

      avg = avg / grades.Count;
      Console.WriteLine($"High: {max}, Low: {min}, Avg: {avg}");

    }

    private List<double> grades;
    private string name;

  }
}