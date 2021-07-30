using System;
using System.Collections.Generic;

namespace GradeBook
{
 class Program
 {
  static void Main(string[] args)
  {
   // var book = new InMemmoryBook("Sirawit");
   // book.GradeAdded += OnGradeAdded;

   // EnterGrades(book);

   // var stats = book.GetStatistics();
   // Console.WriteLine($"For the book name {book.Name}");
   // Console.WriteLine($"Average is {stats.Average:N2}");
   // Console.WriteLine($"High is {stats.High:N2}");
   // Console.WriteLine($"Low is {stats.Low:N2}");
   // Console.WriteLine($"Letter is {stats.Letter:N2}");

   var diskBook = new DiskBook("DiskBook");
   diskBook.GradeAdded += OnGradeAdded;
   diskBook.AddGrade(90);
   diskBook.AddGrade(85);
   diskBook.AddGrade(70);
   var stats = diskBook.GetStatistics();
   Console.WriteLine($"For the book name {diskBook.Name}");
   Console.WriteLine($"Average is {stats.Average:N2}");
   Console.WriteLine($"High is {stats.High:N2}");
   Console.WriteLine($"Low is {stats.Low:N2}");
   Console.WriteLine($"Letter is {stats.Letter:N2}");
  }

  private static void EnterGrades(IBook book)
  {
   while (true)
   {
    Console.WriteLine("Enter grade or press 'q' to exit");
    var input = Console.ReadLine();

    if (input == "q")
    {

     break;
    }

    try
    {
     var grade = double.Parse(input);
     book.AddGrade(grade);
    }
    catch (ArgumentException ex)
    {
     Console.WriteLine(ex.Message);
    }
    catch (FormatException ex)
    {
     Console.WriteLine(ex.Message);
    }
    finally
    {
     // Close file, close connection, clean-up, etc.
    }
   }
  }

  static void OnGradeAdded(object sender, EventArgs e)
  {
   Console.WriteLine("A grade was added");
  }

 }
}
