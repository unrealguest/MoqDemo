using FluentNHibernate.Mapping;
using MockingDemo.Model;

namespace MockingDemo.Mapping
{
    public class BookMapping : ClassMap<Book>
    {
        public BookMapping()
        {
            Table("Books");
            
            Id(book => book.Isbn);
            References(book => book.AuthoredBy);
            Map(book => book.Title).Not.Nullable();
            Map(book => book.Published).Not.Nullable();
        }
    }
}
