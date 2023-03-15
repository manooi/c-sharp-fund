using System;
using Xunit;

namespace GradeBook.Test
// ถ้าไม่ได้อยู่ใน GrandeBook จะต้อง using ด้วย
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        #region Reference types

        // 1 - Can modify from reference!
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name"); // Address in book1 is copied into book

            Assert.Equal("New Name", book1.Name);

        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }


        // 2 - Cannot set original ref to new ref! (inside the method)
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            // When we invoke this... we make a copy of book1 --> to book
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name); // Remain the same!
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new InMemmoryBook(name); // try to set to new reference
            book.Name = name; // and modify name
            // No effect on original book object!
        }


        // 3 - Can pass by reference if you want!
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

        #endregion

        #region Value types

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = 3;
            SetInt(x);
            Assert.Equal(3, x);
        }

        private void SetInt(int z)
        {
            z = 42;
        }

        // Value types (using ref)
        [Fact]
        public void ValueTypesAlsoPassByValueRef()
        {
            var x = 3;
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        // Special case for String
        // String is Reference type but behaves like a value type
        // ถึงแม้จะได้ pointer ก็จริง แต่ก็ไม่มีทางที่จะเปลี่ยนค่าได้!

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            // Value types are really immutable!
            // int i = 3;
            // then i = 12; <--- donesn't change but instead replace!

            // String is immutable!

            string name = "Scott";
            MakeUpperCase(name);

            Assert.Equal("SCOTT", name); // this test failed!

        }

        private void MakeUpperCase(string param)
        {
            param.ToUpper();
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

        #endregion

        #region Deligates

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

        #endregion
    }
}
