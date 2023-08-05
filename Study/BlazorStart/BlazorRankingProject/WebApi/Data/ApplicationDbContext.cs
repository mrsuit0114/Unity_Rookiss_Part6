﻿using Microsoft.EntityFrameworkCore;
using SharedDate.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GameResult> GameResults { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }
}
