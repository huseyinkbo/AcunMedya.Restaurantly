﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AcunMedya.Restaurantly.Entities;

namespace AcunMedya.Restaurantly.Context
{
        public class RestaurantlyContext:DbContext
        {
            public DbSet<About> Abouts { get; set; }
            public DbSet<Adress> Adress { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Chef> Chefs { get; set; }
            public DbSet<Contact> Contacts { get; set; }
            public DbSet<Feature> Features { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Reservation> Reservations { get; set; }
            public DbSet<Service> Services { get; set; }
            public DbSet<Special> Specials { get; set; }
            public DbSet<Testimonial> Testimonials { get; set; }
        }
    }
