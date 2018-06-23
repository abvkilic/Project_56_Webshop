using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ShopMeisterBE_MASTER.Models
{
    public class ShopMeister_Context:DbContext
    {

        public ShopMeister_Context(DbContextOptions<ShopMeister_Context> options) : base(options)
        {

        }
        public DbSet<Product> Product {get;set;}

        public DbSet<User> User {get;set;}   
    }

   
}