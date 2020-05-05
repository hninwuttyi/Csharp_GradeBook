using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_GradeBook;
using Xunit;

namespace GradeBook_Test
{
    public delegate int WriteLogDelegate(int logValue);

    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPoingToMethod()
        {
            WriteLogDelegate log = returnValue;
            log += returnValue;
            log += increasementCount;
            var result = log(5);
            Assert.Equal(3, count);

        }
        int increasementCount(int value)
        {
            count++;
            return value;
        }
        int returnValue(int value)
        {
            count++;
            return value;
        }

        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            string name = "Wuttyi";
            var upper = MakeUpperCase(name);
            Assert.Equal("Wuttyi", name);
            Assert.Equal("WUTTYI", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);

        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {

            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(out Book book, string name)
        {
            book = new Book(name);

        }

        [Fact]
        public void CSharpIsPassByValue()
        {

            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);

        }

        [Fact]
        public void CanSetNameFromReference()
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
            Assert.True(object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
