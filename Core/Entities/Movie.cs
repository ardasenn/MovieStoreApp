using Core.Enums;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Movie : IEntity
    {
        public Movie()
        {
            Actors = new List<Actor>();
        }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Genre> Genres { get; set; }
        public Director Director { get; set; }
        public List<Actor> Actors { get; set; }
        public decimal Price { get; set; }
        public double Imdb { get; set; }
        public Guid Id { get; set; }
        public DateTime CreationDate {get;set;}
        public DateTime? UpdateDate {get;set;}
        public DateTime? DeleteDate {get;set;}
        public Status Status {get;set;}
        public int SalesQuantity { get; set; }
    }
}
