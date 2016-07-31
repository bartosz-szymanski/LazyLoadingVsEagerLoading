using LazyVsEager.Models;

namespace LazyVsEager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LazyVsEagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LazyVsEagerContext context)
        {
            context.Authors.AddOrUpdate(
                x => x.Id,
                new Author() { Id = 1, Name = "Bartosz Szymanski" },
                new Author() { Id = 2, Name = "Rafal Hryniewski" },
                new Author() { Id = 3, Name = "Lukasz Marcinek" });

            context.Blogs.AddOrUpdate(
                x => x.Id,
                new Blog()
                {
                    Id = 1,
                    Address = "bartoszszymanski.net",
                    CreationDate = Convert.ToDateTime("01.06.2016"),
                    AuthorId = 1
                },
                new Blog()
                {
                    Id = 2,
                    Address = "hryniewski.net",
                    CreationDate = Convert.ToDateTime("01.01.2016"),
                    AuthorId = 2
                },
                new Blog()
                {
                     Id = 3,
                     Address = "lmarcinek.pl",
                     CreationDate = Convert.ToDateTime("20.07.2016"),
                     AuthorId = 3
                });
        }
    }
}
