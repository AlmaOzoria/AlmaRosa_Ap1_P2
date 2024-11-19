using AlmaRosa_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace AlmaRosa_Ap1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options) { }

    public DbSet<Combos> Combos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     

        modelBuilder.Entity<Articulos>().HasData(new List<Articulos>()
        {
            new()
            {
                ArticuloId = 1,
                Descripcion = "Teclado",
                Costo = 1000.0m,
                Precio = 1500.0m,
                Existencia = 100
            },
            new()
            {
                ArticuloId = 2,
                Descripcion = "Tarjeta Grafica",
                Costo = 20000.0m,
                Precio = 30000.0m,
                Existencia = 50
            },
            new()
            {
                ArticuloId = 3,
                Descripcion = "Memoria Ram",
                Costo = 30000.0m,
                Precio = 50000.0m,
                Existencia = 60
            },
            new()
            {
                ArticuloId = 4,
                Descripcion = "Cpu",
                Costo = 120000.0m,
                Precio = 140000.0m,
                Existencia = 70
            }
        }
    );

        base.OnModelCreating(modelBuilder);
    }
} 
 