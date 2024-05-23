using CardInfoProvider.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Dynamic;

namespace CardInfoProvider.context;

public class CardDbContext(DbContextOptions<CardDbContext> options) : DbContext(options)
{
    public DbSet<CardInfo> CardInfos { get; set; } = null!;
}


