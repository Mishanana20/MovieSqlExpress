using System;
using System.Collections.Generic;

namespace MovieSqlExpress
{
    public partial class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
        }

        public int GenreId { get; set; }
        public int ActorId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }

        public virtual Actor Actor { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;

        public virtual ICollection<Actor> Actors { get; set; }
    }
}
