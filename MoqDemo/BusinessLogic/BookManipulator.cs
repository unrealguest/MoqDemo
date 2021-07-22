using System;
using System.Linq;
using MockingDemo.Model;

namespace MockingDemo.BusinessLogic
{
    public class BookManipulator
    {
        private readonly Book _book;

        public BookManipulator(Book book) =>
            _book = book;

        public virtual bool CheckIfIsbnIsValid()
        {
            var checkSum = 0;

            for(int i = 0; i < _book.Isbn.Length-1; i++)            
                checkSum += (i % 2 == 0 ? 1 : 3) * int.Parse(_book.Isbn[i].ToString());

            var checkNum = (checkSum / 10) / 3;

            return 10 - checkNum == int.Parse(_book.Isbn.LastOrDefault().ToString());
        }

        public void DoSomething() =>        
            Console.WriteLine($"Doing something with the book {_book.Title}");        
    }
}
