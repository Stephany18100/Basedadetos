using Basedadetos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basedadetos.Context
{
    public class AplicationDbContext:DbContext
    {
     
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //Aqui se pone cadena de produccion
                optionsBuilder.UseMySQL("Server=localhost; database=23CV; user=root; password=;");
            }

       public DbSet<Empleado>Empleados { get; set; }

    }
}
