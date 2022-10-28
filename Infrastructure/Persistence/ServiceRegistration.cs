﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceRegistration 
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<MovieDbContext>(options => options.UseInMemoryDatabase("MovieStoreDb"));

        }
    }
}
