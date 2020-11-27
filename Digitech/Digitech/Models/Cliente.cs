using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace Digitech.Models
{
    public class Cliente
    {


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Nombre { get; set; }
        [MaxLength(255)]
        public string Usuario { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
    }
}