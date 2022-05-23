using System;
using SQLite;
namespace AppSemana7.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public String Nombre { get; set; }

        [MaxLength(50)]
        public String Usuario { get; set; }

        [MaxLength(50)]
        public String Contrasena { get; set; }

    }
}
