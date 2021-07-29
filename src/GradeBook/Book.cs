using System.Collections.Generic;
using System;

namespace GradeBook
{
  public class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      Name = name;
    }

    public void AddGrade(double grade)
    {
      grades.Add(grade);
    }

    public Statistics GetStatistics()
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.High = grades[0];
      result.Low = grades[0];

      foreach (var grade in grades)
      {
        if (grade < result.Low)
        {
          result.Low = grade;
        }

        if (grade > result.High)
        {
          result.High = grade;
        }
        result.Average += grade;
      }
      result.Average = result.Average / grades.Count;
      return result;
    }

    private List<double> grades;
    public string Name; // public always uppercase

  }
}