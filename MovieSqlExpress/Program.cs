using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieSqlExpress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (movie_dbContext db = new movie_dbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            using (movie_dbContext db = new movie_dbContext())
            {
                bool isAvalaible = db.Database.CanConnect();
                if (!isAvalaible)
                {
                    Console.WriteLine("база данных недоступна");
                }
                else Console.WriteLine("база данных доступна");

                Actor misha = new Actor { FirstName = "Misha", SecondName = "Nosik" };
                db.Add(misha);
                db.SaveChanges();
                var actors = db.Actors.ToList();

                Console.WriteLine("Список актеров:");
                foreach (Actor a in actors)
                {
                    Console.WriteLine($" - {a.Id}: {a.FirstName} {a.SecondName}");


                }
            }

            using (movie_dbContext db = new movie_dbContext())
            {
                Genre thriller_film = new Genre { Name = "Thriller film" };
                Genre psychological_thriller = new Genre {Name = "Psychological thriller" };
                db.AddRange(thriller_film, psychological_thriller);
               
                Movie EVA = new Movie { GenreId = 1, ActorId = 1, Name = "Evangelion", Description = "New Genesis Evangelion", Date = DateTime.Now.Date };
                db.Add(EVA);
                db.SaveChanges();


                var genres = db.Genres.ToList();
                Console.WriteLine("Список жанров:");
                foreach (Genre a in genres)
                {
                    Console.WriteLine($" - {a.Id}: {a.Name}");
                }


                var movies = db.Movies.ToList();
                Console.WriteLine("Список фильмов:");
                foreach (Movie a in movies)
                {
                    Console.WriteLine($" - {a.Id}: {a.Name}, {a.Description}, {a.Date}, {a.ActorId}");
                }


            }
        }
    }
}