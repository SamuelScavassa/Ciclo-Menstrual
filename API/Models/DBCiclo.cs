using Microsoft.EntityFrameworkCore;
 
namespace API.Models;
public class DBCiclo: DbContext
{
    public DBCiclo(DbContextOptions<DBCiclo> options) : base(options)
    {
    }
    public DbSet<User>? Users { get; set;}
    public DbSet<Mestruacao>? Mestruacoes { get; set; }
}