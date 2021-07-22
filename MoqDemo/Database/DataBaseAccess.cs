using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MockingDemo.Mapping;
using MockingDemo.Model;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Newtonsoft.Json.Linq;
using System;

namespace MockingDemo.Database
{
    public class DataBaseAccess : IDisposable
    {
        public Configuration NHibernateConfiguration { get; set; }
        public ISessionFactory Factory { get; set; }

        public DataBaseAccess()
        {
            ConfigureDatabase();
            CreateDataBaseSchema();
            FillDataBaseWithData();
        }

        private void ConfigureDatabase()
        {
            NHibernateConfiguration =
                Fluently
                .Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile("BookDataBase.db"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AuthorMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BookMapping>())
                .BuildConfiguration();

            Factory = NHibernateConfiguration.BuildSessionFactory();
        }

        private void CreateDataBaseSchema() =>
            new SchemaExport(NHibernateConfiguration).Create(false, true);

        private void FillDataBaseWithData()
        {
            var booksJson = JObject.Parse(File.ReadAllText("Data/Books.json"));
            
            using var session = Factory.OpenSession();

            foreach (var bookToken in booksJson["books"])
            {
                var newAuthor = bookToken.ToObject<Author>();
                session.Save(newAuthor);

                var newBook = bookToken.ToObject<Book>();
                newBook.AuthoredBy = newAuthor;

                session.Save(newBook);                
            }            
        }

        public List<Author> GetAllAuthors()
        {
            using var session = Factory.OpenSession();

            return session.QueryOver<Author>().List<Author>().ToList();
        }

        public Author GetAuthorById(long id)
        {
            using var session = Factory.OpenSession();

            return session.QueryOver<Author>().Where(author => author.Id == id).SingleOrDefault();
        }

        public List<Book> GetAllBooks()
        {
            using var session = Factory.OpenSession();

            return session.QueryOver<Book>().List<Book>().ToList();               
        }

        public virtual Book GetBookByIsbn(string isbn)
        {
            using var session = Factory.OpenSession();

            return session.Query<Book>().Where(book => book.Isbn == isbn).SingleOrDefault();
        }

        public void Dispose()
        {
            NHibernateConfiguration = null;
            Factory?.Dispose();
            Factory = null;
        }
    }
}
