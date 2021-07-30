using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
 public class Statistics
 {
  public double Average = 0.0;
  public double High = double.MinValue;
  public double Low = double.MaxValue;
  public char Letter;
  public double Sum = 0.0;
  public double Counter = 0.0;
  public List<double> Grades = new List<double>();

  // Constructor for List<double>
  public Statistics(List<double> grades)
  {
   Grades = grades;
   Calculate();
   CalculateLetter();
  }

  // Constructor for file
  public Statistics(StreamReader sr)
  {
   ReadFromFile(sr);
   Calculate();
   CalculateLetter();
  }

  private void ReadFromFile(StreamReader sr)
  {
   String line;
   line = sr.ReadLine();
   //Continue to read until you reach end of file
   while (line != null)
   {
    //write the lie to console window
    Grades.Add(double.Parse(line));
    //Read the next line
    line = sr.ReadLine();
   }
   //close the file
   sr.Close();
  }

  private void Calculate()
  {
   foreach (var grade in Grades)
   {
    Sum += grade;
    High = Math.Max(grade, High);
    Low = Math.Min(grade, Low);
    Counter += 1.0;
   }
   Average = Sum / Counter;
  }

  private void CalculateLetter()
  {
   switch (Average)
   {
    case var d when d >= 90.0:
     Letter = 'A';
     break;

    case var d when d >= 80.0:
     Letter = 'B';
     break;

    case var d when d >= 70.0:
     Letter = 'C';
     break;

    case var d when d >= 60.0:
     Letter = 'D';
     break;

    default:
     Letter = 'F';
     break;
   }
  }
 }
}
