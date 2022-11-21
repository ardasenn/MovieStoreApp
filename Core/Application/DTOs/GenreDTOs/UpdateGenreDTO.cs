﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.GenreDTOs
{
    public class UpdateGenreDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateGenreResponse
    {
        public bool Succeded { get; set; } = true;
        public string Message { get; set; }
    }
}
