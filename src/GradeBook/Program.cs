using System;
using System.Collections.Generic;

namespace GradeBook
{
 class Program
 {
  static void Main(string[] args)
  {
   var book = new Book("Sirawit");
   book.GradeAdded += OnGradeAdded;
   book.GradeAdded += OnGradeAdded;
   book.GradeAdded += OnGradeAdded;

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

   //  book.AddGrade(85.0);
   //  book.AddGrade(95.0);
   //  book.AddGrade(75.0);
   //  book.AddGrade(70.0);
   var result = book.GetStatistics();

   Console.WriteLine(Book.MYCONST);
   Console.WriteLine($"For the book name {book.Name}");
   Console.WriteLine($"Average is {result.Average:N2}");
   Console.WriteLine($"High is {result.High:N2}");
   Console.WriteLine($"Low is {result.Low:N2}");
   Console.WriteLine($"Letter is {result.Letter:N2}");

  }

  static void OnGradeAdded(object sender, EventArgs e)
  {
   Console.WriteLine("A grade was added");

  }

 }
}
