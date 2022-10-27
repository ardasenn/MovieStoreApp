﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext()
        {

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
