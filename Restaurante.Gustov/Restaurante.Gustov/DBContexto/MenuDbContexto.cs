using Microsoft.EntityFrameworkCore;
using Restaurante.Gustov.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Restaurante.Gustov.DBContexto
{
    public class MenuDbContexto : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public MenuDbContexto(DbContextOptions<MenuDbContexto> opcion): base(opcion)
        { 
        
        }

    }
}
