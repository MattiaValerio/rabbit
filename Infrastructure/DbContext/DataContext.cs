using Castle.Core.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext;

public class DataContext : DbContext
{ 
    public DataContext()
    {
      
    }

    public DbSet<Prodotto> Prodotti { get; set; }
}