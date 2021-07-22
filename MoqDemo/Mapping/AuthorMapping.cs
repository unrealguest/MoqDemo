using FluentNHibernate.Mapping;
using MockingDemo.Model;

namespace MockingDemo.Mapping
{
    public class AuthorMapping : ClassMap<Author>
    {
        public AuthorMapping()
        {
            Table("Authors");

            Id(author => author.Id);
            Map(author => author.FirstName).Not.Nullable();
            Map(author => author.LastName).Not.Nullable();
        }
    }
}
