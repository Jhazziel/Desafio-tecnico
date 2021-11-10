using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante.Gustov.Modelos
{
    public class Menu
    {
        public int MenuId { get; set; }
        public int CategoriaId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CostoUnitario { get; set; }
        public int Cantidad { get; set; }
        public int TipoMovimiento { get; set; }
        public string Descripcion { get; set; }

        public virtual TipoMovimientoEnum TipoMovimientoEnum
        {
            get
            {
                return (TipoMovimientoEnum)TipoMovimiento;
            }
            set
            {
                TipoMovimiento = (int)value;
            }
        }
    }

    public enum TipoMovimientoEnum : int
    { 
        Entrada,
        Salida = 1
    }
}
