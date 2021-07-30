using System.Collections.Generic;
using System;
using System.IO;


namespace GradeBook
{

 public delegate void GradeAddedDelegate(object sender, EventArgs args);

 public class NamedObject
 {
  public NamedObject(string name)
  {
   Name = name;
  }

  public string Name
  {
   get;
   set;
  }
 }

 public interface IBook
 {
  void AddGrade(double grade);
  Statistics GetStatistics();
  string Name { get; }
  event GradeAddedDelegate GradeAdded;
 }

 public abstract class Book : NamedObject, IBook
 {
  public Book(string name) : base(name)
  {
  }
  public abstract event GradeAddedDelegate GradeAdded;
  public abstract void AddGrade(double grade);
  public abstract Statistics GetStatistics();
 }

 public class DiskBook : Book
 {

  public DiskBook(string name) : base(name)
  {
  }

  public override event GradeAddedDelegate GradeAdded;

  public override void AddGrade(double grade)
  {
   if (grade <= 100 && grade >= 0)
   {
    // var writer = File.AppendText($"{Name}.txt");
    // writer.WriteLine(grade);
    // writer.Dispose();

    // Commom patterns - wrapping with using statement!
    using (var writer = File.AppendText($"{Name}.txt"))
    {
     writer.WriteLine(grade);
     if (GradeAdded != null)
     {
      GradeAdded(this, new EventArgs());
     }
     else
     {
      throw new ArgumentException($"Invalid {nameof(grade)}");
     }
    } // Call Dispose() ให้ หลังจบ curly brace
   }
  }

  public override Statistics GetStatistics()
  {
   var stats = new Statistics(new StreamReader($"{Name}.txt"));
   return stats;
  }
 }

 public class InMemmoryBook : Book
 {
  public InMemmoryBook(string name) : base(name)
  {
   Name = name;
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

  public override void AddGrade(double grade)
  {
   if (grade <= 100 && grade >= 0)
   {
    grades.Add(grade);
    if (GradeAdded != null)
    // at least one is listening
    {
     // rasing event = invoking delegate
     GradeAdded(this, new EventArgs());
    }
   }
   else
   {
    throw new ArgumentException($"Invalid {nameof(grade)}");
    // Console.WriteLine("Invalid value");
   }
  }

  // jsut a field on the Book class
  // so one can invoke book.GradeAdded
  public override event GradeAddedDelegate GradeAdded;

  public override Statistics GetStatistics()
  {
   var stats = new Statistics(grades);
   return stats;
  }

  public List<double> grades;

 }
}