using System;
namespace MockingDemo.Model
{
    public class Book
    {
        public virtual string Isbn { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime Published { get; set; }
        public virtual Author AuthoredBy { get; set; }
    }
}
