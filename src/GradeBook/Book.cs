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
   category = "";
  }

  public void AddGrade(char letter)
  {
   switch (letter)
   {
    case 'A':
     AddGrade(90);
     break;

    case 'B':
     AddGrade(90);
     break;

    case 'C':
     AddGrade(70);
     break;

    default:
     AddGrade(0);
     break;
   }
  }

  public void AddGrade(double grade)
  {
   if (grade <= 100 && grade >= 0)
   {
    grades.Add(grade);
   }
   else
   {
    throw new ArgumentException($"Invalid {nameof(grade)}");
    // Console.WriteLine("Invalid value");
   }
  }

  public Statistics GetStatistics()
  {
   var result = new Statistics();
   result.Average = 0.0;
   result.High = double.MinValue;
   result.Low = double.MaxValue;


   for (var index = 0; index < grades.Count; index++)
   {
    result.High = Math.Max(grades[index], result.High);
    result.Low = Math.Min(grades[index], result.Low);
    result.Average += grades[index];
   }

   result.Average = result.Average / grades.Count;

   switch (result.Average)
   {
    case var d when d >= 90.0:
     result.Letter = 'A';
     break;

    case var d when d >= 80.0:
     result.Letter = 'B';
     break;

    case var d when d >= 70.0:
     result.Letter = 'C';
     break;

    case var d when d >= 60.0:
     result.Letter = 'D';
     break;

    default:
     result.Letter = 'F';
     break;
   }

   return result;
  }

  public List<double> grades;
  // public string Name; // public always uppercase
  private string name;

  public string Name
  {
   get
   {
    return name;
   }
   private set
   {
    if (!String.IsNullOrEmpty(value))
    {
     name = value;
    }
    else
    {
     throw new Exception("Invalid Name.");
    }
   }
  }

  readonly string category = "Science";
  public const string MYCONST = "MAHANIN";

 }
}