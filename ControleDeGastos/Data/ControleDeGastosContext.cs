using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleDeGastos.Models;

public class ControleDeGastosContext : DbContext
{
    public ControleDeGastosContext(DbContextOptions<ControleDeGastosContext> options)
        : base(options)
    {
    }

    public DbSet<TipoConta> TipoConta { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Conta> Conta { get; set; }
}
