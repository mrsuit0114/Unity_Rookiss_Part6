﻿using BlazorRankingProject.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorRankingProject.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<GameResult> GameResults { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
	}
}