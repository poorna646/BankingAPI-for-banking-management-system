using BankingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Data;

public class BankingDbContext : DbContext{
    public BankingDbContext(DbContextOptions<BankingDbContext>options):base(options)
    {
    }
    public DbSet<User> Users { get; set; }
}