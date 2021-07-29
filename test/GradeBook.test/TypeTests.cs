using System;
using Xunit;

namespace GradeBook.Test
// ถ้าไม่ได้อยู่ใน GrandeBook จะต้อง using ด้วย
{
 public class TypeTests
 {

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
   book = new Book(name);
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
   book = new Book(name);
   // book.Name = name;
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
   // book.Name = name;
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
   return new Book(name);
  }
 }
}
