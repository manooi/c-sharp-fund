using System;
using Xunit;

namespace GradeBook.Test
// ถ้าไม่ได้อยู่ใน GrandeBook จะต้อง using ด้วย
{

 public delegate string WriteLogDelegate(string logMessage);
 public class TypeTests
 {

  int count = 0;

  [Fact]
  public void WriteLogDelegateCanPoinToMethod()
  {
   WriteLogDelegate log = ReturnMessage;

   //Point to any method that returns string and take a string.
   // Must satisfy the delegate type!
   //1st way - long hand notation
   // log = new WriteLogDelegate(ReturnMessage);

   //2nd way - shorter
   log += ReturnMessage;
   log += IncrementCount;
   // invoked ReturnMessage x 2 and IncrementCount x1
   var result = log("Hello!");
   Assert.Equal(3, count);
   Assert.Equal("hello!", result);

  }

  string IncrementCount(string message)
  {
   count++;
   return message.ToLower();
  }

  string ReturnMessage(string message)
  {
   count++;
   return message;
  }

  [Fact]
  public void StringsBehaveLikeValueType()
  {
   string name = "Sirawit";
   string upper = MakeUpperCase(name);

   Assert.Equal("Sirawit", name);
   Assert.Equal("SIRAWIT", upper);

  }

  private string MakeUpperCase(string parameter)
  {
   // string are immutable ถึงมี ref ให้ แต่ก็แก้ไม่ได้เหมือน ref type อื่น ๆ
   return parameter.ToUpper();
  }

  [Fact]
  public void ValueTypesAlsoPassByValue()
  {
   var x = GetInt();
   SetInt(ref x);
   Assert.Equal(42, x);
  }

  private void SetInt(ref int x)
  {
   x = 42;
  }

  private int GetInt()
  {
   return 3;
  }

  [Fact]
  public void CSharpCanPassByRef()
  {
   var book1 = GetBook("Book 1");
   GetBookSetName(ref book1, "New Name");
   Assert.Equal("New Name", book1.Name);
  }

  private void GetBookSetName(ref Book book, string name)
  {
   book = new InMemmoryBook(name);
  }

  [Fact]
  public void CSharpPassByValue()
  {
   var book1 = GetBook("Book 1");
   // When we invoke this... we make a copy of book1 --> to book
   GetBookSetName(book1, "New Name");
   Assert.Equal("Book 1", book1.Name);
  }

  private void GetBookSetName(Book book, string name)
  {
   book = new InMemmoryBook(name);
   book.Name = name;
  }

  [Fact]
  public void CanSetFromReference()
  {
   var book1 = GetBook("Book 1");
   SetName(book1, "New Name");

   Assert.Equal("New Name", book1.Name);

  }

  private void SetName(Book book, string name)
  {
   book.Name = name;
  }

  [Fact]
  public void GetBookReturnsDifferentObjects()
  {
   var book1 = GetBook("Book 1");
   var book2 = GetBook("Book 2");

   Assert.Equal("Book 1", book1.Name);
   Assert.Equal("Book 2", book2.Name);
   Assert.NotSame(book1, book2);
  }

  [Fact]
  public void TwoVarsCanReferenceSameObject()
  {
   var book1 = GetBook("Book 1");
   var book2 = book1;

   Assert.Same(book1, book2);
   Assert.True(Object.ReferenceEquals(book1, book2));
  }

  Book GetBook(string name)
  {
   return new InMemmoryBook(name);
  }
 }
}
