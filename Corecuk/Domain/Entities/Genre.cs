﻿using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Genre : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate {get;set;}
        public DateTime? UpdateDate {get;set;}
        public DateTime? DeleteDate {get;set;}
        public Status Status {get;set;}

        
    }
}
