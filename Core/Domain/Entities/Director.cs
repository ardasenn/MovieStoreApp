using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Director : IEntity
    {
        public Director()
        {
            Movies=new List<Movie>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Movie> Movies { get; set; }
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }=DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }=Status.Active;
        public Actor Actor { get; set; }
    }
}
