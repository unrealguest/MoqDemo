using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockingDemo.BusinessLogic;
using MockingDemo.Database;
using MockingDemo.Model;
using Moq;

namespace MockingDemoTest
{
    [TestClass]
    public class BookManipulatorTest
    {
        static readonly Author mockAuthor =
                new Author
                {
                    FirstName = "Mocking",
                    LastName = "Bird",
                    Id = -99
                };

        static readonly Book mockBookWithInvalidIsbn =
            new Book
            {
                Title = "Some Book That is Mocked And has an invalid ISBN",
                Published = new System.DateTime(2021, 01, 01),
                Isbn = "0000000000000",
                AuthoredBy = mockAuthor
            };

        static readonly Book mockBookWithValidIsbn =
            new Book
            {
                Title = "Some Book That is Mocked And has a valid ISBN",
                Published = new System.DateTime(2021, 01, 01),
                Isbn = "9780306406157",
                AuthoredBy = mockAuthor
            };

        Mock<DataBaseAccess> _dbAccessMock;

        [TestInitialize]
        public void SetupMocks()
        {
            if (_dbAccessMock == null)
            {
                _dbAccessMock = new Mock<DataBaseAccess>();

                _dbAccessMock.Setup(
                    dbAccess =>
                        dbAccess.GetBookByIsbn("0000000000000"))
                                .Returns(mockBookWithInvalidIsbn);

                _dbAccessMock.Setup(
                    dbAccess =>
                        dbAccess.GetBookByIsbn("9780306406157"))
                                .Returns(mockBookWithValidIsbn); 
            }
        }

        [TestMethod]
        public void ShouldReturnFalseIfIsbnIsNotValid()
        {
            var underTest = 
                new BookManipulator(
                    _dbAccessMock.Object.GetBookByIsbn("0000000000000")
                    );            

            Assert.IsFalse(underTest.CheckIfIsbnIsValid());
        }

        [TestMethod]
        public void ShouldReturnTrueIfIsbnIsValid()
        {
            var underTest = 
                new BookManipulator(
                    _dbAccessMock.Object.GetBookByIsbn("9780306406157")
                    );

            Assert.IsTrue(underTest.CheckIfIsbnIsValid());
        }
    }
}
